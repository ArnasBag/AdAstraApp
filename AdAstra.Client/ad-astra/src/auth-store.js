import Vuex from 'vuex';
import VueCookies from 'vue-cookies'
import axios from 'axios';

export default {
    namespaced: true,
    state: {
        // define the initial state of your store
        isAuthenticated: VueCookies.isKey('jwt'),
        userName: '',
        userLastName: '',
    },
    mutations: {
        // define the mutations that can be used to update the state
        setIsAuthenticated(state, isAuthenticated) {
            state.isAuthenticated = isAuthenticated;

            if (state.isAuthenticated) {
                var jwt = VueCookies.get('jwt');
                var base64Url = jwt.split('.')[1];
                var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
                var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
                    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
                }).join(''));

                var user = JSON.parse(jsonPayload);
                state.userName = user.userFirstName
                state.userLastName = user.userLastName
            }
        },
    },
    actions: {
        // define the actions that can be used to update the state
        async login({ commit }, user) {
            if (user.email && user.password) {
                await axios.post('https://localhost:7097/api/authentication/login', {
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