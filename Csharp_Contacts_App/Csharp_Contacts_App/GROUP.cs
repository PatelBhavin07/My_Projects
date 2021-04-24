using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Csharp_Contacts_App
{
    class GROUP
    {

        MY_DB mydb = new MY_DB();
        // global variables that'll be used throughout the page
        SqlDataAdapter adapter;
        DataTable table;
        SqlCommand command;


        // function to insert a new group for a specific user
        public bool insertGroup(string gname, int userid)
        {
            command = new SqlCommand("insert into [mygroups](name, userid) VALUES (@gn, @uid)", mydb.getConnection);

            command.Parameters.Add("@gn", SqlDbType.VarChar).Value = gname;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

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



        // function to update the selected group
        public bool updateGroup(int gid, string gname)
        {
            command = new SqlCommand("update [mygroups] set name= @name where id = @id", mydb.getConnection);
            
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = gname;
            command.Parameters.Add("@id", SqlDbType.Int).Value = gid;

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


        // function to delete the selected group
        public bool deleteGroup(int groupid)
        {
            command = new SqlCommand("delete from [mygroups] where id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = groupid;

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


        // function to get contact groups for a specific user
        public DataTable getGroups( int userid )
        {
            command = new SqlCommand("select * from [mygroups] where userid = @uid", mydb.getConnection);
           
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Connection = mydb.getConnection;
            
            adapter = new SqlDataAdapter(command);
            
            table = new DataTable();
            
            adapter.Fill(table);
            
            return table;
        }



        // function to check if the group name already exists ( for the logged user )
        public bool groupExist(string name, string operation, int userid = 0, int groupid = 0)
        {
            string query = "";

            command = new SqlCommand();

            if (operation == "add") // when inserting a new group
            {
                // if the new group name already exists
                query = "select * from [mygroups] where name = @name and userid = @uid";
                
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            }
            else if (operation == "edit") // when editing a group name
            {
                // we will check if the enter an existing group name
                query = "select * from [mygroups] where name = @name AND userid = @uid and id <> @gid";

                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            }

            command.Connection = mydb.getConnection;
            command.CommandText = query;
            
            adapter = new SqlDataAdapter();
            table = new DataTable();

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
