<template>
    <div id="expense" class="d-flex flex-column justify-content-center w-100 h-100">
        <h1>Expense Index - Vue</h1>
        <p>
            <router-link :to="{ name: 'CreateExpenses', params: { type: 'expense'}}">Add New Expense</router-link> |
            <router-link :to="{ name: 'CreateExpenses', params: { type: 'income'}}">Add New Income</router-link>
        </p>
        <div class="post">
            <div v-if="loading" class="loading"></div>
            <div v-if="post" class="content">
                <table>
                    <thead>
                        <tr>
                            <th>id</th>
                            <th>name</th>
                            <th>amount ($)</th>
                            <th>date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="expense in post" :key="expense.id">
                            <td>{{ expense.id }}</td>   
                            <td>{{ expense.name }}</td>
                            <td>{{ expense.amount }}</td>
                            <td>{{ expense.transactionDate }}</td>
                            <td>
                                <router-link :to="{ name: 'EditExpenses', params: { id: expense.id, type: expense.amount < 0 ? 'expense' : 'income'}}">Edit</router-link> |
                                <router-link :to="{ name: 'DetailsExpenses', params: { id: expense.id}}">Details</router-link> |
                                <router-link :to="{ name: 'DeleteExpenses', params: { id: expense.id}}">Delete</router-link>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'IndexView',
        components: {},
        data() {
            return {
                loading: false,
                post: null
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
                this.post = null;
                this.loading = true;

                fetch('expenses')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return
                    });
            }
        },
    }
</script>

<style>

</style>