<script>
import Trip from '../components/Trip.vue'
import Button from '../components/Button.vue'
import TripCreate from '../components/TripCreate.vue'
import Comments from '../components/Comments.vue'

export default {
    components: {
        Trip,
        Button,
        TripCreate,
        Comments,
    }
}

</script>

<template>
    <div class="main-container">
        <div class="header">
            <div class="image-area">
                <img class="main-image" src="https://picsum.photos/1920/1080" alt="">
            </div>
            <div class="user-info">
                <h1 style="color: #8338ec;">John Johsnon</h1>
            </div>
        </div>
        <div class="content">
            <div class="title">
                <h1>My first ever astronomy photo!</h1>
            </div>
            <div class="description">
                <h3>Description</h3>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc non tincidunt nisi. Nunc semper
                    tristique leo in placerat. Maecenas sit amet purus condimentum, euismod felis eget, interdum purus.
                    Nullam at cursus ex. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
                    inceptos himenaeos. Donec auctor iaculis ante non suscipit. Aliquam semper, sapien a porta rutrum,
                    est nisl laoreet sem, consequat consequat ante tortor in lacus. In ultrices est in nisl porta, vitae
                    convallis felis dictum. Mauris elit turpis, efficitur in dui non, malesuada rutrum erat. Morbi
                    sapien odio, aliquam ac mi non, tristique tincidunt tortor.</p>
            </div>
            <div class="comments">
                <Comments />
                <Comments />
                <Comments />
                <Comments />
            </div>
        </div>

    </div>

</template>

<style scoped>
.comments {
    margin-top: 32px;
    padding: 2%;
    border-radius: 10px;
    background-color: #1a1a1c;
}

.header {
    display: flex;
    height: 100%;
    width: 100%;
}

.main-container {
    max-width: 1500px;
    border-radius: 10px;
    box-shadow: 0 3px 10px rgb(0 0 0 / 0.2);
    background-color: #2d2d30;
    margin-top: 96px;
    margin-left: 5%;
    margin-right: 5%;
    padding: 5%;
    height: 100%;
}

.image-area {
    width: 70%;
}

.main-image {
    border-radius: 10px;
    max-height: 100%;
    max-width: 100%;

}

.user-info {
    margin-left: 20px;
}

.title {
    margin-top: 30px;
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