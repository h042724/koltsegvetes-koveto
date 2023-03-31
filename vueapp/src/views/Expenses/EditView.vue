<template>
    <div id="edit">
        <h1>Edit transaction</h1>
        <div id="edit-transactions" class="transactions-body" v-show="transactions">
            <div>
                <div class="form-group">
                    <input id="id" type="hidden" ref="id" :value=transactions.id />
                </div>
                <div class="form-group">
                    <label for="name">Name:</label>
                    <input id="name" type="text" class="form-control" ref="name" :value=transactions.name />
                </div>
                <div class="form-group">
                    <label for="amount">Amount:</label>
                    <input id="amount" type="text" class="form-control" ref="amount" :value=Math.abs(transactions.amount) />
                </div>
                <div class="form-group">
                    <label for="transaction-date">Transaction date:</label>
                    <input id="transaction-date" type="date" class="form-control" ref="transactionDate" :value=transactions.transactionDate required />
                </div>
                <button @click="editData()">Edit</button>
            </div>
        </div>
    </div>
</template>

<script>
    const uri = 'https://localhost:7007/expenses';

    export default {
        name: "EditView",
        props: ['id', 'type'],
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

            async editData() {
                const postData = {
                    id: this.$refs.id.value,
                    name: this.$refs.name.value,
                    amount: this.$refs.amount.value,
                    transactionDate: this.$refs.transactionDate.value
                };

                try {
                    await fetch(`${uri}/edit/${this.type}/${this.id}`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData),
                    }).then(this.$router.push('/expenses'))
                        .catch(error => console.error('Unable to update item.', error));
                } catch (err) {
                    console.log(err); // Failed to fetch
                }
            },
        },
        mounted() {
            this.$refs.id.focus()
            this.$refs.name.focus()
            this.$refs.amount.focus()
            this.$refs.transactionDate.focus()
        }
    }
</script>