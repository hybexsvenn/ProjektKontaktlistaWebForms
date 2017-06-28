using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

public class Person
{
    #region Fields
    string firstName;
    string lastName;
    string ssn;
    string email;
    int id;
    public List<Address> addressList = new List<Address>();
    public List<Phone> phoneList = new List<Phone>();
    #endregion
    #region Properties

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            //TODO: Man ska inte kunna röra värdet på ID
            id = value;
        }
    }

    public string FirstName
    {
        get
        {
            return firstName;
        }

        set
        {
            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;   
        }

        set
        {
            lastName = value;
        }
    }

    public string SSN
    {
        get
        {
            return ssn;
        }

        set
        {
            ssn = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    //public List<Address> AddressList
    //{
    //    get
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    set
    //    {
    //    }
    //}

    //public List<Phone> PhoneList
    //{
    //    get
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    set
    //    {
    //    }
    //}

    #endregion

    #region Constructor
    public Person(int id, string firstName, string lastName, string ssn, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        SSN = ssn;
        Email = email;
        Id = id;
    }


    #endregion

    public void AddAddress(Address address)
    {
        addressList.Add(address);
    }
}