import VueCookies from 'vue-cookies'
import axios from 'axios';
import router from './router/index.js'

export default {
    namespaced: true,
    state: {
        posts: []
    },
    getters: {
        posts: state => state.posts,
        getPostById: state => (id) => state.posts.find(p => p.id == id)
    },
    mutations: {
        setPosts(state, posts) {
            state.posts = posts
        },
        addPost(state, post) {
            state.posts.push(post)
        },
        updatePost(state, post) {
            const index = state.posts.findIndex(i => i.id === post.id)
            if (index !== -1) {
                state.posts.splice(index, 1, post)
            }
        },
        deletePost(state, post) {
            const index = state.posts.findIndex(i => i.id === post.id)
            if (index !== -1) {
                state.posts.splice(index, 1)
            }
        }
    },

    actions: {
        setPosts({ commit }, posts) {
            commit('setPosts', posts)
        },
        async getPosts({ commit }) {
            await axios.get(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts`)
                .then(response => {
                    commit('setPosts', response.data)
                })
        },
        addPost({ commit }, post) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }

            axios.post(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts`, post, config)
                .then(response => {
                    console.log(response.data)
                    commit('addPost', response.data)
                })
        },
        updatePost({ commit }, post) {
            // Make an API call to update the item
            axios.put(`/api/items/${post.id}`, post)
                .then(response => {
                    commit('updatePost', response.data)
                })
        },
        deletePost({ commit }, post) {
            // Make an API call to delete the item
            axios.delete(`/api/items/${post.id}`)
                .then(() => {
                    commit('deletePost', post)
                })
        }
    }
}