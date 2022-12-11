<script>
import Button from './Button.vue'
import { mapActions, mapGetters, mapState } from 'vuex';

export default {
    data() {
        return {
            postEdit: {
                title: '',
                photoUrl: '',
                review: '',
            },
        }
    },

    computed: {
        ...mapGetters('posts', ['getPostById']),
        ...mapState('posts', ['posts']),
    },

    components: {
        Button,
    },

    methods: {
        ...mapActions('posts', ['addPost', 'getPosts', 'updatePost']),

        async update() {
            await this.updatePost(this.postEdit)
            this.$router.push(`/trips/${this.$route.params.tripId}/posts/${this.$route.params.postId}`)
        }
    },

    async created() {
        await this.getPosts()
        this.postEdit = await this.getPostById(this.$route.params.postId)
    },
}

</script>
<template>
    <div class="container">
        <div>
            <FormKit type="form" id="createTripForm" @submit="update">
                <div class="form-container">
                    <div class="form-text-inputs">
                        <FormKit name="postTitle" v-model="postEdit.title" label="Post title" type="text"
                            validation="required" placeholder="Write a title for your post" />
                        <FormKit v-model="postEdit.review" label="Post review" type="text" validation="required"
                            placeholder="Write a review for your post" />
                    </div>
                </div>
            </FormKit>
        </div>
        <div class="submit-form">
            <Button @click="create" text="Create new post" />
        </div>

    </div>

</template>

<style>
.submit-form {
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
}

.non-resize {
    resize: none;
}

[data-invalid] .formkit-inner {
    border-color: red;
    box-shadow: 0 0 0 1px red;
}

[data-complete] .formkit-inner {
    border-color: red;
    box-shadow: 0 0 0 1px green;
}

[data-complete] .formkit-inner::after {
    content: '✅';
    display: block;
    padding: 0.5em;
}

.form-text-inputs {
    width: 50%;
    display: flex;
    flex-direction: column;
}

.form-container {
    justify-content: space-evenly;
    margin-left: 5%;
    margin-right: 5%;
    margin-top: 12px;
    display: flex;
}

.container {
    height: 80vh;
    max-height: 80vh;
    display: flex;
    flex-direction: column;
}
</style>