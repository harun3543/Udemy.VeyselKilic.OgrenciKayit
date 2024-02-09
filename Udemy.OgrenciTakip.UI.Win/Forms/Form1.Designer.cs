
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
            this.mySimpleButton1 = new Udemy.OgrenciTakip.UI.Win.UserControls.Controls.MySimpleButton();
            this.SuspendLayout();
            // 
            // mySimpleButton1
            // 
            this.mySimpleButton1.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.mySimpleButton1.Appearance.Options.UseForeColor = true;
            this.mySimpleButton1.Location = new System.Drawing.Point(21, 28);
            this.mySimpleButton1.Name = "mySimpleButton1";
            this.mySimpleButton1.Size = new System.Drawing.Size(192, 56);
            this.mySimpleButton1.StatusBarAciklama = null;
            this.mySimpleButton1.TabIndex = 0;
            this.mySimpleButton1.Text = "mySimpleButton1";
            this.mySimpleButton1.Click += new System.EventHandler(this.mySimpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 515);
            this.Controls.Add(this.mySimpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Controls.MySimpleButton mySimpleButton1;
    }
}