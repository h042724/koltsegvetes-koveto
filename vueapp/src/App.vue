<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat&display=swap" rel="stylesheet">
    <div class="app">
        <Sidebar />
        <router-view />
    </div>
</template>

<script>
    import Sidebar from './components/SidebarComponent.vue';

    export default {
        components: {
            Sidebar
        },
    }
</script>

<style lang="scss">
    :root {
        --primary: #9fc5e8;
        --grey: #64748b;
        --dark: #222222;
        --dark-alt: #171717;
        --light: #eee;
        --sidebar-width: 300px;
    }

    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: 'Montserrat', sans-serif;
    }

    body {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        background: var(--light);
    }

    .app {
        display: flex;

        main {
            flex: 1 1 0;
            padding: 2rem;

            @media (max-width: 768px) {
                padding-left: 6rem;
            }
        }
    }
</style>
