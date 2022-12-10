<template>
    <nav class="navbar">
        <div class="logo-area">
            <img class="logo" src="../assets/images/Galaxy-94.png" alt="Logo">
            <h1 style="color: #8338ec;">Ad Astra</h1>
        </div>
        <ul class="nav-menu">
            <li class="nav-item">
                <router-link to="/my-trips">
                    <Button class="auth-btn" v-if="isAuthenticated" text="My trips" />
                </router-link>
            </li>
            <li class="nav-item">
                <router-link class="nav-link" to="/trips">Trips</router-link>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link">About</a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link">Contact</a>
            </li>
            <li class="nav-item">
                <Button class="auth-btn" v-if="isAuthenticated" @click="logout" text="Logout" />
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
import Button from '../components/Button.vue'
import { mapState } from 'vuex'

export default {
    components: {
        Button,
    },

    computed: {
        ...mapState('auth', ['isAuthenticated']),
    },

    methods: {
        logout() {
            this.$store.dispatch('auth/logout');
            this.$router.push('/');
        },
    },
    mounted() {

        const hamburger = document.querySelector(".hamburger");
        const navMenu = document.querySelector(".nav-menu");

        hamburger.addEventListener("click", mobileMenu);

        function mobileMenu() {
            console.log("test")
            hamburger.classList.toggle("active");
            navMenu.classList.toggle("active");
        }
    }
};
</script>


<style scoped>
.auth-btn {
    width: auto;
    height: auto;
    padding: 12px;
    margin: 0;
}

.logo-area {
    display: flex;
    align-items: center;
}

.logo {
    height: 64px;
    width: auto;
    filter: invert(20%) sepia(69%) saturate(3071%) hue-rotate(257deg) brightness(111%) contrast(96%);
}

.navbar {
    position: fixed;
    top: 0;
    width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding-left: 1%;
    padding-right: 1%;
    background-color: #29292b;
    box-shadow: 0 0 11px rgba(33, 33, 33, .2);

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

.nav-link {
    font-size: 1.2rem;
    font-weight: 400;
    color: #8338ec;
}

.nav-link:hover {
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
