using BusinessLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IceCreams
{
    public partial class LoginForm : Form
    {

        byte[] image_data;
      

       public LoginForm()
        {
            InitializeComponent();
        }
    
        private void btnInsertIceCream_Click(object sender, EventArgs e)
        {
            {
                if (lblPicture1.Text != "")
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    image_data = ms.ToArray();
                    ice_creamsClass icecreams = ice_creamsDetails();
                    ice_creamsBusiness.Addice_creamsBusiness(icecreams);
                    MessageBox.Show("New Ice Cream Inserted Successfully! ");
                }
                else
                    MessageBox.Show("Please Select Picture first ");
            }
            ice_creamsClass ice_Creams = new ice_creamsClass()
            {
                id = icecreamID.Text,
                company = icecreamCompany.Text,
                type = icecreamType.Text,
                size = icecreamSize.Text,
                price = icecreamPrice.Text,
                flavour = icecreamFlavour.Text,
                color = icecreamColor.Text,
                expiredate = icecreamExpireDate.Text,
            };


            ice_creamsBusiness.Addice_creamsBusiness(ice_Creams);
            MessageBox.Show("New Ice Cream Inserted Successfully ");
        }

        public void btnShowAllIceCream_Click(object sender, EventArgs e)
        {
            icecreamDataGridView.DataSource = ice_creamsBusiness.SelectAllice_creamsBusiness();
        }

        private void icecreamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            icecreamID.Text = icecreamDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            icecreamCompany.Text = icecreamDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            icecreamType.Text = icecreamDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            icecreamSize.Text = icecreamDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            icecreamPrice.Text = icecreamDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            icecreamFlavour.Text = icecreamDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            icecreamColor.Text = icecreamDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            icecreamExpireDate.Text = icecreamDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            pictureBox1.Image = Image.FromStream(new MemoryStream((Byte[])icecreamDataGridView.SelectedRows[0].Cells[8].Value));
            icecreamID.ReadOnly = true;
        }

        public void btnUpdateIceCream_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            image_data = ms.ToArray();
            ice_creamsClass ice_Creams = new ice_creamsClass()
            {
                id = icecreamID.Text,
                company = icecreamCompany.Text,
                type = icecreamType.Text,
                size = icecreamSize.Text,
                price = icecreamPrice.Text,
                flavour = icecreamFlavour.Text,
                color = icecreamColor.Text,
                expiredate = icecreamExpireDate.Text,
                picture=image_data
            };


            //  ice_creamsClass ice_Creams = ice_creamsDetails();
            ice_creamsBusiness.Updateice_creamBusiness(ice_Creams);
            //for refresh DataGridView
            icecreamDataGridView.DataSource = null;
            icecreamDataGridView.DataSource = ice_creamsBusiness.SelectAllice_creamsBusiness();
            ResetForm();



        } 

        private void icecreamID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndeleteIceCream_Click(object sender, EventArgs e)
        {
            ice_creamsClass ice_Creams = ice_creamsDetails();
            ice_creamsBusiness.Deleteice_creamsBusiness(ice_Creams);
        }

        private ice_creamsClass ice_creamsDetails()
        {

            ice_creamsClass ice_Creams = new ice_creamsClass()
            {
                id = icecreamID.Text,
                company = icecreamCompany.Text,
                type = icecreamType.Text,
                size = icecreamSize.Text,
                price = icecreamPrice.Text,
                flavour = icecreamFlavour.Text,
                color = icecreamColor.Text,
                expiredate = icecreamExpireDate.Text,
                picture = image_data,
            };
            return ice_Creams;
        }

        private void ResetForm()
        {
            icecreamID.Clear();
            icecreamCompany.Clear();
            icecreamType.Clear();
            icecreamSize.Clear();
            icecreamPrice.Clear();
            icecreamFlavour.Clear();
            icecreamColor.Clear();
            icecreamExpireDate.Clear();
            pictureBox1.Image = null;
            icecreamID.ReadOnly = false;


        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp; *.png;";
            if(open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                lblPicture1.Text = Path.GetFileName(open.FileName);
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms,pictureBox1.Image.RawFormat);
                image_data = ms.ToArray();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
