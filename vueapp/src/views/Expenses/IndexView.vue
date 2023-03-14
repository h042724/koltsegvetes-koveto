<template>
    <div id="expense">
        <h1>Expense Index - Vue</h1>
        <p>
            <router-link :to="{ name: 'CreateExpenses' }">Create new</router-link>
        </p>
        <div class="post">
            <div v-if="loading" class="loading">
                Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
            </div>

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
                            <td>{{ expense.TransactionDate }}</td>
                            <td>
                                <router-link :to="{ name: 'EditExpenses', params: { id: expense.id}}">Edit</router-link> |
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
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
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