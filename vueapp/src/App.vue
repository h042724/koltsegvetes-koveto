<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link :to="{ name: 'IndexTransactions' }">Transactions</router-link> 
  </nav>
  <router-view/>
</template>

<style>

</style>
