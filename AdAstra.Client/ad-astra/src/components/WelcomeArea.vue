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
    methods: {
        openLogin() {
            openModal(Login);
        },
        openRegister() {
            openModal(Register);
        }
    }
}

</script>

<template>
    <div class="welcome-area">
        <div class="welcome-text">
            <h1 style="font-size: 3rem">Welcome to <span style="color: var(--purple)">Ad Astra</span></h1>
            <div class="welcome-description-container">
                <p class="welcome-description">A social network for aspiring and professional astrophotographers to
                    share exciting space photos.</p>
            </div>
            <div>
                <Button @click="openRegister" text="Get started" />
                <h3 style="display: inline; margin-right: 30px; margin-left: 30px">or</h3>
                <Button @click="openLogin" text="Log in" />
            </div>
        </div>
    </div>

</template>

<style scoped>
.welcome-area {
    display: flex;
    width: 100%;
    justify-content: center;
    align-items: center;
    height: calc(100vh - 64px);
}

.welcome-text {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.welcome-description-container {
    margin-top: 12px;
    margin-bottom: 36px;
}
</style>