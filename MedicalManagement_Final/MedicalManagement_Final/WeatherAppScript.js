                        <script src="openWeatherAPIKey.js"></script>


                              geoLookUp()
                              function geoLookUp() {

                                  const p = document.querySelector('#weatherBug p')

                                  function success(position) {
                                      const latitude = position.coords.latitude
                                      const longitude = position.coords.longitude
                                      // p.textContent = latitude
                                      setWeather(latitude, longitude)
                                  }

                                  function error(err) {
                                      p.textContent = err.Code
                                  }

                                  if (!navigator.geolocation) {
                                      p.textContent = "Geolocation is not allowed by browser"
                                  }
                                  else {
                                      p.textContent = "Locating...."
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
                                          p.textContent = "loading...."
                                          openWeatherData = JSON.parse(xhr.responseText)
                                          populateWeatherInfo(openWeatherData, p)
                                      }
                                      else {
                                          p.textContent = "error: " + xhr.status
                                      }
                                  }, false)

                                  xhr.send()

                              }

                              function populateWeatherInfo(openWeatherData, p) {
                                  const location = openWeatherData.name
                                  const temp = Math.round(openWeatherData.main.temp)
                                  const feelslike = Math.round(openWeatherData.main.feels_like)
                                  const wind = Math.round(openWeatherData.wind.speed)

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

                                  p.innerHTML = str
                              }

                              function CompleteWeather() {

                                  geoLookUp()
                              }