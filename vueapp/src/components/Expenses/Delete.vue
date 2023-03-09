<template>
    <div id="expense">
        <h1>Expense delete - Vue</h1>
        <h3>Are you sure you want to delete this?</h3>
        <dl class="row">
            <dt class="col-sm-2">
                <label>Name</label>
            </dt>
            <dd class="col-sm-10">
                {{Expense.Name}}
            </dd>
            <dt class="col-sm-2">
                <label>Category</label>
            </dt>
            <dd class="col-sm-10">
                {{Expense.Category}}
            </dd>
            <dt class="col-sm-2">
                <label>Transaction Date</label>
            </dt>
            <dd class="col-sm-10">
                {{Expense.TransactionDate}}
            </dd>
            <dt class="col-sm-2">
                <label>User Guid</label>
            </dt>
            <dd class="col-sm-10">
                {{Expense.UserGuid}}
            </dd>
        </dl>
        <form :action="DeleteExpenseUrl" method="post">
            <input type="hidden" name="Id" value="Expense.Id" />
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            <a :href="IndexExpenseUrl">Back to List</a>
        </form>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: 'expense-create-component',
        props: {
            DeleteExpenseUrl: String,
            IndexExpenseUrl: String,    
            Expense: Object
        },
        /*data() {
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

                fetch('weatherforecast')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },*/
    });
</script>