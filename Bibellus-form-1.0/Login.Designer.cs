namespace Bibellus_form_1._0
{
    partial class Login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.botaologinentrar = new System.Windows.Forms.Button();
            this.User_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.User_pwd = new System.Windows.Forms.TextBox();
            this.aviso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // botaologinentrar
            // 
            this.botaologinentrar.Location = new System.Drawing.Point(135, 97);
            this.botaologinentrar.Name = "botaologinentrar";
            this.botaologinentrar.Size = new System.Drawing.Size(75, 23);
            this.botaologinentrar.TabIndex = 1;
            this.botaologinentrar.Text = "Entrar";
            this.botaologinentrar.UseVisualStyleBackColor = true;
            this.botaologinentrar.Click += new System.EventHandler(this.LoginButton);
            // 
            // User_id
            // 
            this.User_id.Location = new System.Drawing.Point(113, 43);
            this.User_id.Name = "User_id";
            this.User_id.Size = new System.Drawing.Size(129, 20);
            this.User_id.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha:";
            // 
            // User_pwd
            // 
            this.User_pwd.Location = new System.Drawing.Point(113, 71);
            this.User_pwd.Name = "User_pwd";
            this.User_pwd.Size = new System.Drawing.Size(129, 20);
            this.User_pwd.TabIndex = 5;
            this.User_pwd.UseSystemPasswordChar = true;
            // 
            // aviso
            // 
            this.aviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aviso.Location = new System.Drawing.Point(-3, 2);
            this.aviso.Name = "aviso";
            this.aviso.Size = new System.Drawing.Size(292, 38);
            this.aviso.TabIndex = 6;
            this.aviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AcceptButton = this.botaologinentrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 133);
            this.Controls.Add(this.aviso);
            this.Controls.Add(this.User_pwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.User_id);
            this.Controls.Add(this.botaologinentrar);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Shown += new System.EventHandler(this.Login_shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaologinentrar;
        private System.Windows.Forms.TextBox User_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox User_pwd;
        private System.Windows.Forms.Label aviso;
    }
}

