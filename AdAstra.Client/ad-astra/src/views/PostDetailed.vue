<script>
import Trip from '../components/Trip.vue'
import Button from '../components/Button.vue'
import TripCreate from '../components/TripCreate.vue'
import Comments from '../components/Comments.vue'

import axios from 'axios';
import { Comment } from 'vue';

export default {
    components: {
        Trip,
        Button,
        TripCreate,
        Comments,
        Comment
    },
    data() {
        return {
            post: {
                type: Object,
            }
        }

    },
    created() {
        axios.get('https://localhost:7097/api/trips/' + this.$route.params.tripId + '/posts/' + this.$route.params.postId)
            .then(response => {
                this.post = response.data;
                console.log(response.data)
            })
            .catch(error => {
                console.error(error);
            });
    },
}

</script>

<template>
    <div class="page">
        <div class="sidebar">
            <Button @on-click="showTripCreate = true" text="Edit post" />
            <Button @on-click="showTripCreate = true" text="Delete post" />
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
                    <h3>Description</h3>
                    <p>{{ post.description }}</p>
                </div>
                <div class="comments">
                    <Comments v-for="comment in post.comments" v-bind:key="comment.id" :comment="comment" />

                </div>

            </div>
        </div>
    </div>



</template>

<style scoped>
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
    height: 100vh;
    width: 60%;
}

.header {
    width: 100%;
    background-color: #29292b;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}

.image-area {
    display: flex;
    justify-content: center;
    background-color: #29292b;
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
    background-color: #29292b;
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