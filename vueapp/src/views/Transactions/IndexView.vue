<template>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />    
    <main id="index">
        <h1>Transactions index</h1>
        <button @click="fetchUser">Fetch User</button>
        <p v-if="user">Hello, {{ user }}</p>
        <div id="transactions-add-router">
            <button class="transaction-button">
                <span class="material-symbols-outlined">add_circle</span>
            </button>
            <div class="dropdown-content">
                <router-link :to="{ name: 'CreateTransactions', params: { type: 'expense'}}">Add New Expense</router-link>
                <router-link :to="{ name: 'CreateTransactions', params: { type: 'income'}}">Add New Income</router-link>
            </div>
        </div>
        <div v-if="loading" class="loading"></div>
        <div v-if="transactions" id="index-transactions" class="transactions-body">
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Amount ($)</th>
                        <th>Transaction date</th>
                        <th>Category</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in transactions" :key="item.id" v-bind:class="(item.amount < 0) ? 'expense' : 'income'">
                        <td>{{ item.name }}</td>
                        <td>{{ item.amount }}</td>
                        <td>{{ item.transactionDate }}</td>
                        <td>
                            <span class="material-symbols-outlined">{{ item.referencedCategory.iconName }}</span>
                            {{ item.referencedCategory.name }}
                        </td>
                        <td>
                            <router-link :to="{ name: 'EditTransactions', params: { id: item.id, type: item.amount < 0 ? 'expense' : 'income'}}">
                                <span class="material-symbols-outlined">edit</span>
                            </router-link>
                            <router-link :to="{ name: 'DetailsTransactions', params: { id: item.id}}">
                                <span class="material-symbols-outlined">library_books</span>
                            </router-link>
                            <router-link :to="{ name: 'DeleteTransactions', params: { id: item.id}}">
                                <span class="material-symbols-outlined">delete</span>
                            </router-link>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </main>
</template>

<script>
    const uri = 'https://localhost:7007/transactions';

    export default {
        name: 'IndexView',
        components: {},
        data() {
            return {
                loading: false,
                transactions: null,
                category: null,
                user: null
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            async fetchData() {
                this.transactions = null;
                this.loading = true;

                await fetch(`${uri}`, {
                    method: 'GET',
                    mode: 'cors',
                    headers: {
                        'Access-Control-Allow-Origin': 'https://localhost:7007',
                        'Access-Control-Allow-Credentials': 'true'
                    }
                }).then(r => r.json())
                  .then(json => {
                      this.transactions = json;
                      this.loading = false;
                      return
                  });
            },

            async fetchUser() {
                this.user = null;

                await fetch('https://localhost:7007/Login/getUser', {
                    method: 'POST',
                    mode: 'cors',
                    headers: {
                        'Access-Control-Allow-Origin': 'https://localhost:7007',
                        'Access-Control-Allow-Credentials': 'true'
                    }
                }).then(r => r.json())
                    .then(json => {
                        this.user = json;
                        return
                    })
                    .catch(err => console.log(err));
            }
        },
    }
</script>

<style lang="scss" scoped>
    @import '../../assets/css/transactions.css';
</style>