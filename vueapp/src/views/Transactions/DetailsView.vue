<template>
    <div id="details">
        <h1>Transactions details</h1>
        <div id="details-transactions" class="transactions-body">
            <dl v-show="transactions">
                <dt>
                    <label>Name</label>
                </dt>
                <dd class="col-sm-10">
                    {{ transactions.name }}
                </dd>
                <dt>
                    <label>Amount</label>
                </dt>
                <dd class="col-sm-10">
                    {{ transactions.amount }}
                </dd>
                <dt>
                    <label>Transaction Date</label>
                </dt>
                <dd class="col-sm-10">
                    {{ transactions.transactionDate }}
                </dd>
            </dl>
            <button>
                <router-link :to="{ name: 'EditTransactions', params: { id: transactions.id, type: transactions.amount < 0 ? 'expense' : 'income'}}">Edit</router-link>
            </button>
            <button>
                <router-link :to="{ name: 'IndexTransactions' }">Back to List</router-link>
            </button>
        </div>
        </div>
</template>

<script>
    const uri = 'https://localhost:7007/expenses';

    export default {
        name: "DetailsView",
        props: ['id'],
        data() {
            return {
                loading: false,
                transactions: null
            }
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

                fetch(`${uri}/${this.id}`)
                    .then(r => r.json())
                    .then(json => {
                        this.transactions = json;
                        this.loading = false;
                        return
                    });
            },
        }
    }
</script>

<style>

</style>