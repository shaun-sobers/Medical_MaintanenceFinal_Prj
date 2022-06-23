<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignPerscriptionForm.aspx.cs" Inherits="MedicalManagement_Final.AssignPerscriptionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 120px;
        }
        .auto-style3 {
            width: 613px;
        }
    </style>
            <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table table-dark">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Patient"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPatientName" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddlPatientList" runat="server" Visible="False">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Perscription:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPerscription" runat="server"></asp:TextBox>
                    </td>
                    <td>List of Allergies<asp:GridView ID="gvListOfAllergies" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Length"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtLength" runat="server" TextMode="Number" Width="79px"></asp:TextBox>
&nbsp;(Days)</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Perscription Date"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" Text="Assign Perscription" />
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
