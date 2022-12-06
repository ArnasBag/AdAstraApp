<script>

export default {

}

</script>

<template>
    <div class="comment">
        <div class="comment-header">
            <div class="comment-author">
                <i class="fa-regular fa-circle-user fa-2xl" />
                <div style="display: flex; align-items: baseline; margin-left:15px;">
                    <h1 style="color: #8338ec;">John Johnson</h1>
                    <!-- <h3>30 minutes ago</h3> -->
                </div>
            </div>
        </div>
        <div class="comment-content">
            <p>Lorem ipsum odfhjsiaofhdisoahflsdhafjdk.</p>
        </div>
        <div class="comment-impression">

        </div>
    </div>
</template>

<style scoped>
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