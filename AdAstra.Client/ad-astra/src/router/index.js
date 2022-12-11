import { createRouter, createWebHistory } from "vue-router";

import WelcomeArea from '../components/WelcomeArea.vue'
import Posts from '../views/Posts.vue'
import Trips from '../views/Trips.vue'
import PostDetailed from '../views/PostDetailed.vue'
import UserTrips from '../views/UserTrips.vue'
import TripCreate from '../components/TripCreate.vue'
import TripEdit from '../components/TripEdit.vue'
import MyTripPosts from '../views/MyTripPosts.vue'
import PostCreate from '../components/PostCreate.vue'
import PostEdit from '../components/PostEdit.vue'

import store from '../auth-store';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/trips/:tripId/posts',
      name: 'Trip',
      component: Posts
    },
    {
      path: '/my-trips/:tripId/posts',
      name: 'MyTripPosts',
      component: MyTripPosts,
      beforeEnter: (to, from) => {
        if (!store.state.isAuthenticated) {
          return { name: 'WelcomeArea' }
        }
        return true
      }
    },
    {
      path: '/my-trips',
      name: 'UserTrips',
      component: UserTrips,
      beforeEnter: (to, from) => {
        if (!store.state.isAuthenticated) {
          return { name: 'WelcomeArea' }
        }
        return true
      }
    },
    {
      path: '/trips/:tripId/posts/:postId',
      name: 'Post',
      component: PostDetailed
    },
    {
      path: '/',
      component: WelcomeArea,
      name: 'WelcomeArea'
    },
    {
      path: '/trips',
      component: Trips,
      name: 'Trips'
    },
    {
      path: '/trips/create',
      component: TripCreate,
      beforeEnter: (to, from) => {
        if (!store.state.isAuthenticated) {
          return { name: 'WelcomeArea' }
        }
        return true
      }
    },
    {
      path: '/my-trips/:tripId/posts/create',
      component: PostCreate,
      name: 'CreatePost',
      beforeEnter: (to, from) => {
        if (!store.state.isAuthenticated) {
          return { name: 'WelcomeArea' }
        }
        return true
      }
    },
    {
      path: '/my-trips/:tripId/posts/:postId/edit',
      component: PostEdit,
      name: 'EditPost',
      beforeEnter: (to, from) => {
        if (!store.state.isAuthenticated) {
          return { name: 'WelcomeArea' }
        }
        return true
      }
    },
    {
      path: '/trips/:tripId/edit',
      component: TripEdit,
      beforeEnter: (to, from) => {
        if (!store.state.isAuthenticated) {
          return { name: 'WelcomeArea' }
        }
        return true
      }
    },
    {
      path: '/posts',
      component: Posts,
      name: 'Posts',
    },
    {
      path: '/:pathMatch(.*)*',
      component: WelcomeArea,
      beforeEnter: (to, from, next) => {
        next({ path: '/', replace: true })
      }
    }
  ],
});

export default router;
