<script>
import Button from './Button.vue'
import { promptModal } from "jenesius-vue-modal"
import DeleteConfirmationModal from './DeleteConfirmationModal.vue'
import TripEdit from '../components/TripEdit.vue'

export default {
    components: {
        Button,
        DeleteConfirmationModal,
        TripEdit,
    },

    props: {
        trip: {
            type: Object,
            required: true
        }
    },

    methods: {
        async deleteTrip() {
            await promptModal(DeleteConfirmationModal, {
                tripId: this.trip.id
            })
        },

        async updateTrip() {
            this.$router.push(`/trips/${this.trip.id}/edit`)
        },
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
                <router-link :to="{ name: 'MyTripPosts', params: { tripId: trip.id } }">
                    <h1 class="trip-header">
                        {{ trip.name }}
                    </h1>
                </router-link>
                <div class="author-info">
                    <h3>John Johnson</h3>
                    <p>{{ new Date(trip.createdAt).toDateString() }}</p>
                </div>
            </div>
            <div style="display: flex; justify-content:space-between;">
                <div>
                    <Button @click="updateTrip" class="btn" text="Edit" />
                </div>
                <div>
                    <Button @click="deleteTrip" class="btn" text="Delete" />
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

.trip-content {
    background-color: #29292b;
}

.trip {
    background-color: #29292b;
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