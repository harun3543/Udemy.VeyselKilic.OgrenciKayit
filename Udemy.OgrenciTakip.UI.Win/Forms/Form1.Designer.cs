
namespace Udemy.OgrenciTakip.UI.Win.Forms
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
            this.myToogleSwitch1 = new Udemy.OgrenciTakip.UI.Win.UserControls.Controls.MyToogleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.myToogleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // myToogleSwitch1
            // 
            this.myToogleSwitch1.EnterMoveNextControl = true;
            this.myToogleSwitch1.Location = new System.Drawing.Point(153, 308);
            this.myToogleSwitch1.Name = "myToogleSwitch1";
            this.myToogleSwitch1.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.myToogleSwitch1.Properties.Appearance.Options.UseForeColor = true;
            this.myToogleSwitch1.Properties.AutoHeight = false;
            this.myToogleSwitch1.Properties.AutoWidth = true;
            this.myToogleSwitch1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.myToogleSwitch1.Properties.OffText = "Pasif";
            this.myToogleSwitch1.Properties.OnText = "Aktif";
            this.myToogleSwitch1.Size = new System.Drawing.Size(97, 24);
            this.myToogleSwitch1.StatusBarAciklama = "Kartın Kullanım Durmunu Seçiniz.";
            this.myToogleSwitch1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 515);
            this.Controls.Add(this.myToogleSwitch1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.myToogleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyToogleSwitch myToogleSwitch1;
    }
}