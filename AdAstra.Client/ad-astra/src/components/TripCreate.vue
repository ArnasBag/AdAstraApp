<script>
import Button from './Button.vue'
import { mapActions } from 'vuex';
import { routerKey } from 'vue-router';

export default {
  data() {
    return {
      trip: {
        name: '',
        description: '',
        location: '',
        coverUrl: 'https://picsum.photos/1920/1080',
        startDate: '',
        endDate: ''
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
    ...mapActions('trips', ['addTrip']),

    create() {
      this.addTrip(this.trip)
      this.$router.push('/my-trips')
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
            <FormKit v-model="trip.name" label="Trip name" type="text" validation="required"
              placeholder="Write a name for your trip" />
            <FormKit v-model="trip.location" label="Trip location" type="text" validation="required"
              placeholder="Write a location for your trip" />
            <FormKit v-model="trip.startDate" label="Trip starting date" type="date" validation="required"
              placeholder="Write a starting date for your trip" />
            <FormKit v-model="trip.endDate" label="Trip ending date" type="date" validation="required"
              placeholder="Write an ending date for your trip" />

          </div>
          <div class="form-image-input">
            <FormKit type="group" :config="{
              classes: {
                input: 'non-resize'
              }
            }">
              <FormKit v-model="trip.description" rows="10" cols="100" label="Trip description" type="textarea"
                validation="required" placeholder="Write a description for your trip" />
            </FormKit>
            <FormKit label="Trip cover photo" type="file" placeholder="Pick a cover photo for your trip" />
          </div>
        </div>
      </FormKit>
    </div>
    <div class="submit-form">
      <Button @click="create" text="Create new trip" />
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