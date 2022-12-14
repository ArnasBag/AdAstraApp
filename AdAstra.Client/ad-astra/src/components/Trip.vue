<script>
import Button from './Button.vue'
import axios from 'axios';

export default {
    components: {
        Button,
    },

    data() {
        return {
            user: Object,
        }
    },

    props: {
        trip: {
            type: Object,
            required: true
        }
    },

    async created() {
        await axios.get(`https://localhost:7097/api/users/${this.trip.userId}`)
            .then(response => {
                this.user = response.data
            })
    }
}

</script>

<template>

    <div class="trip">
        <div class="trip-image">
            <img :src="trip.coverUrl" alt="something">
        </div>
        <div class="trip-content">
            <div class="trip-title">
                <router-link :to="{ name: 'Trip', params: { tripId: trip.id } }">
                    <h1 class="trip-header">
                        {{ trip.name }}
                    </h1>
                </router-link>
                <div class="author-info">
                    <h3>{{ this.user.firstName }} {{ this.user.lastName }}</h3>
                    <p>{{ new Date(trip.createdAt).toDateString() }}</p>
                </div>
            </div>
        </div>
    </div>


</template>

<style scoped>
.btn {
    width: auto;
    width: 100px;
}

img {
    border-radius: 10px;
    max-width: 100%;
    max-height: calc(100vh - 200px);
    vertical-align: middle;
    margin: auto
}

.trip-image {
    height: auto;
    display: flex;
    justify-content: center;
}


.trip {
    margin: 32px;
    display: flex;
    flex-direction: column;
    flex-grow: 1;
    padding: 12px;
    border-radius: 10px;
    box-shadow: 0 0 11px rgba(33, 33, 33, .2);
    /* max-height: calc(100vh - 200px); */

}

.author-info {
    height: 32px;
    display: flex;
    flex-direction: column;
}

.trip-title {
    margin-bottom: 24px;

}

hr {
    border-top: 2px solid #8338ec;
}

.trip-title {
    margin-top: 12px;
    display: flex;
    align-items: top;
    justify-content: space-between;
}

.trip-title h3,
p {
    color: #9d9da1
}
</style>