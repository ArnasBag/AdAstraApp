<script>
import Button from './Button.vue'
export default{
    props: {
        show: Boolean
    },
    components: {
        Button
    }
}
</script>

<template>
    <Transition name="login">
        <div v-if="show" class="modal-mask">
            <div class="login">         
                <h2 class="login-header">Log in</h2>

                <form class="login-container">
                    <p><input type="email" placeholder="Email"></p>
                    <p><input type="password" placeholder="Password"></p>
                    <div class="center">
                        <Button style="margin: 0" text='Log in'/>
                    </div>
                </form>
            </div>               
        </div>
    </Transition>
</template>

<style scoped>

.center{
    justify-content: center;
    align-items: center;
    text-align: center;
}

.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.7);
  display: flex;
  transition: opacity 0.1s ease;
  justify-content: center;
  align-items: center;
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
  background: white;
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