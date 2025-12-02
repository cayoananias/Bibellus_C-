using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibellus_BD_Csharp;

namespace Bibellus_form_1._0
{
    public partial class Vendas_panel : Form
    {
        private DaO databasesys;
        private decimal totalVendaAtual = 0;
        private string metodoPagamento = "";

        public Vendas_panel()
        {
            InitializeComponent();
        }

        private void Vendas_panel_Shown(object sender, EventArgs e)
        {
            new Login().ShowDialog();
        }

        private void additem_Click(object sender, EventArgs e)
        {
            using (additem formAddItem = new additem())
            {
                if (formAddItem.ShowDialog() == DialogResult.OK)
                {
                    // Adicionar itens ao list_itens
                    foreach (ListViewItem item in formAddItem.ItensVenda)
                    {
                        list_itens.Items.Add((ListViewItem)item.Clone());
                    }

                    // Atualizar total
                    totalVendaAtual += formAddItem.TotalFinal;
                    AtualizarTotal();
                }
            }
        }

        private void AtualizarTotal()
        {
            Valor.Text = totalVendaAtual.ToString("N2");
        }

        private void Vendas_panel_Load(object sender, EventArgs e)
        {
            try
            {
                databasesys = new DaO("server=localhost;password=root;user=root;port=3306;database=bibellus");
                ConfigurarListView();
                ConfigurarBotoesPagamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarListView()
        {
            list_itens.View = View.Details;
            list_itens.Columns.Clear();
            list_itens.Columns.Add("Sabor", 200);
            list_itens.Columns.Add("Tamanho", 100);
            list_itens.Columns.Add("Preço", 100);
        }

        private void ConfigurarBotoesPagamento()
        {
            // Remover botões antigos
            this.Controls.Remove(Rmv_item);
            this.Controls.Remove(Alt_item);
            this.Controls.Remove(Concluir);

            // Criar botões de pagamento
            Button btnDinheiro = new Button();
            btnDinheiro.Location = new Point(613, 150);
            btnDinheiro.Size = new Size(159, 32);
            btnDinheiro.Text = "Dinheiro";
            btnDinheiro.BackColor = Color.LightGreen;
            btnDinheiro.Click += (s, e) => SelecionarPagamento("Dinheiro");
            this.Controls.Add(btnDinheiro);

            Button btnCartaoCredito = new Button();
            btnCartaoCredito.Location = new Point(613, 188);
            btnCartaoCredito.Size = new Size(159, 32);
            btnCartaoCredito.Text = "Cartão Crédito";
            btnCartaoCredito.BackColor = Color.LightBlue;
            btnCartaoCredito.Click += (s, e) => SelecionarPagamento("Cartão Crédito");
            this.Controls.Add(btnCartaoCredito);

            Button btnCartaoDebito = new Button();
            btnCartaoDebito.Location = new Point(613, 226);
            btnCartaoDebito.Size = new Size(159, 32);
            btnCartaoDebito.Text = "Cartão Débito";
            btnCartaoDebito.BackColor = Color.LightCyan;
            btnCartaoDebito.Click += (s, e) => SelecionarPagamento("Cartão Débito");
            this.Controls.Add(btnCartaoDebito);

            Button btnPix = new Button();
            btnPix.Location = new Point(613, 264);
            btnPix.Size = new Size(159, 32);
            btnPix.Text = "PIX";
            btnPix.BackColor = Color.LightGoldenrodYellow;
            btnPix.Click += (s, e) => SelecionarPagamento("PIX");
            this.Controls.Add(btnPix);

            // Botão Finalizar Venda
            Button btnFinalizarVenda = new Button();
            btnFinalizarVenda.Location = new Point(613, 302);
            btnFinalizarVenda.Size = new Size(159, 32);
            btnFinalizarVenda.Text = "Finalizar Venda";
            btnFinalizarVenda.BackColor = Color.Green;
            btnFinalizarVenda.ForeColor = Color.White;
            btnFinalizarVenda.Font = new Font(btnFinalizarVenda.Font, FontStyle.Bold);
            btnFinalizarVenda.Click += btnFinalizarVenda_Click;
            this.Controls.Add(btnFinalizarVenda);
        }

        private void SelecionarPagamento(string metodo)
        {
            metodoPagamento = metodo;
            MessageBox.Show($"Método selecionado: {metodo}", "Pagamento",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (list_itens.Items.Count == 0)
            {
                MessageBox.Show("Nenhum item na venda.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(metodoPagamento))
            {
                MessageBox.Show("Selecione um método de pagamento.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar venda
            DialogResult resultado = MessageBox.Show(
                $"Finalizar venda?\n\nTotal: {totalVendaAtual.ToString("C2")}\nMétodo: {metodoPagamento}",
                "Confirmar Venda",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Salvar venda no banco
                    int resultadoInsert = databasesys.MYSQLInsert(
                        "vendas",
                        $"'{metodoPagamento}', {totalVendaAtual}, 'Venda realizada'",
                        "pagamento, valor, observacao"
                    );

                    if (resultadoInsert > 0)
                    {
                        MessageBox.Show("Venda registrada com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpar tudo
                        list_itens.Items.Clear();
                        totalVendaAtual = 0;
                        Valor.Text = "0,00";
                        metodoPagamento = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar venda: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para remover item selecionado (opcional)
        private void RemoverItemSelecionado()
        {
            if (list_itens.SelectedItems.Count > 0)
            {
                ListViewItem item = list_itens.SelectedItems[0];
                string precoStr = item.SubItems[2].Text.Replace("R$", "").Replace(" ", "").Trim();

                if (decimal.TryParse(precoStr, out decimal preco))
                {
                    totalVendaAtual -= preco;
                    AtualizarTotal();
                }

                list_itens.Items.Remove(item);
            }
        }

        // Se quiser manter o botão de remover, adicione este método
        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverItemSelecionado();
        }
    }
}