<template>
    <div id="expense">
        <h1>Expense edit - Vue</h1>
        <div v-if="post" class="content">
            <form method="post">
                <div class="row">
                    <div class="col-md-4" v-for="expense in post" :key="expense.id">
                        <div class="text-danger"></div>
                        <input type="number" name="Id" :value=expense.id />
                        <div class="form-group">
                            <label for="Name" class="control-label">Expense Name</label>
                            <input name="Name" class="form-control" :value=expense.name />
                        </div>
                        <div class="form-group">
                            <label for="Amount" class="control-label">Amount</label>
                            <input name="Amount" class="form-control" :value=expense.amount />
                        </div>
                        <div class="form-group">
                            <label for="TransactionDate" class="control-label">Transaction Date</label>
                            <input name="TransactionDate" class="form-control" :value=expense.transactionDate />
                        </div>
                        <div class="form-group">
                            <input type="submit" value="Save" class="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
export default {
    name: 'IndexView',
    components: {},
    props: ['id'],
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

            fetch('https://localhost:7007/expenses/')
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