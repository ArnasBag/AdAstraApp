<script>
import { mapState, mapActions } from 'vuex'
import Button from '../components/Button.vue'
import FormInput from '../components/FormInput.vue'

export default {
    data() {
        return {
            edit: false,
        }
    },

    components: {
        Button,
        FormInput
    },

    props: {
        comment: {
            required: true,
            type: Object
        }
    },
    computed: {
        ...mapState('auth', ['isAuthenticated', 'userName', 'userLastName']),
        ...mapState('comments', ['comments'])
    },

    methods: {
        ...mapActions('posts', ['editPostComment', 'deletePostComment']),


        toggleEdit() {
            this.edit = !this.edit
        },

        async editComment() {
            await this.editPostComment({ postId: this.$route.params.postId, comment: this.comment })
            this.toggleEdit()
        },

        async deleteComment() {
            await this.deletePostComment({ postId: this.$route.params.postId, commentId: this.comment.id })
            this.$emit('deletedComment');
        }
    }
}

</script>

<template>
    <div class="comment">
        <div class="comment-header">
            <div class="comment-author">
                <h1 style="color: #8338ec;">{{ comment.user.firstName }} {{ comment.user.lastName }}</h1>
                <div v-if="comment.user.firstName === userName && comment.user.lastName === userLastName">
                    <span @click="toggleEdit" style="color: var(--purple); margin-right: 12px;">
                        <i class="fa-solid fa-pen-to-square fa-xl"></i>
                    </span>
                    <span @click="deleteComment" style="color: red">
                        <i class="fa-solid fa-trash fa-xl"></i>
                    </span>
                </div>
            </div>
        </div>
        <div class="comment-content">
            <form v-if="edit" @submit.prevent="editComment">
                <div style="display: flex; flex-direction: column;">
                    <FormInput v-model="comment.body" id="body" type="textarea" rows="2" />
                    <!-- <textarea v-model="comment.body"></textarea> -->
                    <Button style="width: 10%; height: auto; padding: 5px; margin-top: 12px;" text="Save" />
                </div>
            </form>
            <p v-else>{{ comment.body }}</p>
        </div>
    </div>
</template>

<style scoped>
h1 {
    font-size: 1.5rem;
}

textarea {
    width: 100%;
    resize: none;
    padding: 5px;
}

.comment-author {
    display: flex;
    align-items: baseline;
    justify-content: space-between;
}

.comment-content {
    margin-top: 20px;
}

.comment {
    margin-top: 30px;
    border-radius: 10px;
    padding: 20px;
    box-shadow: 0 3px 10px rgb(0 0 0 / 0.2);
}
</style>