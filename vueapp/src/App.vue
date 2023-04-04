<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <div class="app">
        <Sidebar />
        <router-view />
    </div>
</template>

<script setup>
    import Sidebar from './components/SidebarComponent.vue';
</script>

<style lang="scss">
    :root {
        --primary: #4ade80;
        --grey: #64748b;
        --dark: #1e293b;
        --light: #eee;
        --sidebar-width: 300px;
    }

    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
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
