<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutMeForm.aspx.cs" Inherits="MedicalManagement_Final.AboutMeForm" %>


<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>About Me Profile</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="style.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" integrity="sha512-+4zCK9k+qNFUR5X+cKL9EIR+ZOhtIloNl9GIKS57V1MyNsYpYcUrUeQc9vNfzsWfV28IaLL3i96P9sdNyeRssA==" crossorigin="anonymous" />
<link href="AboutMeStyle.css" rel="stylesheet" />
  </head>

  <body>
    
    <div class = "about-wrapper">
      <div class = "about-left">
        <div class = "about-left-content">
          <div>
            <div class = "shadow">
              <div class = "about-img">
                <img src = "/Images/Shaun_ProfilePic.png" alt = "about image">
              </div>
            </div>

            <h2>Shaun Sobers</h2>
            <h3>Lasalle College | Computer Science | Aspiring Software Developer | Seeking Entry-Level Programming Position | Experience with Java, C++, C#, Python, HTML, CSS, Javascript'</h3>
          </div>

          <ul class = "icons">
            <li>
                <a href="https://www.facebook.com/shaun.sobers/" class = "fab fa-facebook-f"></a>
            </li>
               <li>
                    <a href="https://www.linkedin.com/in/shaun-sobers-bba27859/" class="fab fa-linkedin"></a>
               </li>
          </ul>
        </div>
        
      </div>

      <div class = "about-right">
        <h1>Hello<span>!</span></h1>
        <h2>Here is a little bit About Me</h2>
        <div class = "about-btns">
            <a href="https://github.com/shaun-sobers" class="btn btn-pink">My GitHub</a>
             <a href="/Images/Shaun_CV.docx" download class="btn btn-white"> Resume/ CV</a>
        </div>

        <div class = "about-para">
          <p>Hello, My name is Shaun Sobers, and I am a 3rd year student, completing my DEC in Computer Science at Lasalle College. I am looking for an entry level position that will allow me to utilize my problem solving skills and attention to detail to further develop my abilities in the field of Computer Science.</p>
            <p>Do not hesitate to check out my GitHub and LinkedIn, or contact me for any inquiries</p>
        </div>
        <div class="credit"> Return to <a href="LoginForm.aspx">Login Page</a></div>
      </div>
    </div>
  </body>
</html>

