<template>
    <div id="app" class="container">
        <div class="card" v-if="post">
            <div class="card-header">Vue Fetch POST</div>
            <div class="card-body">
                <div class="form-group">
                    <input id="id" type="text" class="form-control" ref="post_id" :value=post.id disabled />
                </div>
                <div class="form-group">
                    <input id="name" type="text" class="form-control" ref="post_name" :value=post.name />
                </div>
                <div class="form-group">
                    <input id="amount" type="text" class="form-control" ref="post_amount" :value=post.amount />
                </div>
                <div class="form-group">
                    <input id="transaction-date" type="text" class="form-control" ref="post_transactionDate" :value=post.transactionDate />
                </div>
                <button class="btn btn-sm btn-primary" @click="postData">Post Data</button>
            </div>
        </div>
    </div>
</template>

<script>
    const uri = 'https://localhost:7007/expenses';

    export default {
        name: "EditView",
        props: ['id'],
        data() {
            return {
                loading: false,
                post: null
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
                this.post = null;
                this.loading = true;

                fetch(`${uri}/${this.id}`)
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return
                    });
            },

            async postData() {
                const postData = {
                    id: document.getElementById('id').value,
                    name: document.getElementById('name').value,
                    amount: document.getElementById('amount').value,
                    transactionDate: document.getElementById('transaction-date').value,
                };

                try {
                    await fetch(`${uri}/edit/${this.id}`, {
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
        }
    }
</script>