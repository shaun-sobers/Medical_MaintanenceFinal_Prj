<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="MedicalManagement_Final.Inde" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 609px;
        }
        .auto-style3 {
            width: 191px;
        }

        * {
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}

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
    </style>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <section class="vh-100" style="background-color: #42443f;">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col col-xl-10">
        <div class="card" style="border-radius: 1rem;">
          <div class="row g-0">
            <div class="col-md-6 col-lg-5 d-none d-md-block">
              <img src="/Images/homeImage.jpg"
                alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
            </div>
            <div class="col-md-6 col-lg-7 d-flex align-items-center">
              <div class="card-body p-4 p-lg-5 text-black">

                <form id="form1" runat="server">

                  <div class="d-flex align-items-center mb-3 pb-1">
                    <i class="fas fa-cubes fa-2x me-3" style="color: #ff6219;"></i>
                    <span class="h1 fw-bold mb-0">Sobers Health Management</span>
                  </div>

                  <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Sign into your account</h5>

                  <div class="form-outline mb-4">
                     <asp:TextBox CssClass="form-control form-control-lg" ID="txtUsername" runat="server" placeholder="Member ID" ></asp:TextBox>
                    <label class="form-label" for="txtUsername">Email address</label>
                  </div>

                  <div class="form-outline mb-4">
                      <asp:TextBox CssClass="form-control form-control-lg" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" ></asp:TextBox>
                    <label class="form-label" for="txtPassword">Password</label>
                  </div>

                  <div class="pt-1 mb-4">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn-hover color-8" />
                  </div>

                  <a class="small text-muted" href="/ForgotPasswordForm.aspx">Forgot password?</a>
                    <br />
                  <a href="AboutMeForm.aspx" class="small text-muted">About The Creator !</a>
                                           
                  <p class="mb-5 pb-lg-2" style="color: #393f81;">
                      <a style="color: #393f81;">
                     <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register a new Account" CssClass="btn-hover color-8" />
                      </a></p>
                </form>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</body>
</html>
