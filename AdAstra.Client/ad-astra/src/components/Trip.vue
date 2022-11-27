<script>

export default {

}

</script>

<template>
<div class="trip">
  <div class="header-container">
      <div class="header-user">
          <i class="fa-regular fa-circle-user fa-2xl" />
      </div>
      <div class="author-info">
          <h3>John Johnson</h3>
          <p>Nov 27</p>
      </div>
  </div>
  <div class="trip-content">
      <div class="trip-title">
          <h1 class="trip-header">My test trip 1</h1>
          <div class="trip-meta">
              <div>
                  <i class="align fa-solid fa-calendar-days"></i>
                  <p class="align-p">2022/01/01 - 2022/01/05</p>
              </div>
              <div>
                  <i class="align fa-solid fa-location-dot"></i>
                  <p class="align-p">Kaunas, Lithuania</p>
              </div>
          </div>
      </div>

      <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam</p>
  </div>
  <div class="trip-impressions">
      <div class="trip-impression">
          <i class="align fa-solid fa-heart fa-xl"></i>
          <p class="align-p">6,4k likes</p>
      </div>
      <div class="trip-impression">
          <i class="align fa-solid fa-comment fa-xl"></i>
          <p class="align-p">100 comments</p>
      </div>
  </div>
</div>
</template>

<style scoped>
  .header-container{
      margin-bottom: 32px;
      display: flex;
      justify-content: space-between;
  }
  .trip{
      width: 65%;
      padding: 64px;
      background-color: white;
      border-radius: 10px;
      box-shadow: 0 0 11px rgba(33,33,33,.2); 
      margin: 24px;
  }
  .trip-header{
      color: #8338ec;
      font-size: 3rem;
      font-weight: lighter;
  }
  .author-info{
      height: 32px;
      display: flex;
      flex-direction: column;
  }
  .trip-content{
      margin-bottom: 16px;
  }
  .trip-impression{
      display: inline-block;
  }
  .align{
      display: inline-block;
      vertical-align: middle;
  }
  .align-p{
      margin-left: 8px;
      display: inline-block;
      vertical-align: middle;
  }
  .trip-impressions{
      display: flex;
      justify-content: space-between;
  }
  .trip-title{
      margin-bottom: 24px;

  }
  .trip-meta{
      display: flex;
      justify-content: space-between;
  }
  hr{
      border-top: 2px solid #8338ec;
  }
</style>