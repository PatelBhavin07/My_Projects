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
    public partial class Contacts_Full_List_Form : Form
    {
        /// <summary>
        /// method to load Contacts_Full_List_Form showing all contacts as per respected user has added
        /// </summary>
        public Contacts_Full_List_Form()
        {
            InitializeComponent();
        }

        private void Contacts_Full_List_Form_Load(object sender, EventArgs e)
        {
            // display image on the panel ( close and minimize )
            panel4.BackgroundImage = Image.FromFile("../../images/img4.png");
            
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            dataGridView1.RowTemplate.Height = 80;

            CONTACT contact = new CONTACT();
            SqlCommand command = new SqlCommand("select fname as 'First Name', lname as 'Last Name', mygroups.name as 'Group', phone as 'Phone', email as 'E-mail', address as 'Address', pic from [mycontact] inner join mygroups on mycontact.group_id = mygroups.id where mycontact.userid = @userid");
            command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalUserId;
            dataGridView1.DataSource = contact.SelectContactList(command);

            picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            for (int i = 0; i < dataGridView1.Rows.Count; i++) 
            {
                if (IsOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            GROUP group = new GROUP();
            listBox1.DataSource = group.getGroups(Globals.GlobalUserId);
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";

            listBox1.SelectedItem = null;
            dataGridView1.ClearSelection();

        }
        /// <summary>
        /// bool method to check the integer value is Odd
        /// </summary>
        /// <param name="value">looking for odd numbers</param>
        /// <returns>odd numbers</returns>
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (IsOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                CONTACT contact = new CONTACT();
                int groupid = (Int32)listBox1.SelectedValue;
                SqlCommand command = new SqlCommand("select fname as 'First Name', lname as 'Last Name', mygroups.name as 'Group', phone, email, address, pic from [mycontact] inner join [mygroups] on mycontact.group_id = mygroups.id where mycontact.userid = @userid and mycontact.group_id = @groupid");
                command.Parameters.Add("@groupid", SqlDbType.Int).Value = groupid;
                command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalUserId;
                dataGridView1.DataSource = contact.SelectContactList(command);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (IsOdd(i))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            catch (Exception)
            {
               
            }
            
            dataGridView1.ClearSelection();
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


        // show full contact's address on datagridview click
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxAddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }catch(Exception)
            {
                // if the datagridview is empty
            }
            
        }

        private void labelShowAll_Click(object sender, EventArgs e)
        {
            Contacts_Full_List_Form_Load(null, null);
        }

    }
}
