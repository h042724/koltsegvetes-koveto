<template>
    <div id="app" class="container">
        <div class="card">
            <div class="card-header">Vue Fetch POST</div>
            <div class="card-body">
                <div class="form-group">
                    <input id="name" type="text" class="form-control" ref="post_name" />
                </div>
                <div class="form-group">
                    <input id="amount" type="text" class="form-control" ref="post_amount" />
                </div>
                <div class="form-group">
                    <input id="transaction-date" type="text" class="form-control" ref="post_transactionDate" />
                </div>
                <button class="btn btn-sm btn-primary" @click="postData">Post Data</button>
            </div>
        </div>
    </div>
</template>

<script>
const uri = 'https://localhost:7007/expenses';

export default {
    name: "CreateView",
    props: ['type'],
    methods: {
        async postData() {
            const postData = {
                name: document.getElementById('name').value,
                amount: document.getElementById('amount').value,
                transactionDate: document.getElementById('transaction-date').value
            };

            try {
                await fetch(`${uri}/${this.type}`, {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(postData),
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