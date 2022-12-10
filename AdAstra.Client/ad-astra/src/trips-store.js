import Vuex from 'vuex';
import VueCookies from 'vue-cookies'
import axios from 'axios';

export default {
    namespaced: true,
    state: {
        trips: []
    },
    getters: {
        trips: state => state.trips
    },
    mutations: {
        setTrips(state, trips) {
            state.trips = trips
        },
        addTrip(state, trip) {
            state.trips.push(trip)
        },
        updateTrip(state, trip) {
            const index = state.trips.findIndex(i => i.id === trip.id)
            if (index !== -1) {
                state.trips.splice(index, 1, trip)
            }
        },
        deleteTrip(state, trip) {
            const index = state.trips.findIndex(i => i.id === trip.id)
            if (index !== -1) {
                state.trips.splice(index, 1)
            }
        }
    },

    actions: {
        getTrips({ commit }) {
            const jwt = VueCookies.get('jwt');

            var base64Url = jwt.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));

            var user = JSON.parse(jsonPayload);

            axios.get(`https://localhost:7097/api/users/${user.userId}/trips`)
                .then(response => {
                    console.log('it got here');
                    commit('setTrips', response.data)
                })
        },
        addTrip({ commit }, trip) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }

            axios.post('https://localhost:7097/api/trips', trip, config)
                .then(response => {
                    commit('addTrip', response.data)
                })
        },
        updateTrip({ commit }, trip) {
            // Make an API call to update the item
            axios.put(`/api/items/${trip.id}`, trip)
                .then(response => {
                    commit('updateTrip', response.data)
                })
        },
        deleteTrip({ commit }, trip) {
            // Make an API call to delete the item
            axios.delete(`/api/items/${trip.id}`)
                .then(() => {
                    commit('deleteTrip', trip)
                })
        }
    }
}