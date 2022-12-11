import Vuex from 'vuex';
import VueCookies from 'vue-cookies'
import axios from 'axios';

export default {
    namespaced: true,
    state: {
        trips: []
    },
    getters: {
        trips: state => state.trips,
        getTripById: state => async (id) => await state.trips.find(p => p.id == id)
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
        deleteTrip(state, tripId) {
            const index = state.trips.findIndex(i => i.id === tripId)
            if (index !== -1) {
                state.trips.splice(index, 1)
            }
        }
    },

    actions: {
        async getUserTrips({ commit }) {
            const jwt = VueCookies.get('jwt');
            var base64Url = jwt.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));

            var user = JSON.parse(jsonPayload);

            await axios.get(`https://localhost:7097/api/users/${user.userId}/trips`)
                .then(response => {
                    commit('setTrips', response.data)
                })
        },
        async getTrips({ commit }) {
            await axios.get(`https://localhost:7097/api/trips`)
                .then(response => {
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
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }

            axios.put(`https://localhost:7097/api/trips/${trip.id}`, trip, config)
                .then(response => {
                    commit('updateTrip', trip)
                })
        },
        deleteTrip({ commit }, tripId) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }

            // Make an API call to delete the item
            axios.delete(`https://localhost:7097/api/trips/${tripId}`, config)
                .then(() => {
                    commit('deleteTrip', tripId)
                })
                .catch(error => {
                    console.log(error.response.status)
                    if (error.response.status == 400) {
                        console.log("cant delete his one")
                    }
                })
        }
    }
}