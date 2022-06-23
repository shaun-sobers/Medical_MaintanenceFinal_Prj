﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxMsgForm.aspx.cs" Inherits="MedicalManagement_Final.InboxMsgForm" %>


<!DOCTYPE html>

    <style type="text/css">
body {
  background-color: #d1f3e7;
}

#title-Tag-Line {
  font-size: 20px;
}
/* .card-item__bg{
  width: 150px;
  margin-left: auto;
  margin-right: auto;
  left: 0;
  right: 0;
  display: block;
  position: relative;
  margin: 30px auto;
  transform: translate(0px, 50px);
  z-index: 5;
} */

/* form animation starts */
.form {
  background: #fff;
  box-shadow: 0 30px 60px 0 rgba(90, 116, 148, 0.4);
  border-radius: 5px;
  max-width: 480px;
  margin-left: auto;
  margin-right: auto;
  padding-top: 5px;
  padding-bottom: 5px;
  left: 0;
  right: 0;
  position: absolute;
  border-top: 5px solid #0e3721;
/*   z-index: 1; */
  animation: bounce 1.5s infinite;
}
::-webkit-input-placeholder {
  font-size: 1.3em;
}

.title{
  display: block;
  font-family: sans-serif;
  margin: 10px auto 5px;
  width: 300px;
}
.termsConditions{
  margin: 0 auto 5px 80px;
}

.pageTitle{
  font-size: 2em;
  font-weight: bold;
}
.secondaryTitle{
  color: grey;
}

.name {
  background-color: #ebebeb;
  color: white;
}
.name:hover {
  border-bottom: 5px solid #0e3721;
  height: 30px;
  width: 380px;
  transition: ease 0.5s;
}

.email {
  background-color: #ebebeb;
  height: 2em;
}

.email:hover {
  border-bottom: 5px solid #0e3721;
  height: 30px;
  width: 380px;
  transition: ease 0.5s;
}

.message {
  background-color: #ebebeb;
  overflow: hidden;
  height: 10rem;
}

.message:hover {
  border-bottom: 5px solid #0e3721;
  height: 12em;
  width: 380px;
  transition: ease 0.5s;
}

.formEntry {
  display: block;
  margin: 30px auto;
  min-width: 300px;
  padding: 10px;
  border-radius: 2px;
  border: none;
  transition: all 0.5s ease 0s;
}

.submit {
  width: 200px;
  color: white;
  background-color: #0e3721;
  font-size: 20px;
}

.submit:hover {
  box-shadow: 15px 15px 15px 5px rgba(78, 72, 77, 0.219);
  transform: translateY(-3px);
  width: 300px;
  border-top: 5px solid #0e3750;
  border-radius: 0%;
}

@keyframes bounce {
  0% {
    tranform: translate(0, 4px);
  }
  50% {
    transform: translate(0, 8px);
  }
} 


    </style>
    <script>

    </script>
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
  <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
  <link rel="stylesheet" href="../main.css"/>

</head>

<body>
  <div class="wrapper">
    <form class="form" runat="server">
      <div class="pageTitle title">Send Email </div>
      <div class="secondaryTitle title">Please fill this form to Send A Message.</div>
        <label for="tbFrom" class="name formEntry">From User</label>
        <asp:TextBox ID="tbFrom" runat="server" ReadOnly="True" CssClass="name formEntry" placeholder="From User"></asp:TextBox>

         <label for="tbTo" class="name formEntry">To User</label>
         <asp:DropDownList ID="ddlSentList" runat="server" CssClass="name formEntry"> </asp:DropDownList>


       <asp:TextBox ID="tbTo" runat="server" ReadOnly="True" CssClass="message formEntry"></asp:TextBox>


         <asp:TextBox ID="tbDate" runat="server" ReadOnly="True" CssClass="name formEntry"></asp:TextBox>

         <label for="tbSubject" class="name formEntry">Subject</label>
        <asp:TextBox ID="tbSubject" runat="server" ReadOnly="True" CssClass="name formEntry"></asp:TextBox>



                <asp:TextBox TextMode="MultiLine" CssClass="message formEntry" placeholder="Message" runat="server" ID="tbMessage" ></asp:TextBox>

         <asp:Button CssClass="submit formEntry" ID="btnReply" runat="server" OnClick="btnReply_Click" Text="Reply" />

                    <asp:Button CssClass="submit formEntry" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />


   <asp:TextBox TextMode="MultiLine" ID="tbReply" runat="server" CssClass="message formEntry"></asp:TextBox>

         <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="submit formEntry" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="submit formEntry" OnClick="btnCancel_Click" />


    </form>
  </div>
  <script src="app.js"></script>
</body>

</html>

