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
        bool ssnIsValid = CheckSSNValidation();
        bool ssnIsUnique = CheckIfSSNIsUnique();

        if (ssnIsValid && ssnIsUnique)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                myCommand.Connection = myConnection;

                myCommand.CommandText = "insert into headCRM (Firstname, Lastname, SSN, Email) values ('" + firstname.Text + "', '" + lastname.Text + "', '" + ssn.Text + "', '" + email.Text + "')";

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
        else
        {
            lblSSNNotValid.Text = "Invalid SSN";
            lblSSNNotValid.Visible = true;

        }


    }

    private bool CheckIfSSNIsUnique()
    {
        bool isUnique = true;

        SqlConnection myMarsConnection = new SqlConnection();

        myMarsConnection.ConnectionString = connectionString;

        try
        {
            myMarsConnection.Open();
            
            SqlCommand myMarsCommand = new SqlCommand();
            myMarsCommand.Connection = myMarsConnection;

            myMarsCommand.CommandText = "select SSN from headCRM";

            SqlDataReader myMarsReader = myMarsCommand.ExecuteReader();

            

            while (myMarsReader.Read())
            {
                
                if (myMarsReader["SSN"].ToString() == ssn.Text)
                {
                    isUnique = false;
                    break;
                }

            }


        }
        //catch (Exception)
        //{

        //}

        finally
        {
            myMarsConnection.Close();
        }
        

        return isUnique;
    }

    private bool CheckSSNValidation()
    {
        bool isValid = false;

        if (IsNumeric(ssn.Text))
        {
            if (ssn.Text.Length == 6)
            {
                isValid = true;
            }
        }

        return isValid;
    }

    private bool IsNumeric(string inputString)
    {
        bool isNumeric = true;

        for (int i = 0; i < inputString.Length; i++)
        {
            if (Char.IsDigit(inputString[i]) != true)
            {
                isNumeric = false;
                break;
            }
        }

        return isNumeric;
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



    protected void ssn_TextChanged(object sender, EventArgs e)
    {
        lblSSNNotValid.Visible = false;
    }
}