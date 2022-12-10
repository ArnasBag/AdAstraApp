import { createApp, VueElement } from "vue";
import Vuex from 'vuex'

import authStore from './auth-store';
import tripStore from './trips-store';
import postStore from './posts-store';

import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'

import App from "./App.vue";
import router from "./router";

import './assets/app.css'

const app = createApp(App);

app.use(Vuex);

const store = new Vuex.Store({
    modules: {
        auth: authStore,
        trips: tripStore,
        posts: postStore,
    }
})

app.use(store)

app.use(router);
app.mount("#app");
