<script>
import Button from './Button.vue'
import { mapActions } from 'vuex';

export default {
    data() {
        return {
            post: {
                title: '',
                photoUrl: 'https://picsum.photos/1920/1080',
                review: '',
            },
        }
    },

    components: {
        Button,
    },

    methods: {
        ...mapActions('posts', ['addPost']),

        create() {
            console.log(this.post)
            this.addPost(this.post)
            this.$router.push(`/my-trips/${this.$route.params.tripId}/posts`)
        }
    }
}

</script>
<template>
    <div class="container">
        <div>
            <FormKit type="form" id="createTripForm" @submit="create">
                <div class="form-container">
                    <div class="form-text-inputs">
                        <FormKit v-model="post.title" label="Post title" type="text" validation="required"
                            placeholder="Write a title for your post" />
                        <!-- <FormKit v-model="post.photoUrl" label="Post photo" type="file"
                            placeholder="Photo of your post" /> -->
                        <FormKit v-model="post.review" label="Post review" type="textarea" validation="required"
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