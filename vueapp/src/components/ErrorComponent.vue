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
        font-size: 1.4rem;
        margin: 0 5px 0 5px;
        color: red;
    }

    .error {
        font-size: 1em;
        color: red;
        background-color: lightpink;
        border-radius: 10px;
        display: flex;
        align-items: center;
        margin: 25px 0 15px;
    }
    
</style>