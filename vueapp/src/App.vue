<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link :to="{ name: 'About' }">About</router-link> | 
    <router-link :to="{ name: 'IndexExpenses' }">Expenses</router-link> 
  </nav>
  <router-view/>
</template>

<style>

</style>
