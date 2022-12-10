<script>
import Navbar from './components/Navbar.vue'
import WelcomeArea from './components/WelcomeArea.vue'
import Footer from './components/Footer.vue'

import { container } from "jenesius-vue-modal";

export default {
    name: 'Home',
    components: {
        WidgetContainerModal: container,
        Navbar,
        WelcomeArea,
        Footer,
    }
}
</script>

<template>
    <Navbar />
    <router-view></router-view>
    <widget-container-modal />
    <!-- <Footer/> -->
</template>

<style>
.modal-container {
    z-index: 999;
    background-color: #1a1a1a99;
}
</style>


