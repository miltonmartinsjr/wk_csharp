using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms1
{
    public partial class Form1 : Form
    {
        private EMPEntities db = new EMPEntities();
        private bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            String message = "";
            if (!flag)
            {
                COMPANY company = new COMPANY();
                company.ID = Convert.ToInt32(txtid.Text);
                company.NAME = txtnom.Text;
                company.ADRESS = txtadress.Text;
                company.AGE = Convert.ToInt32(txtage.Text);
                company.SALARY = float.Parse(txtsalaire.Text);
                message = "Company a été bien ajouté.";
                db.COMPANY.Add(company);
            }
            else
            {
                int id = Convert.ToInt32(txtid.Text);
                var result = db.COMPANY.Where(s => s.ID == id).SingleOrDefault();
                result.NAME = txtnom.Text;
                result.ADRESS = txtadress.Text;
                result.SALARY = float.Parse(txtsalaire.Text);
                result.AGE = Convert.ToInt32(txtage.Text);
                message = "Company a été mis à jour.";
            }
            db.SaveChanges();

            MessageBox.Show(message);
        }

        private void Txtid_TextChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (txtid.Text.Length != 0)
            {
                id = Convert.ToInt32(txtid.Text);
            }

            var result = db.COMPANY.Where(s => s.ID == id).SingleOrDefault();
            if(result != null)
            {
                txtnom.Text = result.NAME;
                txtadress.Text = result.ADRESS;
                txtsalaire.Text = result.SALARY.Value.ToString("F2");
                txtage.Text = result.AGE.ToString();
                flag = true;
                txtnom.Focus();
            }
            else
            {
                flag = false;
            }

        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
