<template>
    <main id="create">
        <h1>Transactions create</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Add new {{ this.type }}</p>
            <div>
                <div class="form-group">
                    <label for="name">Name:</label>
                    <input id="name" type="text" class="form-control" ref="post_name" required />
                </div>
                <div class="form-group">
                    <label for="amount">Amount:</label>
                    <input id="amount" type="text" class="form-control" ref="post_amount" required />
                </div>
                <div class="form-group">
                    <label for="transaction-date">Transaction date:</label>
                    <input id="transaction-date" type="date" class="form-control" ref="transactionDate" required />
                </div>
                <button class="transaction-button" @click="addData()">+</button>
            </div>
        </div>
    </main>
</template>

<script>
    const uri = 'https://localhost:7007/expenses';

    export default {
        name: "CreateView",
        props: ['type'],
        mounted() {
            this.$refs.transactionDate.focus()
        },
        methods: {
            async addData() {
                const postData = {
                    name: document.getElementById('name').value,
                    amount: document.getElementById('amount').value,
                    transactionDate: this.$refs.transactionDate.value
                };

                try {
                    await fetch(`${uri}/${this.type}`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData),
                    }).then(this.$router.push('/transactions'))
                } catch (err) {
                    alert(err); // Failed to fetch
                }
            },
        }
    }
</script>

<style>

</style>