<template>
    <div class="error">
        <span class="material-icons">error</span>
        <b>Error!&nbsp;</b> {{error}}
    </div>
</template>

<script>
    export default {
        name: "ErrorComponent",
        props: ['error']
    }
</script>

<style scoped>
    .material-icons {
        font-size: 2rem;
        color: red;
    }

    .error {
        font-size: 25px;
        color: red;
        background-color: lightpink;
        border-radius: 10px;
        display: flex;
        align-items: center;
    }
    
</style>