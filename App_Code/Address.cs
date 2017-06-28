using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public class Address
{
    int cid;
    string type;
    string street;
    string zip;
    string city;

    public int Cid
    {
        get
        {
            return cid;
        }
        set
        {
            cid = value;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public string Street
    {
        get
        {
            return street;
        }

        set
        {
            street = value;
        }
    }

    public string Zip
    {
        get
        {
            return zip;
        }

        set
        {
            zip = value;
        }
    }

    public string City
    {
        get
        {
            return city;
        }

        set
        {
            city = value;
        }
    }

    public Address(int cid, string type, string street, string zip, string city)
    {
        Cid = cid;
        Type = type;
        Street = street;
        Zip = zip;
        City = city;
    }
}