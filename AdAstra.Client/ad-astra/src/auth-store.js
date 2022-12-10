import Vuex from 'vuex';
import VueCookies from 'vue-cookies'
import axios from 'axios';

export default {
    namespaced: true,
    state: {
        // define the initial state of your store
        isAuthenticated: VueCookies.isKey('jwt'),
    },
    mutations: {
        // define the mutations that can be used to update the state
        setIsAuthenticated(state, isAuthenticated) {
            state.isAuthenticated = isAuthenticated;
        },
    },
    actions: {
        // define the actions that can be used to update the state
        login({ commit }, user) {
            if (user.email && user.password) {
                axios.post('https://localhost:7097/api/authentication/login', {
                    email: user.email,
                    password: user.password
                })
                    .then((response) => {
                        const expires = new Date()
                        expires.setDate(expires.getDate() + 1)

                        const options = {
                            domain: '.example.com',
                            path: '/',
                            expires
                        }
                        VueCookies.set('jwt', response.data.token, options)
                    })
                    .catch(function (error) {
                        console.log(error)
                    });
            }
            commit('setIsAuthenticated', true);
        },
        logout({ commit }) {
            VueCookies.remove('jwt');
            commit('setIsAuthenticated', false);
        },
    },
};