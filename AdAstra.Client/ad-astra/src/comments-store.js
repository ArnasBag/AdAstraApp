import VueCookies from 'vue-cookies'
import axios from 'axios';
import router from './router/index.js'

export default {
    namespaced: true,
    state: {
        comments: []
    },
    getters: {
        comments: state => state.comments
    },
    mutations: {
        setComments(state, comments) {
            state.comments = comments
        },
        addComment(state, comment) {
            state.comments.push(comment)
        },
        updateComment(state, comment) {
            const index = state.comments.findIndex(i => i.id === comment.id)
            if (index !== -1) {
                state.comments.splice(index, 1, comment)
            }
        },
        deleteComment(state, comment) {
            const index = state.comments.findIndex(i => i.id === comment.id)
            if (index !== -1) {
                state.comments.splice(index, 1)
            }
        }
    },

    actions: {
        setComments({ commit }, comments) {
            commit('setComments', comments)
        },
        async getComments({ commit }) {
            await axios.get(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts/${router.currentRoute.value.params.postId}/comments`)
                .then(response => {
                    commit('setComments', response.data)
                })
        },
        addComment({ commit }, comment) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }

            axios.comment(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/comments`, comment, config)
                .then(response => {
                    commit('addComment', response.data)
                })
        },
        updateComment({ commit }, comment) {
            // Make an API call to update the item
            axios.put(`/api/items/${comment.id}`, comment)
                .then(response => {
                    commit('updateComment', response.data)
                })
        },
        deleteComment({ commit }, comment) {
            // Make an API call to delete the item
            axios.delete(`/api/items/${comment.id}`)
                .then(() => {
                    commit('deleteComment', comment)
                })
        }
    }
}