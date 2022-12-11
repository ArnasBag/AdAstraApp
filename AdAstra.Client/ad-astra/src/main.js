import { createApp } from "vue";
import App from "./App.vue";

import { plugin, defaultConfig } from '@formkit/vue'

import Vuex from 'vuex'

import authStore from './auth-store';
import tripStore from './trips-store';
import postStore from './posts-store';
import commentsStore from "./comments-store";


import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'

import router from "./router";

import './assets/app.css'

const app = createApp(App);

app.use(Vuex);

const store = new Vuex.Store({
    modules: {
        auth: authStore,
        trips: tripStore,
        posts: postStore,
        comments: commentsStore,
    }
})

app.use(store)

app.use(router);
app.use(plugin, defaultConfig({
    theme: 'genesis'
}))
app.mount("#app");
