<script>
import Post from '../components/Post.vue'

export default {
    components: {
        Post,
    }
}

</script>

<template>
<section class="hero-section">
    <div class="card-grid">
        <Post></Post>
        <Post></Post>
        <Post></Post>
        <Post></Post>

    </div>
</section>
</template>

<style scoped>
.hero-section{
  align-items: flex-start;
  display: flex;
  min-height: 100%;
  justify-content: center;
  padding: 64px 24px;
  background-color: #2d2d30;
  margin-left: 5%;
  margin-right: 5%;
  border-radius: 10px;
  margin-top: 80px;
}

.card-grid{
  display: grid;
  grid-template-columns: repeat(1, 1fr);
  grid-column-gap: 24px;
  grid-row-gap: 24px;
  max-width: 1200px;
  width: 100%;
}

@media(min-width: 540px){
  .card-grid{
    grid-template-columns: repeat(2, 1fr); 
  }
}

@media(min-width: 960px){
  .card-grid{
    grid-template-columns: repeat(4, 1fr); 
  }
}
</style>