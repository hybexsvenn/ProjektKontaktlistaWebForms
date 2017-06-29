using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.SqlClient;

public class Controller
{
    static string connectionString = "Data Source=localhost;Initial Catalog=Mars;Integrated Security=True";

    public static List<Person> contactList = new List<Person>();



    public static void UploadFromMarsHeadCRM()
    {
        SqlConnection myMarsConnection = new SqlConnection();

        myMarsConnection.ConnectionString = connectionString;

        try
        {
            myMarsConnection.Open();


            SqlCommand myMarsCommand = new SqlCommand();
            myMarsCommand.Connection = myMarsConnection;

            myMarsCommand.CommandText = "select * from headCRM";

            SqlDataReader myMarsReader = myMarsCommand.ExecuteReader();

            contactList.Clear();

            while (myMarsReader.Read())
            {
                int id = Convert.ToInt32(myMarsReader["ID"].ToString());
                string firstName = myMarsReader["Firstname"].ToString();
                string lastName = myMarsReader["Lastname"].ToString();
                string ssn = myMarsReader["SSN"].ToString();
                string email = myMarsReader["Email"].ToString();

                contactList.Add(new Person(id, firstName, lastName, ssn, email));
                UploadFromMarsAddress(id);
                UploadFromMarsPhone(id);
            }


        }
        //catch (Exception)
        //{

        //}

        finally
        {
            myMarsConnection.Close();
        }

    }


    static void UploadFromMarsAddress(int id)
    {
        {
            SqlConnection myMarsConnection = new SqlConnection();

            myMarsConnection.ConnectionString = connectionString;


            try
            {
                myMarsConnection.Open();


                SqlCommand myMarsCommand = new SqlCommand();
                myMarsCommand.Connection = myMarsConnection;

                myMarsCommand.CommandText = "select * from addressCRM where CID = " + id.ToString();

                SqlDataReader myMarsReader = myMarsCommand.ExecuteReader();

                while (myMarsReader.Read())
                {
                    int cid = Convert.ToInt32(myMarsReader["CID"].ToString());
                    string type = myMarsReader["Type"].ToString();
                    string street = myMarsReader["Street"].ToString();
                    string zip = myMarsReader["Zip"].ToString();
                    string city = myMarsReader["City"].ToString();

                    contactList[Controller.contactList.Count - 1].addressList.Add(new Address(cid, type, street, zip, city));


                }


            }
            //catch (Exception ex)
            //{

            //}

            finally
            {
                myMarsConnection.Close();
            }

        }
    }


    static void UploadFromMarsPhone(int id)
    {
        {
            SqlConnection myMarsConnection = new SqlConnection();

            myMarsConnection.ConnectionString = connectionString;


            try
            {
                myMarsConnection.Open();

                SqlCommand myMarsCommand = new SqlCommand();
                myMarsCommand.Connection = myMarsConnection;

                myMarsCommand.CommandText = "select * from phoneCRM where CID = " + id.ToString();

                SqlDataReader myMarsReader = myMarsCommand.ExecuteReader();

                while (myMarsReader.Read())
                {
                    int cid = Convert.ToInt32(myMarsReader["CID"].ToString());
                    string type = myMarsReader["Type"].ToString();
                    string number = myMarsReader["Number"].ToString();

                    contactList[contactList.Count - 1].phoneList.Add(new Phone(cid, type, number));
                }
            }
            //catch (Exception ex)
            //{

            //}

            finally
            {
                myMarsConnection.Close();
            }

        }
    }

    public static void DeleteMarsian(string[] contactsDelete)
    {
        SqlConnection myMarsConnection = new SqlConnection();

        myMarsConnection.ConnectionString = connectionString;

        try
        {
            myMarsConnection.Open();


            SqlCommand myMarsCommand = new SqlCommand();
            myMarsCommand.Connection = myMarsConnection;

            for (int i = 0; i < contactsDelete.Length - 1; i++)
            {
                myMarsCommand.CommandText = "delete from headCRM where headCRM.SSN = " + contactsDelete[i];

                int rowaffected = myMarsCommand.ExecuteNonQuery();
            }

        }
        //catch (Exception)
        //{

        //}

        finally
        {
            myMarsConnection.Close();
        }
    }

    public static void UpdateMarsian(string[] contactsUpdate)
    {
        SqlConnection myMarsConnection = new SqlConnection();

        myMarsConnection.ConnectionString = connectionString;

        try
        {
            myMarsConnection.Open();


            SqlCommand myMarsCommand = new SqlCommand();
            myMarsCommand.Connection = myMarsConnection;

            myMarsCommand.CommandText = "update headCRM set Firstname = '" + contactsUpdate[0]+"', Lastname = '"+contactsUpdate[1]+"', SSN = '"+contactsUpdate[2]+"', Email = '"+contactsUpdate[3]+"'  where SSN =" + contactsUpdate[4];

            int rowaffected = myMarsCommand.ExecuteNonQuery();


        }
        //catch (Exception)
        //{

        //}

        finally
        {
            myMarsConnection.Close();
        }
    }

}
