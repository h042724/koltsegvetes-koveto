<template>
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App" />
    <IndexExpenses/>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue';
import IndexExpenses from './components/Expenses/Index.vue';
import CreateExpenses from './components/Expenses/Create.vue';
import EditExpenses from './components/Expenses/Edit.vue';
import DetailsExpenses from './components/Expenses/Details.vue';
import DeleteExpenses from './components/Expenses/Delete.vue';

export default {
  name: 'App',
  components: {
      HelloWorld,
      IndexExpenses,
      CreateExpenses,
      EditExpenses,
      DetailsExpenses,
      DeleteExpenses,
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
