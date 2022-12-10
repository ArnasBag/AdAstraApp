<script>

export default {
    props: {
        comment: {
            required: true,
            type: Object
        }
    },
    // created() {
    //     console.log(comment)
    // }

}

</script>

<template>
    <div class="comment">
        <div class="comment-header">
            <div class="comment-author">
                <h1 style="color: #8338ec;">{{ comment.user.firstName }} {{ comment.user.lastName }}</h1>
            </div>
        </div>
        <div class="comment-content">
            <p>{{ comment.body }}</p>
        </div>
        <div class="comment-impression">

        </div>
    </div>
</template>

<style scoped>
h1 {
    font-size: 1.5rem;
}

.comment-author {
    display: flex;
    align-items: baseline;
}

.comment-content {
    margin-top: 20px;
}

.comment {
    margin-top: 30px;
    border-radius: 10px;
    padding: 20px;
    box-shadow: 0 3px 10px rgb(0 0 0 / 0.2);
    background-color: #2d2d30;
}
</style>