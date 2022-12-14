<script>
import Button from './Button.vue'
import { mapState, mapActions } from 'vuex'
import { popModal } from 'jenesius-vue-modal'
import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'

export default {
  setup() {
    return {
      v$: useVuelidate()
    }
  },

  data() {
    return {
      user: {
        firstName: '',
        lastName: '',
        userName: '',
        email: '',
        password: ''
      }
    }
  },

  validations() {
    return {
      user: {
        firstName: { required },
        lastName: { required },
        userName: { required },
        email: { required, email },
        password: { required }
      }
    }
  },

  components: {
    Button
  },

  computed: {
    ...mapState('auth', ['isAuthenticated']),
  },

  methods: {
    ...mapActions('auth', ['register']),

    async registerUser() {
      this.v$.$validate()
      if (this.v$.$errors.length == 0) {
        await this.register(this.user)
        popModal()
        console.log(this.isAuthenticated)
        this.$router.push('my-trips')
      }
    }
  },
}
</script>

<template>
  <div class="login">
    <h2 class="login-header">Registration</h2>
    <form @submit.prevent="registerUser" class="login-container">
      <p><input v-model="user.firstName" type="text" placeholder="First name"></p>
      <span v-for="error in v$.user.firstName.$errors" style="color: red" v-if="v$.user.firstName.$error">{{
          error.$message
      }}</span>
      <p><input v-model="user.lastName" type="text" placeholder="Last name"></p>
      <span v-for="error in v$.user.lastName.$errors" style="color: red" v-if="v$.user.lastName.$error">{{
          error.$message
      }}</span>
      <p><input v-model="user.userName" type="text" placeholder="Username"></p>
      <span v-for="error in v$.user.userName.$errors" style="color: red" v-if="v$.user.userName.$error">{{
          error.$message
      }}</span>
      <p><input v-model="user.email" type="email" placeholder="Email"></p>
      <span v-for="error in v$.user.email.$errors" style="color: red" v-if="v$.user.email.$error">{{ error.$message
      }}</span>
      <p><input v-model="user.password" type="password" placeholder="Password"></p>
      <span v-for="error in v$.user.password.$errors" style="color: red" v-if="v$.user.password.$error">{{
          error.$message
      }}</span>
      <div class="center">
        <Button style="margin: 0" text='Register' />
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

  border: 5px solid #8338ec;
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
  background: white;
  padding: 12px;
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
}

/* Every row inside .login-container is defined with p tags */
.login p {
  padding: 12px;
}

span {
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
  font-size: 1em;
}

.login input[type="email"],
.login input[type="password"],
.login input[type="text"] {
  background: #fff;
  border-color: #8338ec;
  border: 3px solid #8338ec;
  border-radius: 10px;
  color: black;
}

/* Text fields' focus effect */
.login input[type="email"]:focus,
.login input[type="password"]:focus,
.login input[type="text"]:focus {
  border-color: #8338ec;
}

.login input[type="submit"] {
  background: #8338ec;
  border-color: transparent;
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