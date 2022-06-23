<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxForm.aspx.cs" Inherits="MedicalManagement_Final.InboxForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
html,
body {
	height: 100%;
}

body {
	margin: 0;
	background: linear-gradient(45deg, #49a09d, #5f2c82);
	font-family: sans-serif;
	font-weight: 100;
}

.container {
	position: absolute;
	top: 50%;
	left: 50%;
	transform: translate(-50%, -50%);
}

table {
	width: 800px;
	border-collapse: collapse;
	overflow: hidden;
	box-shadow: 0 0 20px rgba(0,0,0,0.1);
}

th,
td {
	padding: 15px;
	background-color: rgba(255,255,255,0.2);
	color: #fff;
}

th {
	text-align: left;
}

thead {
	th {
		background-color: #55608f;
	}
}

tbody {
	tr{
		&:hover {
			background-color: rgba(255,255,255,0.3);
		}
	}
	td {
		position: relative;
		&:hover {
			&:before {
				content: "";
				position: absolute;
				left: 0;
				right: 0;
				top: -9999px;
				bottom: -9999px;
				background-color: rgba(255,255,255,0.2);
				z-index: -1;
			}
		}
	}
}
    </style>
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmailcount" Visible="false" runat="server"></asp:Label>
                    <asp:GridView ID="gvInbox" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource" OnSelectedIndexChanging="gvInbox_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="MessageId" HeaderText="MessageId" SortExpression="MessageId" />
                            <asp:BoundField DataField="MessageText" HeaderText="MessageText" SortExpression="MessageText" />
                            <asp:BoundField DataField="ToUser" HeaderText="ToUser" SortExpression="ToUser" />
                            <asp:BoundField DataField="FromUser" HeaderText="FromUser" SortExpression="FromUser" />
                            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Select" ControlStyle-CssClass="btn btn-outline-primary" />
                            <asp:CheckBoxField HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                    <table class="auto-style1">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnComposeMsg" runat="server" OnClick="btnComposeMsg_Click" Text="Compose New Message" CssClass="btn btn-outline-primary" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReturn" runat="server" OnClick="btnCancel_Click" Text="Return" CssClass="btn btn-outline-primary" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetMessageList" TypeName="MedicalManagement_Final.Database">
                        <SelectParameters>
                            <asp:SessionParameter Name="id" SessionField="userid" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </form>
        </div>
        <div>

</body>
</html>
