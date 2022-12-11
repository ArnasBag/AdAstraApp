<script>
import { popModal } from 'jenesius-vue-modal';
import { mapActions } from 'vuex'
import Button from './Button.vue'

export default {
    components: {
        Button,
    },

    props: {
        tripId: Number,
    },

    methods: {
        ...mapActions('trips', ['deleteTrip']),

        popModal() {
            popModal()
        },

        deleteT() {
            console.log(this.tripId)
            this.deleteTrip(this.tripId)
            popModal()
        }
    }
}

</script>

<template>
    <div class="confirmation-modal">
        <div>
            <h1>Are you sure you want to delete this trip?</h1>

        </div>
        <div class="btns">
            <Button @click="deleteT" text="Yes" />
            <Button @click="popModal" text="No" />
        </div>

    </div>

</template>

<style scoped>
.btns {
    display: flex;
    justify-content: space-between;
}

.confirmation-modal {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    width: 40%;
    height: 40%;
    background-color: #1a1a1c;
    padding: 24px;
    border-radius: 10px;

}
</style>