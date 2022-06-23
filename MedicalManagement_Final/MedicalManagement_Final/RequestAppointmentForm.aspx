<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestAppointmentForm.aspx.cs" Inherits="MedicalManagement_Final.RequestAppointmentForm" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
body {
    background-color: #444442;
    padding-top: 85px;
}

h1 {
    font-family: 'Poppins', sans-serif, 'arial';
    font-weight: 600;
    font-size: 72px;
    color: white;
    text-align: center;
}

h4 {
    font-family: 'Roboto', sans-serif, 'arial';
    font-weight: 400;
    font-size: 20px;
    color: #9b9b9b;
    line-height: 1.5;
}


input:focus ~ label, textarea:focus ~ label, input:valid ~ label, textarea:valid ~ label {
    font-size: 0.75em;
    color: #999;
    top: -5px;
    -webkit-transition: all 0.225s ease;
    transition: all 0.225s ease;
}

.styled-input {
    float: left;
    width: 293px;
    margin: 1rem 0;
    position: relative;
    border-radius: 4px;
}

@media only screen and (max-width: 768px){
    .styled-input {
        width:100%;
    }
}

.styled-input label {
    color: #999;
    padding: 1.3rem 30px 1rem 30px;
    position: absolute;
    top: 10px;
    left: 0;
    -webkit-transition: all 0.25s ease;
    transition: all 0.25s ease;
    pointer-events: none;
}

.styled-input.wide { 
    width: 650px;
    max-width: 100%;
}

input,
textarea {
    padding: 30px;
    border: 0;
    width: 100%;
    font-size: 1rem;
    background-color: #2d2d2d;
    color: white;
    border-radius: 4px;
}

input:focus,
textarea:focus { outline: 0; }

input:focus ~ span,
textarea:focus ~ span {
    width: 100%;
    -webkit-transition: all 0.075s ease;
    transition: all 0.075s ease;
}

textarea {
    width: 100%;
    min-height: 15em;
}

.input-container {
    width: 650px;
    max-width: 100%;
    margin: 20px auto 25px auto;
}

.submit-btn {
    float: right;
    padding: 7px 35px;
    border-radius: 60px;
    display: inline-block;
    background-color: #4b8cfb;
    color: white;
    font-size: 18px;
    cursor: pointer;
    box-shadow: 0 2px 5px 0 rgba(0,0,0,0.06),
              0 2px 10px 0 rgba(0,0,0,0.07);
    -webkit-transition: all 300ms ease;
    transition: all 300ms ease;
}

.submit-btn:hover {
    transform: translateY(1px);
    box-shadow: 0 1px 1px 0 rgba(0,0,0,0.10),
              0 1px 1px 0 rgba(0,0,0,0.09);
}

@media (max-width: 768px) {
    .submit-btn {
        width:100%;
        float: none;
        text-align:center;
    }
}

input[type=checkbox] + label {
  color: #ccc;
  font-style: italic;
} 

input[type=checkbox]:checked + label {
  color: #f00;
  font-style: normal;
}

        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 26px;
            width: 195px;
        }
        .auto-style3 {
            width: 264px;
        }
        .auto-style4 {
            height: 26px;
            width: 264px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            	<div class="row">
			<h1>Appointment Request</h1>
	    </div>
	    <div class="row">
			<h4 style="text-align:center">Please enter your information and a doctor will get back to you</h4>
	    </div>
           	<div class="row input-container">
			<div class="col-xs-12">
				<div class="styled-input wide">
                    <asp:Label Text="Type of appointment" runat="server" CssClass="styled-input wide"></asp:Label>
                        <asp:DropDownList ID="ddlAppointment" runat="server" CssClass="styled-input wide">
                        </asp:DropDownList>

                    
                   <asp:Label Text="Severity" runat="server" CssClass="styled-input wide"></asp:Label>
                    <asp:DropDownList ID="ddlSeverity" runat="server" CssClass="styled-input wide"></asp:DropDownList>

                     <asp:Label Text="Doctors Name" runat="server" CssClass="styled-input wide"></asp:Label>
                     <asp:DropDownList ID="ddlDrsNames" runat="server" CssClass="styled-input wide"></asp:DropDownList>
				</div>
			</div>
			<div class="col-md-6 col-sm-12">
				<div class="styled-input">
                    <asp:TextBox ID="txtReasonfor" runat="server" placeholder="Reason For Consultation" CssClass="styled-input wide"></asp:TextBox>

                 <asp:TextBox ID="txtExtraInfo" runat="server" placeholder="Extra Information..." CssClass="styled-input wide"></asp:TextBox>
                </div>
			</div>
			</div>
            <div>
                        <asp:Button ID="btnSendRequest" runat="server" OnClick="btnSendRequest_Click" Text="Send Request" CssClass="btn btn-outline-secondary" />
                <br />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline-secondary" OnClick="btnClear_Click" />
                <br />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-outline-secondary" />
                </div>
        </div>
    </form>
</body>
</html>
