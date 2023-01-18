namespace ISUTechnicalService
{
    partial class Buy
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
            this.components = new System.ComponentModel.Container();
            this.cmboxCategory = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmboxBrand = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmboxModel = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnSale = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmboxCategory
            // 
            this.cmboxCategory.FormattingEnabled = true;
            this.cmboxCategory.Location = new System.Drawing.Point(192, 146);
            this.cmboxCategory.Name = "cmboxCategory";
            this.cmboxCategory.Size = new System.Drawing.Size(130, 21);
            this.cmboxCategory.TabIndex = 0;
            this.cmboxCategory.SelectedIndexChanged += new System.EventHandler(this.cmboxCategory_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmboxBrand
            // 
            this.cmboxBrand.FormattingEnabled = true;
            this.cmboxBrand.Location = new System.Drawing.Point(401, 146);
            this.cmboxBrand.Name = "cmboxBrand";
            this.cmboxBrand.Size = new System.Drawing.Size(130, 21);
            this.cmboxBrand.TabIndex = 2;
            this.cmboxBrand.SelectedIndexChanged += new System.EventHandler(this.cmboxBrand_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ISUTechnicalService.Properties.Resources._2194108_stock_photo_e_commerce_icon_orange_button;
            this.pictureBox1.Location = new System.Drawing.Point(667, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cmboxModel
            // 
            this.cmboxModel.FormattingEnabled = true;
            this.cmboxModel.Location = new System.Drawing.Point(335, 215);
            this.cmboxModel.Name = "cmboxModel";
            this.cmboxModel.Size = new System.Drawing.Size(130, 21);
            this.cmboxModel.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(496, 276);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 4;
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(344, 314);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(75, 23);
            this.btnSale.TabIndex = 5;
            this.btnSale.Text = "SALES";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(613, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Buy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cmboxModel);
            this.Controls.Add(this.cmboxBrand);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmboxCategory);
            this.Name = "Buy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buy";
            this.Load += new System.EventHandler(this.Buy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboxCategory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmboxBrand;
        private System.Windows.Forms.ComboBox cmboxModel;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button button1;
    }
}