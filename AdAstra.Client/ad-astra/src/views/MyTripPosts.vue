<script>
import Post from '../components/Post.vue'
import Button from '../components/Button.vue'
import { mapState, mapActions } from 'vuex'
import PostCreate from '../components/PostCreate.vue'
import { openModal } from 'jenesius-vue-modal'

export default {
    components: {
        Post,
        Button,
        PostCreate,
    },
    computed: {
        ...mapState('posts', ['posts'])
    },

    methods: {
        ...mapActions('posts', ['getPosts', 'setPosts']),

        createPost() {
            openModal(PostCreate)
        }
    },

    async created() {
        this.getPosts()
        console.log(this.posts)
    }
}

</script>

<template>
    <div class="content">
        <div class="side-nav">
            <Button text="Filter" />
            <router-link :to="{ name: 'CreatePost', params: { tripId: this.$route.params.tripId } }">
                <Button text="Add new post" />
            </router-link>
        </div>
        <div class="cards">
            <div class="card-grid">
                <Post v-for="post in posts" v-bind:key="post.id" :postData="post"></Post>
            </div>
        </div>
    </div>
</template>

<style scoped>
.side-nav {
    box-shadow: 0 0 11px rgba(33, 33, 33, .2);
    border-radius: 10px;
    padding: 12px;
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}

.cards {
    margin-top: 2%;
    margin-left: 5%;
    margin-right: 5%;
}

.card-grid {
    display: grid;
    grid-template-columns: repeat(1, 1fr);
    grid-column-gap: 24px;
    grid-row-gap: 24px;
    max-width: 1200px;
    width: 100%;
}

@media(min-width: 540px) {
    .card-grid {
        grid-template-columns: repeat(2, 1fr);
    }
}

@media(min-width: 960px) {
    .card-grid {
        grid-template-columns: repeat(4, 1fr);
    }
}
</style>