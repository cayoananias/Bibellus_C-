namespace Bibellus_form_1._0
{
    partial class Vendas_panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.view_vendas = new System.Windows.Forms.ToolStripMenuItem();
            this.view_estoque = new System.Windows.Forms.ToolStripMenuItem();
            this.additem = new System.Windows.Forms.Button();
            this.Rmv_item = new System.Windows.Forms.Button();
            this.Alt_item = new System.Windows.Forms.Button();
            this.Concluir = new System.Windows.Forms.Button();
            this.list_itens = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.Valor = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.view_vendas,
            this.view_estoque});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // view_vendas
            // 
            this.view_vendas.Name = "view_vendas";
            this.view_vendas.Size = new System.Drawing.Size(134, 24);
            this.view_vendas.Text = "Visualizar vendas";
            // 
            // view_estoque
            // 
            this.view_estoque.Name = "view_estoque";
            this.view_estoque.Size = new System.Drawing.Size(140, 24);
            this.view_estoque.Text = "Visualisar Estoque";
            // 
            // additem
            // 
            this.additem.Location = new System.Drawing.Point(613, 114);
            this.additem.Name = "additem";
            this.additem.Size = new System.Drawing.Size(159, 32);
            this.additem.TabIndex = 1;
            this.additem.Text = "Adicionar item";
            this.additem.UseVisualStyleBackColor = true;
            this.additem.Click += new System.EventHandler(this.additem_Click);
            // 
            // Rmv_item
            // 
            this.Rmv_item.Location = new System.Drawing.Point(613, 271);
            this.Rmv_item.Name = "Rmv_item";
            this.Rmv_item.Size = new System.Drawing.Size(159, 32);
            this.Rmv_item.TabIndex = 2;
            this.Rmv_item.Text = "Remover item";
            this.Rmv_item.UseVisualStyleBackColor = true;
            // 
            // Alt_item
            // 
            this.Alt_item.Location = new System.Drawing.Point(613, 233);
            this.Alt_item.Name = "Alt_item";
            this.Alt_item.Size = new System.Drawing.Size(159, 32);
            this.Alt_item.TabIndex = 3;
            this.Alt_item.Text = "Alterar ";
            this.Alt_item.UseVisualStyleBackColor = true;
            // 
            // Concluir
            // 
            this.Concluir.Location = new System.Drawing.Point(613, 309);
            this.Concluir.Name = "Concluir";
            this.Concluir.Size = new System.Drawing.Size(159, 32);
            this.Concluir.TabIndex = 4;
            this.Concluir.Text = "Concluir";
            this.Concluir.UseVisualStyleBackColor = true;
            // 
            // list_itens
            // 
            this.list_itens.HideSelection = false;
            this.list_itens.Location = new System.Drawing.Point(12, 32);
            this.list_itens.Name = "list_itens";
            this.list_itens.Size = new System.Drawing.Size(579, 318);
            this.list_itens.TabIndex = 5;
            this.list_itens.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(607, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total:";
            // 
            // Valor
            // 
            this.Valor.AutoSize = true;
            this.Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor.Location = new System.Drawing.Point(701, 41);
            this.Valor.Name = "Valor";
            this.Valor.Size = new System.Drawing.Size(71, 31);
            this.Valor.TabIndex = 7;
            this.Valor.Text = "0,00";
            // 
            // Vendas_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Valor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_itens);
            this.Controls.Add(this.Concluir);
            this.Controls.Add(this.Alt_item);
            this.Controls.Add(this.Rmv_item);
            this.Controls.Add(this.additem);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Vendas_panel";
            this.Text = "Caixa";
            this.Load += new System.EventHandler(this.Vendas_panel_Load);
            this.Shown += new System.EventHandler(this.Vendas_panel_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem view_vendas;
        private System.Windows.Forms.ToolStripMenuItem view_estoque;
        private System.Windows.Forms.Button additem;
        private System.Windows.Forms.Button Rmv_item;
        private System.Windows.Forms.Button Alt_item;
        private System.Windows.Forms.Button Concluir;
        private System.Windows.Forms.ListView list_itens;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Valor;
    }
}