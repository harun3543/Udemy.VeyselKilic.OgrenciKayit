﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udemy.Dal.Base;
using Udemy.OgrenciTakip.Data.Contexts;
using Udemy.OgrenciTakip.Model.Entities;
using Udemy.OgrenciTakip.UI.Win.Forms.BaseForms;
using Udemy.OgrenciTakip.UI.Win.Forms.OkulForms;

namespace Udemy.OgrenciTakip.UI.Win.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();        
        }

        private void mySimpleButton1_Click(object sender, EventArgs e)
        {
            OkulKartlari kartlar = new OkulKartlari();
            kartlar.ShowDialog();
        }
    }
}
