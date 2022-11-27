import { createRouter, createWebHistory } from "vue-router";

import WelcomeArea from '../components/WelcomeArea.vue'
import Trips from '../views/Trips.vue'
import Posts from '../views/Posts.vue'

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
    }
  ],
});

export default router;
