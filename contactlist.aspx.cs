using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class contactlist : System.Web.UI.Page
{
    string connectionString = "Data Source=localhost;Initial Catalog=Mars;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if(Page.Request["action"] != null)
        {
            if(Page.Request["action"] == "delete")
            {
                string ids = Page.Request["ids"];

                string[] toDelete = ids.Split(';');

                Controller.DeleteMarsian(toDelete);
            }
            else if (Page.Request["action"] == "edit")
            {
                string ids = Page.Request["ids"];

                string[] toUpdate = ids.Split(';');

                Controller.UpdateMarsian(toUpdate);
            }
        }



        Controller.UploadFromMarsHeadCRM();


        myMarsLiteral.Text = JsonConvert.SerializeObject(Controller.contactList, Formatting.Indented);
    }

    //public void UploadFromMarsHeadCRM()
    //{
    //    SqlConnection myMarsConnection = new SqlConnection();

    //    myMarsConnection.ConnectionString = connectionString;

    //    try
    //    {
    //        myMarsConnection.Open();


    //        SqlCommand myMarsCommand = new SqlCommand();
    //        myMarsCommand.Connection = myMarsConnection;

    //        myMarsCommand.CommandText = "select * from headCRM";

    //        SqlDataReader myMarsReader = myMarsCommand.ExecuteReader();

    //        Controller.contactList.Clear();

    //        while (myMarsReader.Read())
    //        {
    //            int id = Convert.ToInt32(myMarsReader["ID"].ToString());
    //            string firstName = myMarsReader["Firstname"].ToString();
    //            string lastName = myMarsReader["Lastname"].ToString();
    //            string ssn = myMarsReader["SSN"].ToString();
    //            string email = myMarsReader["Email"].ToString();

    //            Controller.contactList.Add(new Person(id, firstName, lastName, ssn, email));
    //            UploadFromMarsAddress(id);
    //            UploadFromMarsPhone(id);
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        //Console.WriteLine(ex.Message);
    //    }

    //    finally
    //    {
    //        myMarsConnection.Close();
    //    }

    //}


    //private void UploadFromMarsAddress(int id)
    //{
    //    {
    //        SqlConnection myMarsConnection = new SqlConnection();

    //        myMarsConnection.ConnectionString = connectionString;


    //        try
    //        {
    //            myMarsConnection.Open();


    //            SqlCommand myMarsCommand = new SqlCommand();
    //            myMarsCommand.Connection = myMarsConnection;

    //            myMarsCommand.CommandText = "select * from addressCRM where CID = "+id.ToString();

    //            SqlDataReader myMarsReader = myMarsCommand.ExecuteReader();

    //            while (myMarsReader.Read())
    //            {
    //                int cid = Convert.ToInt32(myMarsReader["CID"].ToString());
    //                string type = myMarsReader["Type"].ToString();
    //                string street = myMarsReader["Street"].ToString();
    //                string zip = myMarsReader["Zip"].ToString();
    //                string city = myMarsReader["City"].ToString();

    //                Controller.contactList[Controller.contactList.Count - 1].addressList.Add(new Address(cid, type, street, zip, city));


    //            }


    //        }
    //        catch (Exception ex)
    //        {

    //        }

    //        finally
    //        {
    //            myMarsConnection.Close();
    //        }

    //    }
    //}

    
    //private void UploadFromMarsPhone(int id)
    //{
    //    {
    //        SqlConnection myMarsConnection = new SqlConnection();

    //        myMarsConnection.ConnectionString = connectionString;


    //        try
    //        {
    //            myMarsConnection.Open();


    //            SqlCommand myMarsCommand = new SqlCommand();
    //            myMarsCommand.Connection = myMarsConnection;

    //            myMarsCommand.CommandText = "select * from phoneCRM where CID = " + id.ToString();

    //            SqlDataReader myMarsReader = myMarsCommand.ExecuteReader();

    //            while (myMarsReader.Read())
    //            {
    //                int cid = Convert.ToInt32(myMarsReader["CID"].ToString());
    //                string type = myMarsReader["Type"].ToString();
    //                string number = myMarsReader["Number"].ToString();

    //                Controller.contactList[Controller.contactList.Count - 1].phoneList.Add(new Phone(cid, type, number));


    //            }


    //        }
    //        catch (Exception ex)
    //        {

    //        }

    //        finally
    //        {
    //            myMarsConnection.Close();
    //        }

    //    }
    //}



}