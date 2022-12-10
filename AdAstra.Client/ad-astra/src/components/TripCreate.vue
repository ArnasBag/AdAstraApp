<script>
import Button from './Button.vue'
import { popModal } from 'jenesius-vue-modal'
import { mapActions } from 'vuex';

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
      popModal()
    }
  }
}

</script>

<template>
  <div class="trip-create">
    <h2 class="trip-create-header">Create new trip</h2>

    <form class="trip-create-container" @submit.prevent="create">
      <div class="block">
        <label for="name">Trip name</label>
        <input id="name" type="text" placeholder="Trip name" v-model="trip.name">
      </div>
      <div class="block">
        <label for="description">Trip description</label>
        <input id="description" type="text" placeholder="Trip description" v-model="trip.description">
      </div>
      <div class="block">
        <label for="location">Trip location</label>
        <input id="location" type="text" placeholder="Trip location" v-model="trip.location">
      </div>
      <div class="block">
        <label for="cover">Cover photo</label>
        <input id="cover" type="file">
      </div>
      <div class="block">
        <label for="startDate">Start date</label>
        <input id="startDate" type="date" v-model="trip.startDate">
      </div>
      <div class="block">
        <label for="endDate">End date</label>
        <input id="endDate" type="date" v-model="trip.endDate">
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

.trip-create {
  width: 400px;
  margin: 16px auto;
  font-size: 16px;
  border-radius: 20px;
}

.trip-create-container label {
  color: white;
}

.trip-create-container input {
  border-radius: 10px;
}

/* Reset top and bottom margins from certain elements */
.trip-create-header,
.trip-create p {
  margin-top: 0;
  margin-bottom: 0;
}

.trip-create-header {
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

.trip-create-container {
  background: #1a1a1c;
  padding: 12px;
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
}

/* Every row inside .register-container is defined with p tags */
.trip-create p {
  padding: 12px;
}

.trip-create input {
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

.trip-create input[type="email"],
.trip-create input[type="password"] {
  background: #fff;
  border-color: #bbb;
  color: #555;
}

/* Text fields' focus effect */
.trip-create input[type="email"]:focus,
.trip-create input[type="password"]:focus {
  border-color: #888;
}

.trip-create input[type="submit"] {
  background: #8338ec;
  border-color: transparent;
  color: #fff;
  cursor: pointer;
}

.trip-create input[type="submit"]:hover {
  background: #17c;
}

/* Buttons' focus effect */
.register input[type="submit"]:focus {
  border-color: #05a;
}
</style>