import { createRouter, createWebHistory } from "vue-router";

import WelcomeArea from '../components/WelcomeArea.vue'
import Trips from '../views/Trips.vue'
import Posts from '../views/Posts.vue'
import TripDetailed from '../views/TripDetailed.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
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
    {
      path: '/posts/1',
      component: TripDetailed
    }
  ],
});

export default router;
