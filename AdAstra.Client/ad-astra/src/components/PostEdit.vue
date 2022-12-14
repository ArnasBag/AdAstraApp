<script>
import Button from './Button.vue'
import FormInput from './FormInput.vue'
import { mapActions, mapGetters, mapState } from 'vuex';
import { useVuelidate } from '@vuelidate/core'
import { required } from '@vuelidate/validators'
export default {
    setup() {
        return {
            v$: useVuelidate()
        }
    },

    data() {
        return {
            post: {
                title: '',
                photoUrl: 'https://picsum.photos/1920/1080',
                review: ''
            },
            imageFile: null,
            imageFileUrl: null,
        }
    },

    validations() {
        return {
            post: {
                title: { required },
                photoUrl: { required },
                review: { required },
            }
        }
    },

    computed: {
        ...mapGetters('posts', ['getPostById']),
        ...mapState('posts', ['posts']),
    },

    components: {
        Button,
        FormInput,
    },

    methods: {
        ...mapActions('posts', ['updatePost', 'getPosts', 'getPostById']),

        async edit() {
            this.v$.$validate()
            if (this.v$.$errors.length == 0) {
                await this.updatePost(this.post)
                this.$router.push(`/trips/${this.$route.params.tripId}/posts/${this.$route.params.postId}`)
            }
        },

        chooseImage() {
            this.$refs.fileInput.click()
        },

        handleImageChosen(e) {
            const files = e.target.files
            if (files[0] !== undefined) {
                if (files[0].name.lastIndexOf('.') <= 0) {
                    return
                }
                const fr = new FileReader();

                fr.readAsDataURL(files[0]);

                fr.addEventListener('load', () => {
                    this.imageFileUrl = files[0].name; // For DOM display purpose.
                    this.imageFile = files[0]; // To be sent to server.
                });
            }
        },
    },
    async created() {
        await this.getPosts()
        this.post = await this.getPostById(this.$route.params.postId)
    },
}


</script>
<template>
    <div class="trip-create-wrapper">
        <div class="header">
            <h1>Post edit</h1>
            <Button text="Edit" @click="edit" />
        </div>
        <FormInput v-model="post.title" id="title" label="Post title" type="text" placeholder="Post title" />
        <div style="padding: 12px;">
            <label class="label" for="photoUrl">Post photo</label>
            <input ref="fileInput" @change="handleImageChosen" id="photoUrl" label="Post photo" type="file"
                placeholder="Trip cover photo" />
            <div class="image-dropzone" @click="chooseImage">
                <p>Click to Upload</p>
                <p>{{ this.imageFileUrl }}</p>
            </div>
        </div>
        <FormInput v-model="post.review" id="review" label="Post review" type="textarea" placeholder="Post review"
            rows="10" />
    </div>
</template>

<style scoped>
.trip-create-wrapper {
    border-radius: var(--border-radius-default);
    padding: 12px;
}

.label {
    margin-right: 24px;
    margin-bottom: 12px;
    vertical-align: middle;
}

.header {
    display: flex;
    justify-content: space-between;
    padding: 12px;
}

.form-wrapper {
    display: flex;
}

.small-inputs {
    width: 50%;
}

h1 {
    color: var(--purple);
    font-size: 3rem;
    margin-bottom: 12px;
}

.image-wrapper {
    height: 100%;
}

.image-dropzone {
    border: 3px dashed var(--purple);
    border-radius: 10px;
    cursor: pointer;
    padding: 12px;
    margin-top: 12px;
    display: flex;
    justify-content: space-between;
}

input[type="file"] {
    display: none;
}

.uploaded-image {
    max-height: 50%;
    max-width: 50%;
}
</style>