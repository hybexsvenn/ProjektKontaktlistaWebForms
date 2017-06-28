using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class _Default : System.Web.UI.Page
{
    string connectionString = "Data Source=localhost;Initial Catalog=Mars;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString =  connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "insert into headCRM (Firstname, Lastname, SSN, Email) values ('"+firstname.Text+"', '"+lastname.Text+"', '"+ssn.Text+"', '"+email.Text+"')";

            SqlDataReader myReader = myCommand.ExecuteReader();

        }
        catch (Exception)
        {

        }
        finally
        {
            myConnection.Close();
        }

        Controller.UploadFromMarsHeadCRM();


        //TODO: Javascript för att ta fram div

        address_panel.Visible = true;


    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void add_address_Click(object sender, EventArgs e)
    {
        int cid = 0;
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            
            myCommand.CommandText = string.Format("select * from headCRM where headCRM.SSN='{0}'", ssn.Text);
            SqlDataReader myMarsReader = myCommand.ExecuteReader();

            if (myMarsReader.HasRows)
            {
                myMarsReader.Read();
                cid = Convert.ToInt32(myMarsReader["ID"]);
                myMarsReader.Close();

                myCommand.CommandText = "insert into addressCRM (CID, Type, Street, Zip, City) values (" + cid.ToString() + ", '" + type_address.Text + "', '" + street.Text + "', '" + zip.Text + "', '" + city.Text + "')";

                int rowaffected = myCommand.ExecuteNonQuery();
            }
            else
            {
                myMarsReader.Close();
            }


        }
        //catch (Exception)
        //{

        //}
        finally
        {
            myConnection.Close();
        }

        Controller.UploadFromMarsHeadCRM();
    }

    protected void btn_addPhone_Click(object sender, EventArgs e)
    {
        int cid = 0;
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;


            myCommand.CommandText = string.Format("select * from headCRM where headCRM.SSN='{0}'", ssn.Text);
            SqlDataReader myMarsReader = myCommand.ExecuteReader();

            if (myMarsReader.HasRows)
            {
                myMarsReader.Read();
                cid = Convert.ToInt32(myMarsReader["ID"]);
                myMarsReader.Close();

                myCommand.CommandText = "insert into phoneCRM (CID, Type, Number) values (" + cid.ToString() + ", '" + type_phone.Text + "', '" + number.Text + "')";

                int rowaffected = myCommand.ExecuteNonQuery();
            }
            else
            {
                myMarsReader.Close();
            }


        }
        //catch (Exception)
        //{

        //}
        finally
        {
            myConnection.Close();
        }

        Controller.UploadFromMarsHeadCRM();
    }

    protected void btn_home_Click1(object sender, EventArgs e)
    {
        Server.Transfer("index.html");
    }
}