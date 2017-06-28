using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public class Phone
{
    int cid;
    string type;
    string number;

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

    public string Number
    {
        get
        {
            return number;
        }

        set
        {
            number = value;
        }
    }

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

    public Phone(int cid, string type, string number)
    {
        Cid = cid;
        Type = type;
        Number = number;
    }
}