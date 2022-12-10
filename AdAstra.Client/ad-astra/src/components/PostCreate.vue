<script>
import Button from './Button.vue'
import { popModal } from 'jenesius-vue-modal'
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

    props: {
        show: Boolean
    },

    components: {
        Button,
    },
    methods: {
        ...mapActions('posts', ['addPost']),

        create() {
            this.addPost(this.post)
            popModal()
        }
    }
}

</script>

<template>
    <div class="post-create">
        <h2 class="post-create-header">Create new post</h2>

        <form class="post-create-container" @submit.prevent="create">
            <div class="block">
                <label for="name">Post title</label>
                <input id="name" type="text" placeholder="Trip name" v-model="post.title">
            </div>
            <div class="block">
                <label for="description">Post photo url</label>
                <input id="description" type="text" placeholder="Trip description" v-model="post.photoUrl">
            </div>
            <div class="block">
                <label for="location">Post review</label>
                <input id="location" type="text" placeholder="Trip location" v-model="post.review">
            </div>
            <div class="center">
                <Button style="margin: 0" text='Create' />
            </div>
        </form>
    </div>
</template>

<style scoped>
.block {
    margin-bottom: 18px;
}

#cover {
    background-color: white;
}

.center {
    justify-content: center;
    align-items: center;
    text-align: center;
    margin-top: 12px;
}

.post-create {
    width: 400px;
    margin: 16px auto;
    font-size: 16px;
    border-radius: 20px;
}

.post-create-container label {
    color: white;
}

.post-create-container input {
    border-radius: 10px;
}

/* Reset top and bottom margins from certain elements */
.post-create-header,
.post-create p {
    margin-top: 0;
    margin-bottom: 0;
}

.post-create-header {
    background: #8338ec;
    padding: 20px;
    font-size: 1.4em;
    font-weight: normal;
    text-align: center;
    text-transform: uppercase;
    color: #fff;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}

.post-create-container {
    background: #1a1a1c;
    padding: 12px;
    border-bottom-left-radius: 10px;
    border-bottom-right-radius: 10px;
}

/* Every row inside .register-container is defined with p tags */
.post-create p {
    padding: 12px;
}

.post-create input {
    box-sizing: border-box;
    display: block;
    width: 100%;
    border-width: 1px;
    border-style: solid;
    padding: 16px;
    outline: 0;
    font-family: inherit;
    font-size: 0.95em;
}

.post-create input[type="email"],
.post-create input[type="password"] {
    background: #fff;
    border-color: #bbb;
    color: #555;
}

/* Text fields' focus effect */
.post-create input[type="email"]:focus,
.post-create input[type="password"]:focus {
    border-color: #888;
}

.post-create input[type="submit"] {
    background: #8338ec;
    border-color: transparent;
    color: #fff;
    cursor: pointer;
}

.post-create input[type="submit"]:hover {
    background: #17c;
}

/* Buttons' focus effect */
.register input[type="submit"]:focus {
    border-color: #05a;
}
</style>