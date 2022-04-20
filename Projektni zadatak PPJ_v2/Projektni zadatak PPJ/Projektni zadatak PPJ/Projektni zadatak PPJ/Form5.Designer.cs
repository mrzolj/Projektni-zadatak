namespace WindowsFormsApplication1
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikazBrisanjeNarudzbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prikaz / Brisanje narudzbe";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Brisanje narudzbe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(133, 271);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID narudzbe:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(562, 200);
            this.dataGridView1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 18);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem,
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem,
            this.prikazBrisanjeNarudzbeToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // kreiranjeAzuriranjeKupcaToolStripMenuItem
            // 
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Name = "kreiranjeAzuriranjeKupcaToolStripMenuItem";
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Text = "Kreiranje / Azuriranje kupca";
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Click += new System.EventHandler(this.kreiranjeAzuriranjeKupcaToolStripMenuItem_Click);
            // 
            // dodavanjeAzuriranjeArtikalaToolStripMenuItem
            // 
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Name = "dodavanjeAzuriranjeArtikalaToolStripMenuItem";
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Text = "Dodavanje / Azuriranje artikala";
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Click += new System.EventHandler(this.dodavanjeAzuriranjeArtikalaToolStripMenuItem_Click);
            // 
            // prikazBrisanjeNarudzbeToolStripMenuItem
            // 
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Name = "prikazBrisanjeNarudzbeToolStripMenuItem";
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Text = "Prikaz / Brisanje narudzbe";
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Click += new System.EventHandler(this.prikazBrisanjeNarudzbeToolStripMenuItem_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 391);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prikaz / Brisanje narudzbe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form5_FormClosing);
            this.Load += new System.EventHandler(this.Form5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreiranjeAzuriranjeKupcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodavanjeAzuriranjeArtikalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikazBrisanjeNarudzbeToolStripMenuItem;
    }
}