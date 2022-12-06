<script>
import Button from './Button.vue'

export default {
    props: {
        show: Boolean
    },
    components: {
        Button,
    }
}

</script>

<template>
 <Transition name="trip-create">
        <div v-if="show" class="modal-mask">
            <div class="trip-create">         
                <h2 class="trip-create-header">Create new trip</h2>

                <form class="trip-create-container">
                    <p><input type="email" placeholder="Email"></p>
                    <p><input type="password" placeholder="Password"></p>
                    <div class="center">
                        <Button style="margin: 0" text='Create'/>
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
.trip-create {
  width: 400px;
  margin: 16px auto;
  font-size: 16px;
  border-radius: 20px;

}

/* Reset top and bottom margins from certain elements */
.trip-create-header,
.trip-create p {
  margin-top: 0;
  margin-bottom: 0;
}

.trip-create-header {
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

.trip-create-container {
  background: white;
  padding: 12px;
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
}

/* Every row inside .register-container is defined with p tags */
.trip-create p {
  padding: 12px;
}

.trip-create input {
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

.trip-create input[type="email"],
.trip-create input[type="password"] {
  background: #fff;
  border-color: #bbb;
  color: #555;
}

/* Text fields' focus effect */
.trip-create input[type="email"]:focus,
.trip-create input[type="password"]:focus {
  border-color: #888;
}

.trip-create input[type="submit"] {
  background: #8338ec;
  border-color: transparent;
  color: #fff;
  cursor: pointer;
}

.trip-create input[type="submit"]:hover {
  background: #17c;
}

/* Buttons' focus effect */
.register input[type="submit"]:focus {
  border-color: #05a;
}
</style>