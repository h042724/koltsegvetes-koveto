<template>
    <main id="create">
        <h1>Transactions create</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Add new {{ this.type }}</p>
            <div>
                <div class="form-group">
                    <label for="name">Name:</label>
                    <input id="name" type="text" class="form-control" ref="post_name" required autocomplete="off" />
                </div>
                <div class="form-group">
                    <label for="amount">Amount:</label>
                    <input id="amount" type="number" class="form-control" ref="post_amount" required autocomplete="off" />
                </div>
                <div class="form-group">
                    <label for="transaction-date">Transaction date:</label>
                    <input id="transaction-date" type="date" class="form-control" ref="transactionDate" required />
                </div>
                <div class="form-group">
                    <label for="categories">Category:</label>
                    <select name="categories" id="categories">
                        <option v-for="item in categories" :key="item.id" :value="item.id">{{ item.name }}</option>
                    </select>
                </div>
            <button class="transaction-button" @click="addData()">+</button>
            </div>
        </div>
    </main>
</template>

<script>
    const transactionsUri = 'https://localhost:7007/transactions';
    const CategoriesUri = 'https://localhost:7007/categories';

    export default {
        name: "CreateView",
        props: ['type'],
        data() {
            return {
                selectedCategory: '',
                categories: null
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        mounted() {
            this.$refs.transactionDate.focus()
        },
        methods: {
            async addData() {   
                const postData = {
                    name: document.getElementById('name').value,
                    amount: document.getElementById('amount').value,
                    transactionDate: this.$refs.transactionDate.value,
                    categoryID: document.getElementById("categories").value,
                    userID: ''
                };

                try {
                    await fetch(`${transactionsUri}/${this.type}`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData),
                    }).then(this.$router.push('/transactions'))
                } catch (err) {
                    alert(err);
                }
            },

            fetchData() {
                fetch(`${CategoriesUri}/${this.type}`)
                    .then(r => r.json())
                    .then(json => {
                        this.categories = json;
                        this.loading = false;
                        return
                    });
            }
        }
    }
</script>

<style>

</style>