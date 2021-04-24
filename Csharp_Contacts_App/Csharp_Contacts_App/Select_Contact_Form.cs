using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Contacts_App
{
    public partial class Select_Contact_Form : Form
    {
        /// <summary>
        /// method to load Select_Contact_Form with contacts(in datagrid) saved by that logged in user
        /// Methods include minimize and close
        /// </summary>
        public Select_Contact_Form()
        {
            InitializeComponent();
        }

        private void Select_Contact_Form_Load(object sender, EventArgs e)
        {
            // display image on the panel ( close and minimize )
            panel4.BackgroundImage = Image.FromFile("../../images/img4.png");
            
            CONTACT contact = new CONTACT();
            SqlCommand command = new SqlCommand("select id, fname as 'first name', lname as 'last name', group_id as 'group id' from [mycontact] where userid = @uid");
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserId;
            dataGridView1.DataSource = contact.SelectContactList(command);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }


        // button minimize
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        // button close
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
