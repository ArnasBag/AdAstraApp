<script>
import UserTrip from '../components/UserTrip.vue'
import Button from '../components/Button.vue'
import TripCreate from '../components/TripCreate.vue'

import { openModal } from 'jenesius-vue-modal'
import { mapState, mapActions } from 'vuex'


export default {
    components: {
        UserTrip,
        Button,
        TripCreate,
    },

    computed: {
        ...mapState('trips', ['trips'])
    },

    methods: {
        ...mapActions('trips', ['getUserTrips']),

        createTrip() {
            openModal(TripCreate)
        }
    },

    async created() {
        await this.getUserTrips()
    }
}

</script>

<template>
    <div class="content">
        <div class="side-nav">
            <router-link to="/trips/create">
                <Button text="Add new trip" />
            </router-link>
        </div>
        <div class="cards">
            <UserTrip v-for="trip in trips" v-bind:key="trip.id" :trip="trip" />
        </div>

    </div>
</template>

<style scoped>
.cards {
    display: flex;
    flex-direction: column;
    width: 60%;
}

.trip-content {
    display: grid;
    grid-template-columns: repeat(1, 1fr);
    grid-column-gap: 24px;
    grid-row-gap: 24px;
    max-width: 1200px;
    width: 100%;
}

.side-nav {
    background-color: #29292b;
    height: 100vh;
    box-shadow: 0 0 11px rgba(33, 33, 33, .2);
    border-radius: 10px;
    margin-top: 32px;
    margin-left: 12px;
    padding: 12px;
    width: 20%;
    display: flex;
    flex-direction: column;
    align-items: center;
}

.content {
    display: flex;
    flex-direction: row;
}

@media only screen and (max-width: 768px) {
    .side-nav {
        display: none;
    }

    .cards {
        width: 100%;
    }
}
</style>