<script>
import Button from './Button.vue'
import { mapState } from 'vuex'

import { popModal } from 'jenesius-vue-modal'

export default {
  data() {
    return {
      user: {
        email: '',
        password: ''
      }
    }
  },

  props: {
    show: Boolean
  },

  components: {
    Button
  },

  computed: {
    ...mapState({
      isAuthenticated: state => state.authentication.isAuthenticated,
    }),
  },

  methods: {
    login() {
      this.$store.dispatch('auth/login', this.user);
      popModal();
      this.$router.push('/trips');
    },
  },

}
</script>

<template>
  <div class="login">
    <h2 class="login-header">Log in</h2>
    <form @submit.prevent="login" class="login-container">
      <p><input v-model="user.email" type="email" placeholder="Email"></p>
      <p><input v-model="user.password" type="password" placeholder="Password"></p>
      <div class="center">
        <Button style="margin: 0" text='Log in' />
      </div>
    </form>
  </div>
</template>

<style scoped>
.center {
  justify-content: center;
  align-items: center;
  text-align: center;
}

.login {
  width: 400px;
  margin: 16px auto;
  font-size: 16px;
  border-radius: 20px;

}

/* Reset top and bottom margins from certain elements */
.login-header,
.login p {
  margin-top: 0;
  margin-bottom: 0;
}

.login-header {
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

.login-container {
  background: #1a1a1c;
  padding: 12px;
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
}

/* Every row inside .login-container is defined with p tags */
.login p {
  padding: 12px;
}

.login input {
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

.login input[type="email"],
.login input[type="password"] {
  background: #fff;
  border-color: #bbb;
  color: #555;
  border-radius: 10px;
}

/* Text fields' focus effect */
.login input[type="email"]:focus,
.login input[type="password"]:focus {
  border-color: #888;
}

.login input[type="submit"] {
  background: #8338ec;
  border-color: transparent;
  color: #fff;
  cursor: pointer;
}

.login input[type="submit"]:hover {
  background: #17c;
}

/* Buttons' focus effect */
.login input[type="submit"]:focus {
  border-color: #05a;
}
</style>