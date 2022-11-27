<script>

export default{
    name: 'Button',
    props: {
        text : String,
    }
}

</script>

<template>
    <button @click="$emit('onClick')" class="btn-hover btn-1">{{text}}</button>
</template>

<style scoped>

.btn-hover {
    width: 200px;
    font-size: 16px;
    font-weight: 600;
    color: #fff;
    cursor: pointer;
    height: 55px;
    text-align:center;
    border: none;
    background-size: 300% 100%;
    margin-top: 30px;
    margin-right: 30px;

    border-radius: 10px;
    moz-transition: all .4s ease-in-out;
    -o-transition: all .4s ease-in-out;
    -webkit-transition: all .4s ease-in-out;
    transition: all .4s ease-in-out;
}

.btn-hover:hover {
    background-position: 100% 0;
    moz-transition: all .4s ease-in-out;
    -o-transition: all .4s ease-in-out;
    -webkit-transition: all .4s ease-in-out;
    transition: all .4s ease-in-out;
}

.btn-1 {
    background-image: linear-gradient(90deg, rgba(104,12,235,1) 0%, rgba(142,91,214,1) 50%, rgba(169,118,240,1) 100%);
}
</style>