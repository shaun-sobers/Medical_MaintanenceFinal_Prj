<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordForm.aspx.cs" Inherits="MedicalManagement_Final.ForgotPasswordForm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .buttons {
    margin: 8%;
    text-align: center;
}

.btn-hover {
    width: 200px;
    font-size: 15px;
    font-weight: 600;
    color: #fff;
    cursor: pointer;
    margin: 20px;
    height: 55px;
    text-align:center;
    border: none;
    background-size: 200% 100%;

    border-radius: 50px;
    moz-transition: all .4s ease-in-out;
    -o-transition: all .4s ease-in-out;
    -webkit-transition: all .4s ease-in-out;
    transition: all .4s ease-in-out;
}

.btn-hover:hover {
    background-position: 100% 0;
    moz-transition: all .4s ease-in-out;
    -o-transition: all .4s ease-in-out;
    -webkit-transition: all .4s ease-in-out;
    transition: all .4s ease-in-out;
}

.btn-hover:focus {
    outline: none;
}

.btn-hover.color-8 {
    background-image: linear-gradient(to right, #29323c, #485563, #2b5876, #4e4376);
    box-shadow: 0 4px 15px 0 rgba(45, 54, 65, 0.75);
}
        .auto-style4 {
            margin-left: 280px;
        }
        </style>
</head>
<body class="vh-100" style="background-color: #42443f;">
<link href="Content/bootstrap.css" rel="stylesheet" />
  <div class="container">
    <div class="row">
      <div class="col-lg-10 col-xl-9 mx-auto">
        <div class="card flex-row my-5 border-0 shadow rounded-3 overflow-hidden">
          <div class="card-img-left d-none d-md-flex">
          </div>
          <div class="card-body p-4 p-sm-5">
            <h5 class="card-title text-center mb-5 fw-light fs-5">Register</h5>
            <form id="form3" runat="server">

              <div class="form-floating mb-3">


       
                     <asp:TextBox CssClass="form-control form-control-lg" ID="txtUsername" runat="server" ></asp:TextBox>
                <label for="txtUsername">Username</label>

                  <asp:Button ID="btnNext" runat="server" Text="Next Step" CssClass="btn-hover color-8" OnClick="btnNext_Click" />
 
              </div>
              <hr>

              <div class="form-floating mb-3">
                  <asp:TextBox CssClass="form-control form-control-lg" ID="txtSecurityQuestion" runat="server"  placeholder="Security Question" ></asp:TextBox>
              </div>

              <div class="form-floating mb-3">
                       <asp:TextBox CssClass="form-control form-control-lg" ID="txtSecurityAnswer" runat="server"  placeholder ="Security Answer" ></asp:TextBox>
                <asp:Button ID="btnNext2" runat="server" Text="Next Step" CssClass="btn-hover color-8" OnClick="btnNext2_Click"   />
              </div>

            <div class="form-floating mb-3">
                <asp:TextBox CssClass="form-outline mb-4" ID="txtNewPassword" runat="server" placeholder="Enter new Password" TextMode="Password" Width="300" ></asp:TextBox>
              </div>

                
            <div class="form-floating mb-3">
                 <asp:TextBox CssClass="form-outline mb-4" ID="txtRepeatPassword" runat="server" placeholder="Retype New Password" TextMode="Password" Width="300" ></asp:TextBox>
              </div>
          <div class="form-floating mb-3">
                <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn-hover color-8" Visible="false" OnClick="btnResetPassword_Click" />
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</body>

</body>
</html>
