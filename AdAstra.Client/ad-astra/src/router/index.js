import { createRouter, createWebHistory } from "vue-router";

import WelcomeArea from '../components/WelcomeArea.vue'
import Trips from '../views/Trips.vue'
import Posts from '../views/Posts.vue'
import PostDetailed from '../views/PostDetailed.vue'
import UserTrips from '../views/UserTrips.vue'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/trips/:tripId/posts',
      name: 'Trip',
      component: Posts
    },
    {
      path: '/my-trips',
      name: 'UserTrips',
      component: UserTrips
    },
    {
      path: '/trips/:tripId/posts/:postId',
      name: 'Post',
      component: PostDetailed
    },
    {
      path: '/',
      component: WelcomeArea
    },
    {
      path: '/trips',
      component: Trips
    },
    {
      path: '/posts',
      component: Posts
    },
  ],
});

export default router;
