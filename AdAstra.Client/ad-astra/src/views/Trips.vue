<script>
import Trip from '../components/Trip.vue'

export default {
  components: {
    Trip,
  }
}

</script>

<template>
  <div class="flex-page">
    <div class="side-nav">
      <ul>
        <h1>test</h1>
      </ul>
    </div>
    <div class="content">
      <Trip class="mobile-width"/>
      <Trip class="mobile-width"/>
      <Trip class="mobile-width"/>
      <Trip class="mobile-width"/>
    </div>
</div>
</template>

<style scoped>
html, body{
  overflow: hidden !important;
}
.flex-page {
  display: flex;
  overflow: hidden;
}

.side-nav {
  background: white;
  display: flex;
  flex: 1;
  box-shadow: 0 0 11px rgba(33,33,33,.2); 
  border-radius: 10px;
  position: fixed;
  height: 100%;
  width: 300px;
  z-index: -1;
  padding-top: 96px;
}


.content {
  display: flex;
  flex-direction: column;
  flex: 3;
  margin-left: 312px;
  margin-top: 96px;
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