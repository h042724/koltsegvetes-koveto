<template>
    <main id="index">
        <h1>Transactions index</h1>
        <div id="transactions-add-router">
            <button class="transaction-button">+</button>
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
                        <th>Amount</th>
                        <th>Transaction date</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in transactions" :key="item.id" v-bind:class="(item.amount < 0) ? 'expense' : 'income'">
                        <td>{{ item.name }}</td>
                        <td>{{ item.amount }}</td>
                        <td>{{ item.transactionDate }}</td>
                        <td>
                            <router-link :to="{ name: 'EditTransactions', params: { id: item.id, type: item.amount < 0 ? 'expense' : 'income'}}">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" padding="10px" fill="currentColor" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                                    <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" />
                                </svg>                            </router-link>
                            <router-link :to="{ name: 'DetailsTransactions', params: { id: item.id}}">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" padding="10px" fill="currentColor" class="bi bi-info-circle" viewBox="0 0 16 16">
                                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
                                    <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0z" />
                                </svg>
                            </router-link>
                            <router-link :to="{ name: 'DeleteTransactions', params: { id: item.id}}">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" padding="10px" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                                    <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
                                </svg>
                            </router-link>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </main>
</template>

<script>
    export default {
        name: 'IndexView',
        components: {},
        data() {
            return {
                loading: false,
                transactions: null
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.transactions = null;
                this.loading = true;

                fetch('expenses')
                    .then(r => r.json())
                    .then(json => {
                        this.transactions = json;
                        this.loading = false;
                        return
                    });
            }
        },
    }
</script>

<style>
    @import '../../assets/css/transactions.css';
</style>