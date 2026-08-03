Main Project code is here, while there also parts 1, 2, 3, 4. and css design, the main html is "MainProject" one and bellow and the flow:

Navigation Flow
index.html (Landing Page) → Login → login.html
login.html → Login button → main.html
main.html → Logout → index.html
About can be accessed from every page through the navigation bar.





<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Restaurant Website</title>

<style>
*{
    margin:0;
    padding:0;
    box-sizing:border-box;
    font-family:Arial, sans-serif;
}

body{
    background:#f4f4f4;
}

/* Header */
header{
    background:#8B0000;
    color:white;
    text-align:center;
    padding:20px;
}

/* Navigation */
nav{
    background:#333;
    padding:15px;
    text-align:center;
}

nav a{
    color:white;
    text-decoration:none;
    margin:0 20px;
    font-weight:bold;
}

nav a:hover{
    color:orange;
}

/* Sections */
.page{
    display:none;
    padding:40px;
    min-height:70vh;
}

.active{
    display:block;
}

.hero{
    text-align:center;
    margin-top:30px;
}

.hero h1{
    color:#8B0000;
    margin-bottom:20px;
}

.hero p{
    margin-bottom:20px;
}

/* Cards */
.cards{
    display:flex;
    justify-content:center;
    gap:20px;
    flex-wrap:wrap;
    margin-top:20px;
}

.card{
    background:white;
    width:220px;
    padding:20px;
    border-radius:10px;
    box-shadow:0 0 10px gray;
    text-align:center;
}

/* Button */
button{
    background:#8B0000;
    color:white;
    border:none;
    padding:10px 20px;
    cursor:pointer;
    border-radius:5px;
}

button:hover{
    background:#b22222;
}

/* Login */
.login-box{
    width:350px;
    margin:auto;
    background:white;
    padding:30px;
    border-radius:10px;
    box-shadow:0 0 10px gray;
}

input{
    width:100%;
    padding:10px;
    margin:10px 0;
}

/* Footer */
footer{
    background:#333;
    color:white;
    text-align:center;
    padding:20px;
}

footer a{
    color:white;
    margin:0 10px;
    text-decoration:none;
}
</style>

</head>
<body>

<header>
<h1>Delicious Restaurant</h1>
</header>

<nav>
<a href="#" onclick="showPage('landing')">Home</a>
<a href="#" onclick="showPage('about')">About</a>
<a href="#" onclick="showPage('login')">Login</a>
</nav>

<!-- LANDING PAGE -->
<div id="landing" class="page active">

<div class="hero">
<h1>Welcome to Delicious Restaurant</h1>

<p>
Enjoy delicious meals made with fresh ingredients.
Experience quality food and excellent service.
</p>

<button onclick="showPage('login')">Login</button>

</div>

</div>

<!-- ABOUT PAGE -->
<div id="about" class="page">

<h1>About Us</h1>

<br>

<p>
Delicious Restaurant serves high-quality meals prepared by experienced chefs.
We are committed to providing excellent customer service and creating memorable dining experiences.
</p>

<br>

<h2>Our Features</h2>

<div class="cards">

<div class="card">
<h3>Fresh Food</h3>
<p>Prepared every day.</p>
</div>

<div class="card">
<h3>Fast Service</h3>
<p>Friendly staff and quick service.</p>
</div>

<div class="card">
<h3>Affordable</h3>
<p>Quality meals at affordable prices.</p>
</div>

</div>

</div>

<!-- LOGIN PAGE -->
<div id="login" class="page">

<div class="login-box">

<h2>Login</h2>

<form onsubmit="login(event)">

<input type="text" placeholder="Username" required>

<input type="password" placeholder="Password" required>

<button type="submit">Login</button>

</form>

</div>

</div>

<!-- MAIN PAGE -->
<div id="main" class="page">

<h1>Welcome!</h1>

<br>

<p>You have successfully logged in.</p>

<br>

<h2>Restaurant Menu</h2>

<div class="cards">

<div class="card">
<h3>Burger</h3>
<p>$5.99</p>
</div>

<div class="card">
<h3>Pizza</h3>
<p>$9.99</p>
</div>

<div class="card">
<h3>Fried Chicken</h3>
<p>$6.99</p>
</div>

<div class="card">
<h3>Pasta</h3>
<p>$7.99</p>
</div>

</div>

<br><br>

<button onclick="showPage('landing')">Logout</button>

</div>

<footer>

<h3>Follow Us</h3>

<p>
<a href="https://facebook.com" target="_blank">Facebook</a> |
<a href="https://instagram.com" target="_blank">Instagram</a> |
<a href="https://twitter.com" target="_blank">Twitter</a>
</p>

<p>&copy; 2026 Delicious Restaurant</p>

</footer>

<script>

function showPage(page){

let pages=document.querySelectorAll(".page");

pages.forEach(function(p){
    p.classList.remove("active");
});

document.getElementById(page).classList.add("active");

}

function login(event){

event.preventDefault();

showPage("main");

}

</script>
/
</body>
</html>


