import { createApp, VueElement } from "vue";

import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'

import axios from 'axios';
Vue.prototype.$http = axios;

import App from "./App.vue";
import router from "./router";

import './assets/app.css'

const app = createApp(App);

app.use(router);

app.mount("#app");
