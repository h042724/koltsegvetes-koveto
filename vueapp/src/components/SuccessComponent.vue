<template>
    <div class="success">
        <span class="material-icons">error</span>
        <b>Success!&nbsp;</b> {{success}}
    </div>
</template>

<script>
    export default {
        name: "SuccessComponent",
        props: ['success']
    }
</script>

<style scoped>
    .material-icons {
        font-size: 2rem;
        color: red;
    }

    .success {
        font-size: 25px;
        color: green;
        background-color: lightgreen;
        border-radius: 10px;
        display: flex;
        align-items: center;
    }
</style>