
namespace CreateMosFileDeneme
{
    partial class Form1
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
            this.buttonExcelOku = new System.Windows.Forms.Button();
            this.buttonDosyaOlustur = new System.Windows.Forms.Button();
            this.buttonMosOlustur = new System.Windows.Forms.Button();
            this.listBoxIslemler = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonExcelOku
            // 
            this.buttonExcelOku.Location = new System.Drawing.Point(12, 12);
            this.buttonExcelOku.Name = "buttonExcelOku";
            this.buttonExcelOku.Size = new System.Drawing.Size(80, 80);
            this.buttonExcelOku.TabIndex = 0;
            this.buttonExcelOku.Text = "Excel Oku";
            this.buttonExcelOku.UseVisualStyleBackColor = true;
            this.buttonExcelOku.Click += new System.EventHandler(this.buttonExcelOku_Click);
            // 
            // buttonDosyaOlustur
            // 
            this.buttonDosyaOlustur.Enabled = false;
            this.buttonDosyaOlustur.Location = new System.Drawing.Point(12, 98);
            this.buttonDosyaOlustur.Name = "buttonDosyaOlustur";
            this.buttonDosyaOlustur.Size = new System.Drawing.Size(80, 80);
            this.buttonDosyaOlustur.TabIndex = 1;
            this.buttonDosyaOlustur.Text = "Dosya Oluştur";
            this.buttonDosyaOlustur.UseVisualStyleBackColor = true;
            this.buttonDosyaOlustur.Click += new System.EventHandler(this.buttonDosyaOlustur_Click);
            // 
            // buttonMosOlustur
            // 
            this.buttonMosOlustur.Enabled = false;
            this.buttonMosOlustur.Location = new System.Drawing.Point(12, 184);
            this.buttonMosOlustur.Name = "buttonMosOlustur";
            this.buttonMosOlustur.Size = new System.Drawing.Size(80, 80);
            this.buttonMosOlustur.TabIndex = 2;
            this.buttonMosOlustur.Text = ".mos Oluştur";
            this.buttonMosOlustur.UseVisualStyleBackColor = true;
            this.buttonMosOlustur.Click += new System.EventHandler(this.buttonMosOlustur_Click);
            // 
            // listBoxIslemler
            // 
            this.listBoxIslemler.FormattingEnabled = true;
            this.listBoxIslemler.ItemHeight = 16;
            this.listBoxIslemler.Location = new System.Drawing.Point(114, 20);
            this.listBoxIslemler.Name = "listBoxIslemler";
            this.listBoxIslemler.Size = new System.Drawing.Size(264, 244);
            this.listBoxIslemler.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 279);
            this.Controls.Add(this.listBoxIslemler);
            this.Controls.Add(this.buttonMosOlustur);
            this.Controls.Add(this.buttonDosyaOlustur);
            this.Controls.Add(this.buttonExcelOku);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExcelOku;
        private System.Windows.Forms.Button buttonDosyaOlustur;
        private System.Windows.Forms.Button buttonMosOlustur;
        private System.Windows.Forms.ListBox listBoxIslemler;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

