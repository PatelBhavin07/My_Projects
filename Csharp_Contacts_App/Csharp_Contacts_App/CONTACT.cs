using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Csharp_Contacts_App
{
    class CONTACT
    {

        MY_DB mydb = new MY_DB();
        // global variables that'll be used throughout the page
        SqlDataAdapter adapter;
        DataTable table;
        SqlCommand command;


        // function to insert a new contact
        public bool insertContact(string fname, string lname, string phone, string address, string email, int userid, int groupid, MemoryStream picture)
        {
            command = new SqlCommand("insert into [mycontact](fname, lname, group_id, phone, email, address, pic, userid) VALUES (@fn, @ln, @grp, @phn, @mail, @adrs, @pic, @uid)", mydb.getConnection);

            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@grp", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }



        // function to update the selected contact
        public bool updateContact(int contactid, string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture)
        {
            command = new SqlCommand("update [mycontact] set fname= @fn, lname= @ln, group_id= @gid, phone= @phn, email= @mail, address= @adrs, pic= @pic where id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = contactid;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

            if ( command.ExecuteNonQuery() == 1 )
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }


        // function to delete the selected contact
        public bool deleteContact(int contactid)
        {
            command = new SqlCommand("delete from [mycontact] where id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = contactid;
            
            mydb.openConnection();
            

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }


        // function to return the contacts list depending on the given command
        public DataTable SelectContactList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }



        public DataTable GetContactById(Int32 contactId)
        {
            command = new SqlCommand("select id, fname, lname, group_id, phone, email,`address, pic, userid from [mycontact] where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }



    }
}
