﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EntityForm_GUI3
{
    public partial class Form1 : Form
    {
        static EMPEntities db = new EMPEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            db.COMPANY.Load();
            bindingSource1.DataSource = db.COMPANY.Local.ToBindingList();

            dataGridView1.DataSource = bindingSource1;
        }

        private void BindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex) {
                MessageBox.Show("Addition / Modification a ete rejetee." + "\n" + ex.Message);
                db.Dispose();
                db = new EMPEntities();
                db.COMPANY.Load();
                bindingSource1.DataSource = db.COMPANY.Local.ToBindingList();
                dataGridView1.Refresh();
            }
        }
    }
}
