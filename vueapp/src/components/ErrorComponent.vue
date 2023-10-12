<template>
    <div class="error">
        <span class="material-icons">error</span>
        <b>Error!&nbsp;</b> 
        <router-link :to=routeTo>
            {{ text }}
        </router-link>
    </div>
</template>

<script>
    export default {
        name: "ErrorComponent",
        props: {
            text: {
                type: String,
                default: '',
                required: true
            },

            routeTo: {
                type: String,
                default: '',
                required: false
            }
        },
        components: {},
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
        background-color: #FFE6EE;
        border-radius: 10px;
        display: flex;
        align-items: center;
        margin: 25px 0 15px;
    }
    
</style>