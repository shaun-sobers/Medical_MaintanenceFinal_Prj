<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeNurseForm.aspx.cs" Inherits="MedicalManagement_Final.HomeNurseForm" %>

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
        <style type="text/css">
            @import url('https://fonts.googleapis.com/css?family=Libre+Caslon+Text:400,700&display=swap');

body {
  font-family: Libre Caslon Text;
  background-color: blue;
  background-image: url(https://images.unsplash.com/photo-1516841273335-e39b37888115?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mjd8fG51cnNlfGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=600&q=60);
}

.body-text {
  padding-top: 20vh;
  text-align: center;
  position: relative;
}

.hamburger-icon {
  position: absolute;
  z-index: 1;
  top: 5vh;
  left: 5vw;
  padding-bottom: 2vh;
}

.hamburger-icon span {
  height: 5px;
  width: 40px;
  background-color: black;
  display: block;
  margin: 5px 0px 5px 0px;
  transition: 0.7s ease-in-out;
  transform: none;
}

#openmenu:checked ~ .menu-pane {
  left: -5vw;
  transform: translateX(-5vw);
}

#openmenu:checked ~ .body-text {
display: none;
}

#openmenu:checked ~ .hamburger-icon span:nth-of-type(2) {
  transform: translate(0%, 175%) rotate(-45deg);
  background-color: black;
}

#openmenu:checked ~ .hamburger-icon span:nth-of-type(3) {
  transform: rotate(45deg);
  background-color: black;
}

#openmenu:checked ~ .hamburger-icon span:nth-of-type(1) {
  opacity: 0;
}

#openmenu:checked ~ .hamburger-icon span:nth-of-type(4) {
  opacity: 0;
}

div.menu-pane {
  background-color: beige;
  position: absolute;
  transform: translateX(-105vw);
  transform-origin: (0, 0);
  width: 100vw;
  transition: 0.6s ease-in-out;
}

.menu-pane p {
  color: black;
  font-size: 0.6em;
}

.menu-pane nav {
  padding: 10%;
}

.menu-links li, a, span {
      transition: 0.5s ease-in-out;
}

.menu-pane ul {
  padding: 10%;
  display: inline-block;
}

.menu-pane li {
  padding-top: 20px;
  padding-bottom: 20px;
  margin-left: 10px;
    font-size: 1em;
}


.menu-pane li:first-child {
  font-size: 1.3em;
  margin-left: -10px;
}


.menu-links li a {
  color: white;
  text-decoration: none;
}


.menu-links li:hover a {
  color: #FFAB91;
}

.menu-links li:first-child:hover a {
  color: black;  
  background-color: #FFAB91;
}

#QC-info {
  background-color: #FFAB91;
    border: 2px solid;
  border-color: #FFAB91;
display: block;
  opacity: 0;
  
}

.menu-links li:first-child:hover #QC-info {
opacity: 1;
}

.menu-links li:first-child:hover #DC-info {
opacity: 1;
}

#DC-info {
  background-color: #FFAB91;
    border: 2px solid;
  border-color: #FFAB91;
display: block;
  opacity: 0;
}


.menu-links li:first-child a {
  padding: 5px;
}



input.hamburger-checkbox {
  position: absolute;
  z-index: 3;
  top: 5vh;
  left: 5vw;
  width: 10vw;
  opacity: 0;
  height: 6vh;
}


            </style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>





</head>
<body>
    <form id="form1" runat="server">
    <div class="menu-container">
  
  <input type="checkbox" id="openmenu" class="hamburger-checkbox" style="left: -2147483648px; top: -2147483648px"/>
  
  <div class="hamburger-icon">
    <label for="openmenu" id="hamburger-label">
      <span></span>
      <span></span>
      <span></span>
      <span></span>
    </label>    
  </div>

    <div class="menu-pane">
      
      <nav>
          <a href="/InboxForm.aspx">Inbox</a>
         <asp:Button ID="btnLoggout" runat="server" OnClick="btnLoggout_Click" Text="LogOut" />

          <div class="menu-links">
               <div class="box" style="display:flex;align-items:center;justify-content:center">
                    <div id="overlay">
                        <ul>
                            <li>
                                <asp:ImageMap ID="imgUser" runat="server" CssClass="image"></asp:ImageMap>
                            </li>
                            <li>
                                <asp:Label ID="lblUsersName" runat="server"></asp:Label>
                            </li>
                            <li>
                               <asp:Label ID="lblBirthday" runat="server"></asp:Label> 
                            </li>
                        </ul>
                 </div>
               </div>

              <div>
                  <div class="widget">
   <link href="WeatherDivStyle.css" rel="stylesheet" />
            <div class="left-panel panel" id="weatherBug">
                <div class="date">
                   <p id="date">Date</p>
                </div>
                <div class="city">
                    <p id="city">No Weather Data</p>
                </div>
                <div class="temp">
                   <p id="temp">
                        27&deg;
                   </p>
                </div>
            </div>
            <div class="right-panel panel">
                <div class="city">
                    <p id="wind"></p>
                </div>
                <div class="city">
                <p id="feels-like"></p>
                </div>
                 <div class="city">
                    <img src="" id="icon">
                </div>
            </div>

                            <script src="openWeatherAPIKey.js"></script>
                          <script>

                              var varCity = document.getElementById("city")
                              var varTemp = document.getElementById("temp")
                              var varFeelsLike = document.getElementById("feels-like")
                              var varDate = document.getElementById("date")
                              var varWind = document.getElementById("wind")
                              var varIcon = document.getElementById("icon")

                              varDate.innerHTML = new Date().toJSON().slice(0, 10).replace(/-/g, '/');
                              geoLookUp()
                              function geoLookUp() {

                                  //const p = document.querySelector('#weatherBug p')

                                  function success(position) {
                                      const latitude = position.coords.latitude
                                      const longitude = position.coords.longitude
                                      setWeather(latitude, longitude)
                                  }

                                  function error(err) {
                                      varCity.textContent = err.Code
                                  }

                                  if (!navigator.geolocation) {
                                      varCity.textContent = "Geolocation is not allowed by browser"
                                  }
                                  else {
                                      varCity.textContent = "Locating...."
                                      navigator.geolocation.getCurrentPosition(success, error)
                                  }


                              }

                              function setWeather(latitude, longitude) {

                                  const p = document.querySelector('#weatherBug p')

                                  let openWeatherData = {}
                                  let xhr = new XMLHttpRequest()
                                  xhr.open('GET', `https://api.openweathermap.org/data/2.5/weather?lat=${latitude}&lon=${longitude}&appid=${openWeatherKey}&units=metric`)


                                  xhr.responseType = 'text'

                                  xhr.addEventListener('load', function () {
                                      if (xhr.status === 200) {
                                          varCity.textContent = "loading...."
                                          openWeatherData = JSON.parse(xhr.responseText)
                                          populateWeatherInfo(openWeatherData)
                                      }
                                      else {
                                          p.textContent = "error: " + xhr.status
                                      }
                                  }, false)

                                  xhr.send()

                              }

                              function populateWeatherInfo(openWeatherData) {
                                  const location = openWeatherData.name
                                  const temp = Math.round(openWeatherData.main.temp)
                                  const feelslike = Math.round(openWeatherData.main.feels_like)
                                  const wind = Math.round(openWeatherData.wind.speed)
                                  // const icon = openWeatherData[0].weather.icon
                                  const time = new Date(openWeatherData.dt * 1000)

                                  const hrs = time.getHours()
                                  let mins = time.getMinutes()

                                  let timeString = ''

                                  if (mins < 10) {
                                      mins = `0${mins}`
                                  }
                                  if (hrs === 12) {
                                      timeString = `12:${mins} PM`
                                  }
                                  else if (hrs > 12) {
                                      timeString = `${hrs - 12}:${mins} PM`
                                  }
                                  else if (hrs === 0) {
                                      timeString = `12:${mins} AM`
                                  }
                                  else {
                                      timeString = `${hrs}:${mins} AM`
                                  }

                                  const str = `${location}<br> Temp:${temp} &#0176 <br> Wind: ${wind} <br>  Feels like: ${feelslike}&#0176 <br> Time: ${timeString}`

                                  // p.innerHTML = str
                                  varCity.innerHTML = location
                                  varTemp.innerHTML = temp + "&#0176"
                                  varFeelsLike.innerHTML = "Feels like: " + feelslike + "&#0176"
                                  varWind.innerHTML = "Wind: " + wind
                                  varDate.innerHTML = new Date().toJSON().slice(0, 10).replace(/-/g, '/') + "&ensp;&ensp;" + timeString;
                                  varIcon.src = `http://openweathermap.org/img/w/${openWeatherData.weather[0].icon}.png`;
                              }
                          </script>

        </div>
              </div>
          </div>
      
         
         
          <ul class="menu-links">

            <li>
            </li>

        </ul>
      </nav>
    </div>
  <div class="body-text">
      <h1>
                     <asp:Label ID="LblWelcome" Text="Hello, " runat="server"></asp:Label>
      </h1>
            <br>
     <br>
     <h2>
                  <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" />
                  <asp:Button ID="btnInbox" runat="server" OnClick="btnInbox_Click" Text="Inbox" />
         <div>
             <asp:DropDownList Id="dlPatients" runat="server"></asp:DropDownList>
             <asp:Button ID="btnSelect" Text="Select Patient" runat="server" OnClick="btnSelect_Click" />
         </div>

     </h2>
      <br>
     <br>
      <asp:GridView ID="gvAppointments" runat="server"></asp:GridView>

             
        </div>
</div>
</form>
</body>
</html>