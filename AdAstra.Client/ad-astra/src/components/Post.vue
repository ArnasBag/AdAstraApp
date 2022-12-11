<script>

export default {
  props: {
    postData: {
      type: Object,
      required: true
    }
  }
}

</script>

<template>
  <router-link class="card" :to="{ name: 'Post', params: { tripId: this.$route.params.tripId, postId: postData.id } }">
    <div class="card-background" :style="{ 'background-image': 'url(' + postData.photoUrl + ')' }"></div>
    <div class=" card-content">
      <p class="card-category">Category</p>
      <h3 class="card-heading">{{ postData.title }}</h3>
    </div>
  </router-link>
</template>

<style scoped>
.card {
  list-style: none;
  position: relative;
  z-index: 0;
}

.card:before {
  content: '';
  display: block;
  padding-bottom: 150%;
  width: 100%;
}

.card-background {
  background-size: cover;
  background-position: center;
  border-radius: 10px;
  bottom: 0;
  filter: brightness(0.75) saturate(1.2) contrast(0.85);
  left: 0;
  position: absolute;
  right: 0;
  top: 0;
  transform-origin: center;
  transform: scale(1) translateZ(0);
  transition:
    filter 200ms linear,
    transform 200ms linear;
  z-index: 0;
}

.card:hover .card-background {
  transform: scale(1.05) translateZ(0);
}

.card-content {
  left: 0;
  padding: 24px;
  position: absolute;
  top: 0;
}

.card-category {
  color: rgba(255, 255, 255, 0.6);
  font-size: 0.9rem;
  margin-bottom: 8px;
  text-transform: uppercase;
}

.card-heading {
  color: rgba(255, 255, 255, 0.9);
  font-size: 1.9rem;
  text-shadow: 2px 2px 20px rgba(0, 0, 0, 0.2);
  line-height: 1.4;
  word-spacing: 100vw;
}
</style>