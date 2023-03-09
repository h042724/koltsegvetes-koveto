<template>
    <div id="expense">
        <h1>Expense Index - Vue</h1>
        <p>
            <a :href="CreateExpenseUrl">Create New</a>
            <router-link to="/Create">Create New</router-link>
        </p>
        <table class="table">
            <thead>
                <tr>
                    <th>
                        Name
                    </th>
                    <th>
                        Category
                    </th>
                    <th>
                        TransactionDate
                    </th>
                    <th>
                        UserGuid
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="expense in post" :key="expense.TransactionDate">
                    <td>
                        {{expense.Name}}
                    </td>
                    <td>
                        {{expense.Category}}
                    </td>
                    <td>
                        {{expense.TransactionDate}}
                    </td>
                    <td>
                        {{expense.UserGuid}}
                    </td>
                    <td>
                        <a :href="EditExpenseUrl+'/'+item.Id">Edit</a> |
                        <a :href="DetailsExpenseUrl+'/'+item.Id">Details</a> |
                        <a :href="DeleteExpenseUrl+'/'+item.Id">Delete</a>
                    </td>
                </tr>
             </tbody>
        </table>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: 'expense-index-component',
        props: {
            CreateExpenseUrl: String,
            DeleteExpenseUrl: String,
            EditExpenseUrl: String,
            DetailsExpenseUrl: String,
            Expenses: Array,
        },
        /*mounted: function () {
            console.log(this.Expenses);
        }*/
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
                        return;
                    });
            }
        },
    });
</script>