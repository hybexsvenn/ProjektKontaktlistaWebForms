<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createMarsian1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 161px;
            text-align: right;
        }
        .auto-style3 {
            width: 199px;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            width: 161px;
            text-align: right;
            height: 29px;
        }
        .auto-style6 {
            width: 199px;
            height: 29px;
        }
        .auto-style7 {
            text-align: left;
            height: 29px;
        }
        .auto-style8 {
            width: 90px;
        }
        .auto-style9 {
            width: 161px;
            text-align: right;
            height: 48px;
        }
        .auto-style10 {
            width: 199px;
            height: 48px;
        }
        .auto-style11 {
            text-align: left;
            height: 48px;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">Firstname:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="firstname" runat="server" Width="189px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="firstname" ErrorMessage="Firstname is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Lastname:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="lastname" runat="server" Width="189px"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lastname" ErrorMessage="Lastname is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">SSN:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="ssn" runat="server" Width="189px"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ssn" ErrorMessage="SSN is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Email:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="email" runat="server" TextMode="Password" Width="189px"></asp:TextBox>
                </td>
                <td class="auto-style11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="email" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <%--<asp:Button ID="Button1" runat="server" Height="29px" OnClick="Button1_Click" Text="Submit" Width="90px" />--%>
                    <input id="Reset1" class="auto-style8" type="reset" value="Reset" /></td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
