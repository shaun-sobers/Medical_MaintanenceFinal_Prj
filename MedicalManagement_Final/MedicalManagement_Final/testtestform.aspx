<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testtestform.aspx.cs" Inherits="MedicalManagement_Final.testtestform" %>

<!DOCTYPE html>


<!DOCTYPE html>
<html lang="en">

<head>
    <title></title>
  <meta charset="UTF-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
  <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
  <link rel="stylesheet" href="../main.css"/>
    <link href="WeatherDivStyle.css" rel="stylesheet" />
</head>

<body>
  <div class="wrapper">
    <form class="form" runat="server">
       

<div class="widget">
            


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
                <img src="https://s5.postimg.cc/lifnombwz/mumbai1.png" alt="" width="160">
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
                                  varTemp.innerHTML = temp+ "&#0176"
                                  varFeelsLike.innerHTML = "Feels like: " + feelslike+ "&#0176"
                                  varWind.innerHTML = "Wind: " + wind
                                  varDate.innerHTML = new Date().toJSON().slice(0, 10).replace(/-/g, '/') + "&ensp;&ensp;" + timeString;
                                  varIcon.src = `http://openweathermap.org/img/w/${openWeatherData.weather[0].icon}.png`;
                              }
                          </script>

        </div>

                             


        </form>
      </div>
</body>

</html>
