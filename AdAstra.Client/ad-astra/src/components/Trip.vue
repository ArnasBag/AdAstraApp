<script>

export default {

}

</script>

<template>
    <div class="trip">
        <div class="header-container">
            <div class="header-user">
                <i class="fa-regular fa-circle-user fa-2xl" />
            </div>
            <div class="author-info">
                <h3>John Johnson</h3>
                <p>Nov 27</p>
            </div>
        </div>
        <div class="trip-content">
            <div class="trip-title">
                <h1 class="trip-header">My test trip 1</h1>
                <div class="trip-meta">
                    <div>
                        <i class="align fa-solid fa-location-dot"></i>
                        <p class="align-p">Kaunas, Lithuania</p>
                    </div>
                </div>
            </div>
            <div class="image-area">
                <img class="trip-img" src="https://picsum.photos/1920/1800" alt="something">
            </div>
            <div class="trip-impressions">
                <div class="trip-impression">
                    <i class="align fa-solid fa-heart fa-xl"></i>
                    <p class="align-p">6,4k likes</p>
                </div>
                <div class="trip-impression">
                    <i class="align fa-solid fa-comment fa-xl"></i>
                    <p class="align-p">100 comments</p>
                </div>
            </div>
        </div>

    </div>
</template>

<style scoped>
.trip-img {
    max-height: calc(100vh - 100px);
    max-width: 100%;
    border-radius: 10px;
}

.image-area {
    margin-top: 32px;
    margin-bottom: 32px;
    display: flex;
    justify-content: center;
    background-color: #29292b;
    flex-grow: 1;
    max-height: 100%;
    border-radius: 10px;
}

.header-container {
    margin-bottom: 32px;
    display: flex;
    justify-content: space-between;
}

.trip {
    display: flex;
    flex-direction: column;
    width: 100%;
    padding: 32px;
    background-color: #2d2d30;
    ;
    border-radius: 10px;
    box-shadow: 0 0 11px rgba(33, 33, 33, .2);
}

.trip-header {
    color: #8338ec;
    font-size: 3rem;
    font-weight: lighter;
}

.author-info {
    height: 32px;
    display: flex;
    flex-direction: column;
}

.trip-content {
    display: flex;
    flex-direction: column;
    margin-bottom: 16px;
    flex-grow: 1;
    justify-content: space-between;
}

.trip-impression {
    display: inline-block;
}

.align {
    display: inline-block;
    vertical-align: middle;
}

.align-p {
    margin-left: 8px;
    display: inline-block;
    vertical-align: middle;
}

.trip-impressions {
    display: flex;
    justify-content: space-between;
}

.trip-title {
    margin-bottom: 24px;

}

.trip-meta {
    display: flex;
    justify-content: space-between;
}

hr {
    border-top: 2px solid #8338ec;
}
</style>