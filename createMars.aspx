<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createMars.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="myScript.js"></script>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
            height: 248px;
        }

        .auto-style2 {
            width: 162px;
        }

        .auto-style3 {
            width: 162px;
            text-align: right;
        }

        .auto-style4 {
            width: 185px;
        }

        .auto-style5 {
            width: 856px;
        }

        .auto-style6 {
            width: 162px;
            text-align: right;
            height: 29px;
        }

        .auto-style7 {
            width: 185px;
            height: 29px;
        }

        .auto-style8 {
            width: 856px;
            height: 29px;
        }

        .auto-style9 {
            width: 636px;
            height: 252px;
        }

        .auto-style10 {
            width: 100%;
        }

        .auto-style11 {
            height: 26px;
        }

        .auto-style12 {
            width: 108px;
            text-align: right;
        }

        .auto-style13 {
            height: 26px;
            width: 108px;
            text-align: right;
        }

        .auto-style14 {
            height: 25px;
            width: 108px;
            text-align: right;
        }

        .auto-style15 {
            height: 25px;
        }
    </style>
</head>
<body>
    <div id="wrapper">
        <div id="header" class="page-header" style="text-align: center;">
            <div class="btn-group-xs">
                <input type="button" class="btn-group btn-info" value="Create" onclick="window.location.href = 'createMars.aspx'" />
                <input type="button" class="btn-group btn-info" value="Read" onclick="window.location.href = 'index.html'" />
                <input type="button" class="btn-group btn-info" value="Update" onclick="UpdateMarsian();" />
                <input type="button" class="btn-group btn-info" value="Delete" onclick="DeleteMarsian();" />
            </div>
        </div>
        <div class="container" style="margin-left:auto;margin-right:auto;">
            <form id="form1" runat="server">
                <div class="auto-style9" style="margin-left:auto;margin-right:auto;">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style6">Firstname:</td>
                            <td class="auto-style7">
                                <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style8">
                                <asp:RequiredFieldValidator ID="firstname_fail" runat="server" ControlToValidate="firstname" ErrorMessage="Firstname required" ForeColor="Red" ValidationGroup="a1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Lastname:</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style5">
                                <asp:RequiredFieldValidator ID="lastname_fail" runat="server" ControlToValidate="lastname" ErrorMessage="Lastname required" ForeColor="Red" ValidationGroup="a1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">SSN:</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="ssn" runat="server" AutoPostBack="True" OnTextChanged="ssn_TextChanged"></asp:TextBox>
                            </td>
                            <td class="auto-style5">
                                <asp:RequiredFieldValidator ID="ssn_fail" runat="server" ControlToValidate="ssn" ErrorMessage="SSN required" ForeColor="Red" ValidationGroup="a1"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblSSNNotValid" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Email:</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="email" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style5">
                                <asp:RequiredFieldValidator ID="email_fail" runat="server" ControlToValidate="email" ErrorMessage="Email required" ForeColor="Red" ValidationGroup="a1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style4">
                                <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" ValidationGroup="a1" />
                            </td>
                            <td class="auto-style5">
                                <asp:Button ID="btn_home" runat="server" Text="Home" OnClick="btn_home_Click1" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                        </tr>
                    </table>
                    <asp:Panel ID="address_panel" runat="server" Visible="False">

                        <table class="auto-style10">
                            <tr>
                                <td class="auto-style12">Type:</td>
                                <td>
                                    <asp:DropDownList ID="type_address" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="164px">
                                        <asp:ListItem>Select address</asp:ListItem>
                                        <asp:ListItem>Home</asp:ListItem>
                                        <asp:ListItem>Work</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="type_address_fail" runat="server" ControlToValidate="type_address" ErrorMessage="Choose address type" ForeColor="Red" InitialValue="Select address" ValidationGroup="a2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">Street:</td>
                                <td>
                                    <asp:TextBox ID="street" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Street required" ForeColor="Red" ControlToValidate="street" ValidationGroup="a2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">Zip:</td>
                                <td class="auto-style11">
                                    <asp:TextBox ID="zip" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style11">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Zip required" ForeColor="Red" ControlToValidate="zip" ValidationGroup="a2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">City:</td>
                                <td>
                                    <asp:TextBox ID="city" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="City required" ForeColor="Red" ControlToValidate="city" ValidationGroup="a2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style11">
                                    <asp:Button ID="add_address" runat="server" OnClick="add_address_Click" Text="Add Address" ValidationGroup="a2" />
                                </td>
                                <td class="auto-style11"></td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style11">&nbsp;</td>
                            </tr>
                        </table>

                        <table class="auto-style10">
                            <tr>
                                <td class="auto-style12">Type:</td>
                                <td>
                                    <asp:DropDownList ID="type_phone" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="164px" ValidationGroup="a3">
                                        <asp:ListItem>Select phone</asp:ListItem>
                                        <asp:ListItem>Home</asp:ListItem>
                                        <asp:ListItem>Work</asp:ListItem>
                                        <asp:ListItem>Mobile</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="type_phone_error" runat="server" ControlToValidate="type_phone" ErrorMessage="Choose phone type" ForeColor="Red" InitialValue="Select phone" ValidationGroup="a3"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">Number:</td>
                                <td>
                                    <asp:TextBox ID="number" runat="server" ValidationGroup="a3"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="number_fail" runat="server" ErrorMessage="Number required" ForeColor="Red" ControlToValidate="number" ValidationGroup="a3"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style14"></td>
                                <td class="auto-style15">
                                    <asp:Button ID="btn_addPhone" runat="server" OnClick="btn_addPhone_Click" Text="Add Phone" ValidationGroup="a3" />
                                </td>
                                <td class="auto-style15">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style12">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style11"></td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style11">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
