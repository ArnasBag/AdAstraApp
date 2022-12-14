<script>
import Trip from '../components/UserTrip.vue'
import Button from '../components/Button.vue'
import TripCreate from '../components/TripCreate.vue'
import Comments from '../components/Comments.vue'
import DeletePost from '../components/DeletePost.vue'
import FormInput from '../components/FormInput.vue'

import { mapGetters, mapActions, mapState } from 'vuex'
import { Comment } from 'vue';
import { promptModal } from "jenesius-vue-modal"


export default {
    components: {
        Trip,
        Button,
        TripCreate,
        Comments,
        Comment,
        DeletePost,
        FormInput,
    },

    data() {
        return {
            post: {
                type: Object
            },
            comment: {
                body: ''
            },
        }
    },

    computed: {
        ...mapState('posts', ['posts']),
        ...mapGetters('posts', ['getPostById']),
        ...mapState('auth', ['isAuthenticated', 'userName', 'userLastName']),
    },

    methods: {
        ...mapActions('posts', ['getPosts', 'setPosts', 'addCommentToPost']),

        async deletePost() {
            await promptModal(DeletePost, {
                postId: this.post.id
            })
        },

        async updatePost() {
            this.$router.push({ name: 'EditPost' })
        },

        async writeComment() {
            await this.addCommentToPost({ postId: this.$route.params.postId, comment: this.comment })
            this.post = await this.getPostById(this.$route.params.postId)
        },

        async deletedCommentHandler() {
            this.post = await this.getPostById(this.$route.params.postId)
        }
    },

    async created() {
        await this.getPosts()
        this.post = this.getPostById(this.$route.params.postId)
    },
}

</script>

<template>
    <div class="page">
        <div class="sidebar">
            <div v-if="isAuthenticated">
                <Button @click="updatePost" text="Edit post" />
                <Button @click="deletePost" text="Delete post" />
            </div>

        </div>

        <div class="container">
            <div class="header">
                <div class="image-area">
                    <img class="main-image" :src="post.photoUrl" alt="">
                </div>
            </div>
            <div class="content">
                <div class="title">
                    <h1>{{ post.title }}</h1>
                </div>
                <div class="description">
                    <p>{{ post.review }}</p>
                </div>
                <div v-if="isAuthenticated" class="write-comment-container">
                    <!-- <form @submit.prevent="writeComment">
                        <textarea v-model="comment.body" id="commentBody" name="commentBody"
                            placeholder="Write a comment..." rows="5"></textarea>

                    </form> -->
                    <FormInput v-model="comment.body" id="commentBody" label="Comment" type="textarea"
                        placeholder="Write a comment..." rows="10" />
                    <div class="write-comment-footer">
                        <Button @click="writeComment" class="comment-btn" text="Comment" />
                    </div>

                </div>
                <div class="comments">
                    <Comments @deletedComment="deletedCommentHandler" v-for="comment in post.comments"
                        v-bind:key="comment.id" :comment="comment" />
                </div>
            </div>
        </div>
    </div>



</template>

<style scoped>
.write-comment-container {
    width: 100%;
    margin-top: 24px;
}

.write-comment-container textarea {
    width: 100%;
    font-family: 'Roboto';
    color: white;
    padding: 12px;
    resize: none;
}

.comment-btn {
    width: auto;
    height: auto;
    padding: 12px;
    float: right;
}

.page {
    margin-top: 12px;
    display: flex;
}

.sidebar {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 20%;

}

.container {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 60%;
    box-shadow: 0 0 11px rgba(33, 33, 33, .2);
    border-radius: 12px;

}

.header {
    width: 100%;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}

.image-area {
    display: flex;
    justify-content: center;
    padding: 32px 32px 0 32px;
    border-radius: 10px;

}

.main-image {
    border-radius: 10px;
    width: 100%;
    max-height: 65vh;
}

.content {
    display: flex;
    flex-direction: column;
    width: 100%;
    padding: 0 32px 32px 32px
}

.user-info {
    margin-left: 20px;
}

.title {
    margin-top: 30px;
    width: 80%;
}

.description {
    margin-top: 30px;
}

@media only screen and (max-width: 600px) {
    .main-container {
        padding-left: 10px;
        padding-right: 10px;
        margin-left: 0%;
        margin-right: 0%;
        flex-direction: column;
    }

    .user-info {
        display: none;
    }

    .image-area {
        width: 100%;
    }
}

@media only screen and (max-width: 992px) {
    .main-container {
        padding-left: 2%;
        padding-right: 2%;
        margin-left: 2%;
        margin-right: 2%;
    }
}
</style>