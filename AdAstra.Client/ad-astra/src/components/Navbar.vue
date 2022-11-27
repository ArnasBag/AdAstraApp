<template>
    <nav class="navbar">
        <img class="logo" src="../assets/images/Galaxy-94.png" alt="Logo">
        <ul class="nav-menu">
            <li class="nav-item">
                <router-link class="nav-link" to="/trips">Trips</router-link>
                <!-- <a href="#" class="nav-link">Trips</a> -->
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link">About</a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link">Contact</a>
            </li>
        </ul>
        <div class="hamburger">
            <span class="bar"></span>
            <span class="bar"></span>
            <span class="bar"></span>
        </div>
    </nav>
</template>

<script>
export default{
    mounted(){
        const hamburger = document.querySelector(".hamburger");
        const navMenu = document.querySelector(".nav-menu");

        hamburger.addEventListener("click", mobileMenu);

        function mobileMenu() {
            console.log("test")
            hamburger.classList.toggle("active");
            navMenu.classList.toggle("active");
        }
    }
}
</script>


<style scoped>

.logo{
    height: 64px;
    width: auto;
    filter: invert(20%) sepia(69%) saturate(3071%) hue-rotate(257deg) brightness(111%) contrast(96%);
}

.navbar {
    position: fixed;
    height: 64px;
    width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding-left: 1rem;
    padding-right: 1rem;
    background-color: white;
    box-shadow: 0 0 11px rgba(33,33,33,.2); 
}
.hamburger {
    display: none;
}
.bar {
    display: block;
    width: 25px;
    height: 3px;
    margin: 5px auto;
    -webkit-transition: all 0.3s ease-in-out;
    transition: all 0.3s ease-in-out;
    background-color: #101010;
}
.nav-menu {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.nav-item {
    margin-left: 5rem;
}

.nav-link{
    font-size: 1.2rem;
    font-weight: 400;
    color: #8338ec;
}

.nav-link:hover{
    color: #482ff7;
}

.nav-logo {
    font-size: 2.1rem;
    font-weight: 500;
    color: #482ff7;
}
@media only screen and (max-width: 768px) {
    .nav-menu {
        position: fixed;
        left: -100%;
        top: 5rem;
        flex-direction: column;
        background-color: #fff;
        width: 100%;
        border-radius: 10px;
        text-align: center;
        transition: 0.3s;
        box-shadow:
            0 10px 27px rgba(0, 0, 0, 0.05);
    }

    .nav-menu.active {
        left: 0;
    }

    .nav-item {
        margin: 2.5rem 0;
    }

    .hamburger {
        display: block;
        cursor: pointer;
    }
    .hamburger.active .bar:nth-child(2) {
        opacity: 0;
    }

    .hamburger.active .bar:nth-child(1) {
        transform: translateY(8px) rotate(45deg);
    }

    .hamburger.active .bar:nth-child(3) {
        transform: translateY(-8px) rotate(-45deg);
    }
    
}
</style>
