namespace KutuphaneYonetimi
{
    partial class OduncForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OduncForm));
            this.cmbKitaplar = new System.Windows.Forms.ComboBox();
            this.cmbUyeler = new System.Windows.Forms.ComboBox();
            this.btnOduncAl = new System.Windows.Forms.Button();
            this.btnIadeEt = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKitaplar
            // 
            this.cmbKitaplar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKitaplar.FormattingEnabled = true;
            this.cmbKitaplar.Location = new System.Drawing.Point(336, 289);
            this.cmbKitaplar.Name = "cmbKitaplar";
            this.cmbKitaplar.Size = new System.Drawing.Size(197, 24);
            this.cmbKitaplar.TabIndex = 0;
            // 
            // cmbUyeler
            // 
            this.cmbUyeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUyeler.FormattingEnabled = true;
            this.cmbUyeler.Location = new System.Drawing.Point(336, 330);
            this.cmbUyeler.Name = "cmbUyeler";
            this.cmbUyeler.Size = new System.Drawing.Size(197, 24);
            this.cmbUyeler.TabIndex = 1;
            // 
            // btnOduncAl
            // 
            this.btnOduncAl.Location = new System.Drawing.Point(308, 386);
            this.btnOduncAl.Name = "btnOduncAl";
            this.btnOduncAl.Size = new System.Drawing.Size(89, 30);
            this.btnOduncAl.TabIndex = 2;
            this.btnOduncAl.Text = "Ödünç Al";
            this.btnOduncAl.UseVisualStyleBackColor = true;
            this.btnOduncAl.Click += new System.EventHandler(this.btnOduncAl_Click);
            // 
            // btnIadeEt
            // 
            this.btnIadeEt.Location = new System.Drawing.Point(449, 386);
            this.btnIadeEt.Name = "btnIadeEt";
            this.btnIadeEt.Size = new System.Drawing.Size(84, 30);
            this.btnIadeEt.TabIndex = 3;
            this.btnIadeEt.Text = "İade Et";
            this.btnIadeEt.UseVisualStyleBackColor = true;
            this.btnIadeEt.Click += new System.EventHandler(this.btnIadeEt_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(803, 248);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kitap Seç";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Üye Seç";
            // 
            // OduncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnIadeEt);
            this.Controls.Add(this.btnOduncAl);
            this.Controls.Add(this.cmbUyeler);
            this.Controls.Add(this.cmbKitaplar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OduncForm";
            this.Text = "Kitap Ödünç Al | İade Et";
            this.Load += new System.EventHandler(this.OduncForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKitaplar;
        private System.Windows.Forms.ComboBox cmbUyeler;
        private System.Windows.Forms.Button btnOduncAl;
        private System.Windows.Forms.Button btnIadeEt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}