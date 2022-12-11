<script>
import { popModal } from 'jenesius-vue-modal';
import { mapActions } from 'vuex'
import Button from './Button.vue'

export default {
    components: {
        Button,
    },

    props: {
        postId: Number,
    },

    methods: {
        ...mapActions('posts', ['deletePost']),

        popModal() {
            popModal()
        },

        async deleteP() {
            await this.deletePost(this.postId)
            popModal()
            this.$router.push('/trips/2/posts')
        }
    }
}

</script>

<template>
    <div class="confirmation-modal">
        <div>
            <h1>Are you sure you want to delete this post?</h1>

        </div>
        <div class="btns">
            <Button @click="deleteP" text="Yes" />
            <Button @click="popModal" text="No" />
        </div>

    </div>

</template>

<style scoped>
.btns {
    display: flex;
    justify-content: space-between;
}

.confirmation-modal {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    width: 40%;
    height: 40%;
    background-color: #1a1a1c;
    padding: 24px;
    border-radius: 10px;

}
</style>