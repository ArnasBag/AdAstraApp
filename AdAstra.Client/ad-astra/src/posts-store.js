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
        deletePost(state, postId) {
            const index = state.posts.findIndex(i => i.id === postId)
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
        async addPost({ commit }, post) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }

            await axios.post(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts`, post, config)
                .then(response => {
                    console.log(response.data)
                    commit('addPost', response.data)
                })
        },
        async updatePost({ commit }, post) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }

            // Make an API call to update the item
            await axios.put(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts/${router.currentRoute.value.params.postId}`, post, config)
                .then(response => {
                    commit('updatePost', post)
                })
        },
        async deletePost({ commit }, postId) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }
            // Make an API call to delete the item
            await axios.delete(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts/${postId}`, config)
                .then(() => {
                    commit('deletePost', postId)
                })
        },
        async addCommentToPost({ commit }, { postId, comment }) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }
            // Make an API call to delete the item
            await axios.post(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts/${postId}/comments`, comment, config)
                .then(async () => {
                    await axios.get(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts`)
                        .then(response => {
                            commit('setPosts', response.data)
                        })
                })
        },

        async editPostComment({ commit }, { postId, comment }) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }
            // Make an API call to delete the item
            await axios.put(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts/${postId}/comments/${comment.id}`, comment, config)
                .then(async () => {
                    await axios.get(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts`)
                        .then(response => {
                            commit('setPosts', response.data)
                        })
                })
        },

        async deletePostComment({ commit }, { postId, commentId }) {
            const jwt = VueCookies.get('jwt');

            const config = {
                headers: { Authorization: `Bearer ${jwt}` }
            }
            // Make an API call to delete the item
            await axios.delete(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts/${postId}/comments/${commentId}`, config)
                .then(async () => {
                    await axios.get(`https://localhost:7097/api/trips/${router.currentRoute.value.params.tripId}/posts`)
                        .then(response => {
                            commit('setPosts', response.data)
                        })
                })
        },

    }
}