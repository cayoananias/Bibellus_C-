using Bibellus_BD_Csharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibellus_form_1._0
{
    public partial class additem : Form
    {
        private DaO databasesys;
        private Dictionary<string, decimal> precosTamanho;
        private decimal totalVenda = 0;
        public decimal TotalFinal { get; private set; }
        public List<ListViewItem> ItensVenda { get; private set; }

        public additem()
        {
            InitializeComponent();

            // Inicializar os preços por tamanho
            precosTamanho = new Dictionary<string, decimal>
            {
                {"Casquinha", 4.50m},
                {"Pequeno", 13.00m},
                {"Médio", 18.00m},
                {"Grande", 23.00m},
                {"Gigante", 28.00m}
            };

            ItensVenda = new List<ListViewItem>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Adiciona o item selecionado ao ListView
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                string sabor = comboBox1.SelectedItem.ToString();
                string tamanho = comboBox2.SelectedItem.ToString();
                decimal preco = precosTamanho[tamanho];

                // Formatar preço para exibição
                string precoFormatado = preco.ToString("C2");

                // Cria um item para o ListView
                ListViewItem item = new ListViewItem(sabor);
                item.SubItems.Add(tamanho);
                item.SubItems.Add(precoFormatado);

                listView1.Items.Add(item);
                ItensVenda.Add((ListViewItem)item.Clone());

                // Atualizar total da venda
                totalVenda += preco;
                TotalFinal = totalVenda;

                // Limpa as seleções para próxima adição
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

                // Mostrar total atual
                AtualizarTotalVenda();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um sabor e um tamanho.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void additem_Load(object sender, EventArgs e)
        {
            try
            {
                // Inicializar a conexão com o banco
                databasesys = new DaO("server=localhost;password=root;user=root;port=3306;database=bibellus");

                // Configurar o ListView para exibir colunas
                listView1.View = View.Details;
                listView1.Columns.Clear();
                listView1.Columns.Add("Sabor", 250);
                listView1.Columns.Add("Tamanho", 120);
                listView1.Columns.Add("Preço", 120);

                // Ajustar tamanho das colunas
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = -2;
                }

                // Buscar todos os sabores de sorvete do banco
                string[] sabores = databasesys.MYSQLSelect(
                    "produto p INNER JOIN tipo t ON p.id_tipo_fk = t.id",
                    "t.descricao = 'sorvete'",
                    "p.descricao"
                );

                // Limpar e adicionar sabores ao ComboBox
                comboBox1.Items.Clear();
                foreach (string sabor in sabores)
                {
                    string saborLimpo = sabor.TrimEnd(',');
                    if (!string.IsNullOrEmpty(saborLimpo))
                    {
                        comboBox1.Items.Add(saborLimpo);
                    }
                }

                // Selecionar o primeiro item por padrão
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                if (comboBox2.Items.Count > 0)
                    comboBox2.SelectedIndex = 0;
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ao carregar dados: " + Erro.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTotalVenda()
        {
            this.Text = $"Adicionar Item - Total: {totalVenda.ToString("C2")}";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Tem certeza que deseja cancelar a venda?\nTodos os itens serão perdidos.",
                "Cancelar Venda",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void Finalizar_btn_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum item adicionado à venda.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView1.SelectedItems[0];

                string precoStr = itemSelecionado.SubItems[2].Text
                    .Replace("R$", "")
                    .Replace(" ", "")
                    .Trim();

                if (decimal.TryParse(precoStr, out decimal precoItem))
                {
                    totalVenda -= precoItem;
                    TotalFinal = totalVenda;
                }

                itemSelecionado.Remove();
                AtualizarTotalVenda();
            }
        }
    }
}