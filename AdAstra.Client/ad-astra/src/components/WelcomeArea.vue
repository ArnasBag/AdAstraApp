<script>
import Button from './Button.vue'
import Login from './Login.vue'
import Register from './Register.vue'
import { openModal } from 'jenesius-vue-modal'

export default {
    name: 'WelcomeArea',
    components: {
        Button,
        Login,
        Register,
    },
    data() {
        return {
            showLogin: false,
            showRegister: false,
        }
    },
    methods: {
        openLogin() {
            console.log('triggered')
            openModal(Login);
        }
    }
}

</script>

<template>
    <div class="welcome-area">
        <div class="welcome-text">
            <h1 class="welcome-greeting">Welcome to <span class="logo">Ad Astra</span></h1>
            <div class="welcome-description-container">
                <p class="welcome-description">A social network for aspiring and professional astrophotographers to
                    share exciting space photos.</p>
                <Button text="Get started" />
                <h3 style="display: inline; margin-right: 30px;">or</h3>
                <Button @click="openLogin" text="Log in" />
                <Teleport to="body">
                    <Register :show="showRegister">

                    </Register>
                </Teleport>
            </div>
        </div>
    </div>
</template>

<style scoped>
.welcome-area {
    display: flex;
    justify-content: left;
    align-items: center;
    height: calc(100vh - 64px);
    background: url('../assets/images/starry-background(1).png');
    background-repeat: no-repeat;
    background-position: 100% 50%;
    background-size: contain;
    z-index: 1;
}

.welcome-text {
    margin-left: 5%;
    margin-bottom: 10%;
}

.welcome-greeting {
    font-size: 3rem;
}

.welcome-description-container {
    width: 80%;
}

.welcome-description {
    margin-top: 5%;
    margin-bottom: 20px;
    font-size: 1.1rem;
}

.logo {
    color: #8338ec;
    font-size: 3rem;
}
</style>