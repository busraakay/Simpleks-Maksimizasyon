
namespace SimplexForm
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.degisken_txt = new System.Windows.Forms.TextBox();
            this.kisit_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Değişken Sayısı Giriniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kısıt Sayısı Giriniz:";
            // 
            // degisken_txt
            // 
            this.degisken_txt.Location = new System.Drawing.Point(315, 41);
            this.degisken_txt.Name = "degisken_txt";
            this.degisken_txt.Size = new System.Drawing.Size(100, 20);
            this.degisken_txt.TabIndex = 2;
            // 
            // kisit_txt
            // 
            this.kisit_txt.Location = new System.Drawing.Point(315, 74);
            this.kisit_txt.Name = "kisit_txt";
            this.kisit_txt.Size = new System.Drawing.Size(100, 20);
            this.kisit_txt.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Onayla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(45, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 88);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zmax Fonksiyonu";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(45, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 230);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kısıtlar";
            this.groupBox2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 527);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Hesapla";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox3.Location = new System.Drawing.Point(45, 575);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 132);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sonuç";
            this.groupBox3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 733);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kisit_txt);
            this.Controls.Add(this.degisken_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox degisken_txt;
        private System.Windows.Forms.TextBox kisit_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

