<script>
    import Navbar from './components/Navbar.vue'
    import WelcomeArea from './components/WelcomeArea.vue'
    import Footer from './components/Footer.vue'

    export default{
        name: 'Home',
        components: {
            Navbar,
            WelcomeArea,
            Footer,
        }
    }
</script>

<template>
    <Navbar/>
    <router-view></router-view>
    <!-- <Footer/> -->
</template>


