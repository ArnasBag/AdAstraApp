<script>
import Button from './Button.vue'
import FormInput from './FormInput.vue'
import { mapActions } from 'vuex';
import { useVuelidate } from '@vuelidate/core'
import { required } from '@vuelidate/validators'
export default {
  setup() {
    return {
      v$: useVuelidate()
    }
  },

  data() {
    return {
      trip: {
        name: '',
        description: '',
        location: '',
        coverUrl: 'https://picsum.photos/1920/1080',
        startDate: '',
        endDate: ''
      },
      imageFile: null,
      imageFileUrl: null,
    }
  },

  validations() {
    return {
      trip: {
        name: { required },
        description: { required },
        location: { required },
        coverUrl: { required },
        startDate: { required },
        endDate: { required }
      }
    }
  },

  components: {
    Button,
    FormInput,
  },

  methods: {
    ...mapActions('trips', ['addTrip']),

    async create() {
      this.v$.$validate()
      if (this.v$.$errors.length == 0) {
        await this.addTrip(this.trip)
        this.$router.push('/my-trips')
      }
    },

    chooseImage() {
      this.$refs.fileInput.click()
    },

    handleImageChosen(e) {
      const files = e.target.files
      if (files[0] !== undefined) {
        if (files[0].name.lastIndexOf('.') <= 0) {
          return
        }
        const fr = new FileReader();

        fr.readAsDataURL(files[0]);

        fr.addEventListener('load', () => {
          this.imageFileUrl = files[0].name; // For DOM display purpose.
          this.imageFile = files[0]; // To be sent to server.
        });
      }
    },
  }
}


</script>
<template>
  <div class="trip-create-wrapper">
    <div class="header">
      <h1>Trip creation</h1>
      <Button text="Create" @click="create" />
    </div>
    <div class="form-wrapper">
      <div class="small-inputs">
        <FormInput v-model="trip.name" id="name" label="Trip name" type="text" placeholder="Trip name" />
        <FormInput v-model="trip.location" id="location" label="Trip location" type="text"
          placeholder="Trip location" />
        <FormInput v-model="trip.startDate" id="startDate" label="From" type="date" placeholder="Trip start date" />
        <FormInput v-model="trip.endDate" id="endDate" label="To" type="date" placeholder="Trip end date" />
      </div>
      <div style="width: 50%; max-height: calc(100vh - 200px);">
        <FormInput v-model="trip.description" id="description" label="Trip description" type="textarea"
          placeholder="Trip description" rows="10" />
        <div style="padding: 12px;">
          <label class="label" for="coverUrl">Trip cover photo</label>
          <input ref="fileInput" @change="handleImageChosen" id="coverUrl" label="Trip cover" type="file"
            placeholder="Trip cover photo" />
          <div class="image-dropzone" @click="chooseImage">
            <p>Click to Upload</p>
            <p>{{ this.imageFileUrl }}</p>
          </div>
        </div>
      </div>


    </div>
  </div>
</template>

<style scoped>
.trip-create-wrapper {
  border-radius: var(--border-radius-default);
  padding: 12px;
}

.label {
  margin-right: 24px;
  margin-bottom: 12px;
  vertical-align: middle;
}

.header {
  display: flex;
  justify-content: space-between;
  padding: 12px;
}

.form-wrapper {
  display: flex;
}

.small-inputs {
  width: 50%;
}

h1 {
  color: var(--purple);
  font-size: 3rem;
  margin-bottom: 12px;
}

.image-wrapper {
  height: 100%;
}

.image-dropzone {
  border: 3px dashed var(--purple);
  border-radius: 10px;
  cursor: pointer;
  padding: 12px;
  margin-top: 12px;
  display: flex;
  justify-content: space-between;
}

input[type="file"] {
  display: none;
}

.uploaded-image {
  max-height: 50%;
  max-width: 50%;
}
</style>