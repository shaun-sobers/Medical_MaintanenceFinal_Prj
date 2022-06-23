<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationForm.aspx.cs" Inherits="MedicalManagement_Final.InformationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 422px;
        }
        .auto-style3 {
            width: 384px;
        }
        .auto-style4 {
            width: 422px;
            height: 26px;
        }
        .auto-style5 {
            width: 384px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
        <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-dark">
            <tr>
                <td class="auto-style2">
                    <asp:ImageMap ID="imgProfile" runat="server">
                    </asp:ImageMap>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Name&nbsp;&nbsp;
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Gender:
                    <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Birthday
                    <asp:Label ID="lblBirthday" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="lblAllergyList" runat="server" Text="List Of Allergies"></asp:Label>
                    <asp:GridView ID="gvAllergies" runat="server">
                    </asp:GridView>
                </td>
                <td>
                    <asp:Button ID="btnPerscription" runat="server" OnClick="btnPerscription_Click" Text="Asign Perscription" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="lblAppointmentList" runat="server" Text="Appointment List"></asp:Label>
                    <br />
                    <asp:GridView ID="gvAppointmentHistory" runat="server">
                    </asp:GridView>
                </td>
                <td>
                    <asp:Label ID="lblPerscriptionList" runat="server" Text="Perscription List"></asp:Label>
                    <asp:GridView ID="gvPerscriptionHistory" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnAdmit" runat="server" OnClick="lblAdmit_Click" Text="Admit" />
                    <asp:Button ID="btnDischarge" runat="server" OnClick="btnDischarge_Click" Text="Discharge Patient" Visible="False" />
                    <asp:Button ID="btnSendMessage" runat="server" OnClick="btnSendMessage_Click" Text="Send Message" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblExtraInfo" runat="server" Visible="False">Extra Info</asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lblAddNotes" runat="server" Visible="False">Add Notes</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAddNotes" runat="server" OnClick="btnAddNotes_Click" Text="Add Note" Visible="False" />
                </td>
                <td class="auto-style6">
                    <asp:Label ID="lblNotes" runat="server" Visible="False">Notes</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="txtExtraInfo" runat="server" Height="77px" Visible="False" Width="410px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtAddNote" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:ListBox ID="lbNotes" runat="server" Width="617px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <table class="auto-style1">
                        <tr>
                            <td>&nbsp;<asp:Label ID="lblNurse" runat="server" Text="Nurse" Visible="False"></asp:Label>
&nbsp;
                                <asp:DropDownList ID="ddlNurse" runat="server" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblRoom" runat="server" Text="Room" Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlRoom" runat="server" OnSelectedIndexChanged="ddlRoom_SelectedIndexChanged" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnSaveAdmission" runat="server" OnClick="btnSaveAdmission_Click" Text="Admit To Room" Visible="False" />
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
