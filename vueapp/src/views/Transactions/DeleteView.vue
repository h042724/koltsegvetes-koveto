<template>
    <div id="delete">
        <h1>Delete transaction</h1>
        <h3>Are you sure you want to delete this transaction?</h3>
        <dl v-show="transactions">
            <dt>
                <label>Name</label>
            </dt>
            <dd>
                {{ transactions.name }}
            </dd>
            <dt>
                <label>Amount</label>
            </dt>
            <dd>
                {{ transactions.amount }}
            </dd>
            <dt>
                <label>Transaction Date</label>
            </dt>
            <dd>
                {{ transactions.transactionDate }}
            </dd>
        </dl>
        <button @click="deleteData()">Delete</button>
        <button>
            <router-link :to="{ name: 'IndexTransactions' }">Back to List</router-link>
        </button>
    </div>
</template>

<script>
    const uri = 'https://localhost:7007/expenses';

    export default {
        name: "DeleteView",
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

            async deleteData() {
                try {
                    await fetch(`${uri}/${this.id}`, {
                        method: 'DELETE'
                    }).then(this.$router.push('/expenses'))
                } catch (err) {
                    alert(err); // Failed to fetch
                }
            },
        }
    }
</script>

<style>

</style>