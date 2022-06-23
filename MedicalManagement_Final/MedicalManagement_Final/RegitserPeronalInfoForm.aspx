    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegitserPeronalInfoForm.aspx.cs" Inherits="MedicalManagement_Final.RegitserPeronalInfo" %>

<!DOCTYPE html>


<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <link href="Content/bootstrap.css" rel="stylesheet" />
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script src="Scripts/jquery-2.1.1.js"></script>
<script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type='text/javascript' src='js/plugins/icheck/icheck.min.js'></script>
    <script type="text/javascript" src="js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>

    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-datepicker.js"></script>                
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-file-input.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-select.js"></script>
    <script type="text/javascript" src="js/plugins/tagsinput/jquery.tagsinput.min.js"></script>

<body>
        <style type="text/css">
            .register{
    background: -webkit-linear-gradient(left, #3931af, #00c6ff);
    margin-top: 3%;
    padding: 3%;
}
.register-left{
    text-align: center;
    color: #fff;
    margin-top: 4%;
}
.register-left input{
    border: none;
    border-radius: 1.5rem;
    padding: 2%;
    width: 60%;
    background: #f8f9fa;
    font-weight: bold;
    color: #383d41;
    margin-top: 30%;
    margin-bottom: 3%;
    cursor: pointer;
}
.register-right{
    background: #f8f9fa;
    border-top-left-radius: 10% 50%;
    border-bottom-left-radius: 10% 50%;
}
.register-left img{
    margin-top: 15%;
    margin-bottom: 5%;
    width: 25%;
    -webkit-animation: mover 2s infinite  alternate;
    animation: mover 1s infinite  alternate;
}
@-webkit-keyframes mover {
    0% { transform: translateY(0); }
    100% { transform: translateY(-20px); }
}
@keyframes mover {
    0% { transform: translateY(0); }
    100% { transform: translateY(-20px); }
}
.register-left p{
    font-weight: lighter;
    padding: 12%;
    margin-top: -9%;
}
.register .register-form{
    padding: 10%;
    margin-top: 10%;
}
.btnRegister{
    float: right;
    margin-top: 10%;
    border: none;
    border-radius: 1.5rem;
    padding: 2%;
    background: #0062cc;
    color: #fff;
    font-weight: 600;
    width: 50%;
    cursor: pointer;
}
.register .nav-tabs{
    margin-top: 3%;
    border: none;
    background: #0062cc;
    border-radius: 1.5rem;
    width: 28%;
    float: right;
}
.register .nav-tabs .nav-link{
    padding: 2%;
    height: 34px;
    font-weight: 600;
    color: #fff;
    border-top-right-radius: 1.5rem;
    border-bottom-right-radius: 1.5rem;
}
.register .nav-tabs .nav-link:hover{
    border: none;
}
.register .nav-tabs .nav-link.active{
    width: 100px;
    color: #0062cc;
    border: 2px solid #0062cc;
    border-top-left-radius: 1.5rem;
    border-bottom-left-radius: 1.5rem;
}
.register-heading{
    text-align: center;
    margin-top: 8%;
    margin-bottom: -15%;
    color: #495057;
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
<!------ Include the above in your HEAD tag ---------->
<div class="container register">
    <form id="form4" runat="server"> 

                <div class="row">
                    <div class="col-md-3 register-left">
                        <img src="https://image.ibb.co/n7oTvU/logo_white.png" alt=""/>
                        <h3>Welcome</h3>
                        <p>Please create an account to enter website</p>
                       <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-hover color-8" OnClick="btnSave_Click" />
                                                            <div class="col-md-6">
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                    </div>
                    </div>
                    <div class="col-md-9 register-right">
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                <h3 class="register-heading">Register Account</h3>
                                <div class="row register-form">
                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:FileUpload ID="FileUpload1" runat="server"/>
                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />

                                            <asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                            <asp:ImageField DataImageUrlField="Value" HeaderText="Image">
                                            </asp:ImageField>
                                            <asp:BoundField DataField="Text" HeaderText="Title" SortExpression="Text" />
                                           </Columns>
                                          </asp:GridView>
                                        </div>

                                        <div class="form-group">
                                               <asp:TextBox ID="txtFname" runat="server" Width="272px" placeholder="First Name *" CssClass="form-control"/>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtLname" runat="server" Width="272px" placeholder="Last Name *" CssClass="form-control"/>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label" for="ddlSex">Gender</label>
                                       <asp:DropDownList ID="ddlSex" runat="server" OnSelectedIndexChange="ddlSex_SelectedIndexChanged" CssClass="form-group" data-toggle="dropdown" AutoPostBack="true">
                    </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label" for="ddlBloodType">Blood Type</label>
                                       <asp:DropDownList ID="ddlBloodType" runat="server" OnSelectedIndexChange="ddlBloodType_SelectedIndexChanged" CssClass="form-group" data-toggle="dropdown" AutoPostBack="true">
                    </asp:DropDownList>
                                        </div>

                                     <div class="form-group">
                                           <asp:Label ID="lblType" runat="server" Text="Type" Visible="False" CssClass="form-group"></asp:Label>
                                       <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChange="ddlType_SelectedIndexChanged" CssClass="form-group" data-toggle="dropdown" AutoPostBack="true" Visible="false">
                    </asp:DropDownList>
                                        </div>
                                        
                                    <div class="form-group">
                                            <asp:TextBox ID="txtPhone" runat="server" Width="272px" placeholder="Phone Number"  CssClass="form-control" MaxLength="10" />
                                        </div>

                                           <div class="form-group">
                                            <asp:DropDownList ID="ddlSecurityQuestion" runat="server" CssClass="form-group" data-toggle="dropdown" AutoPostBack="true">
                    </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                             <asp:TextBox ID="txtSecurityAnswer" runat="server" Width="272px" placeholder="Security Answer*" CssClass="form-control"/>
                                        </div>


                                    <div class="form-group">
                                            <asp:TextBox ID="txtAdminCode" runat="server" Width="272px" OnTextChanged="txtAdminCode_TextChanged" placeholder="Admin Code" CssClass="form-control" TextMode="Password"/>
                                        </div>
                                    </div>
                               <div class="col-md-6">
                                   <div class="form-group">
                                               <asp:TextBox ID="txtEmergName" runat="server" Width="272px" placeholder="Emergency Name" CssClass="form-control"/>
                                   </div>

                                   <div class="form-group">
                                               <asp:TextBox ID="txtEmergNum" runat="server" Width="272px" placeholder="Emergency Number" CssClass="form-control"/>
                                   </div>
                      
                                   
                                        <div class="form-group">
                                            <asp:Label ID="lblBirthday" runat="server" Text="Birthday" CssClass="form-group"></asp:Label>
                                            <asp:TextBox ID="txtBirthday" runat="server" TextMode="Date"></asp:TextBox>
                                        </div>

                                      <div class="form-group">
                                      <asp:TextBox ID="txtAllergies" runat="server" Width="184px"></asp:TextBox>
                                        <asp:Button ID="btnAddAllergy" OnClick="btnAddAllergy_Click" runat="server" Text="Add Allergy" />
                                           <asp:ListBox ID="lbAllergies" runat="server" Width="320px"></asp:ListBox>

                                    </div>
                                </div>
                            </div>


                            </div>
                            <div class="tab-pane fade show" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                <h3  class="register-heading">Apply as a Hirer</h3>
                                <div class="row register-form">
                                    <div class="col-md-6">
                                        <input type="submit" class="btnRegister"  value="Register" CssClass="btn-hover color-8"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


        </form>
</body>

</html>
