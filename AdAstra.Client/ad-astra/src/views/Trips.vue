<script>
import Trip from '../components/Trip.vue'
import Button from '../components/Button.vue'
import TripCreate from '../components/TripCreate.vue'

export default {
  components: {
    Trip,
    Button,
    TripCreate,
  },
  data() {
        return {
            showTripCreate: false,
        }
    }
}

</script>

<template>
  <div class="content">
    <div class="side-nav">
      <Button @on-click="showTripCreate = true" text="Add new trip"/>
      <Teleport to="body">
          <TripCreate :show="showTripCreate" @close="showTripCreate = false">

          </TripCreate>
      </Teleport>
    </div>
    <div class="trip-content">
      <Trip class="trip"/>
    </div>

  </div>
</template>

<style scoped>
.trip-content{
  flex: 1 1 80%;
  margin-right: 32px;
}
.side-nav{
  box-shadow: 0 0 11px rgba(33,33,33,.2); 
  border-radius: 10px;
  margin: 12px;
  padding: 12px;
  flex: 1 1 20%
}
.trip{
  margin: 12px;
}
.content {
  margin-top: 96px;
  display: flex;
}

@media only screen and (max-width: 768px) {
  .side-nav{
    display: none;
  }
  .content{
    margin-left: 0px;
  }
  .mobile-width{
    width: 100%;
  }
}

</style>