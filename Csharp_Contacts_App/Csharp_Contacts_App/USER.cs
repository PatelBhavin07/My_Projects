using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Contacts_App
{
    class USER
    {

        MY_DB db = new MY_DB();

        SqlDataAdapter adapter;
        DataTable table;
        SqlCommand command;

        public DataTable getUserById(Int32 userid)
        {
            
            adapter = new SqlDataAdapter();

            table = new DataTable();

            command = new SqlCommand("select * from [user] where id = @uid", db.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            return table;
        }


        // function to insert a new user
        public bool insertUser(string fname, string lname, string username, string password, MemoryStream picture)
        {
            command = new SqlCommand("insert into [user](fname, lname, username, pass, pic) VALUES (@fn, @ln, @un, @pass, @pic)", db.getConnection);

            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            db.openConnection();

            if ( command.ExecuteNonQuery() == 1 )
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }


        // function to check if the username already exists
        public bool usernameExist(string username, string operation, int userid = 0)
        {
            string query = "";

            if (operation == "register")
            {
                // if a new user want to register we will check if the username already exists
                query = "select * from [user] where username = @un";
            }
            else if(operation == "edit")
            {
                // if an existing student want to edit his information 
                // we will check if he enter an existing username ( not including his own username )
                query = "select * from [user] where username = @un AND id <> @uid";
            }

            command = new SqlCommand(query, db.getConnection);

            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            adapter = new SqlDataAdapter();
            table = new DataTable();

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        // function to update the logged user data
        public bool updateUser(int userid, string fname, string lname, string username, string password, MemoryStream picture)
        {
            command = new SqlCommand("update [user] set fname= @fn, lname= @ln, username= @un, pass= @pass, pic= @pic where id = @uid", db.getConnection);

            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            db.openConnection();

            if ( command.ExecuteNonQuery() == 1 )
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }


    }
}
