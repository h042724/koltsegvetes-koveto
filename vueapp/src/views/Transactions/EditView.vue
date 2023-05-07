<template>
    <main id="edit">
        <h1>Edit transaction</h1>
        <div v-if="loading" class="loading"></div>
        <div v-if="transactions" id="edit-transactions" class="transactions-body">
            <div class="form-group">
                <input id="id" type="hidden" :value=transactions.id />
            </div>
            <div class="form-group">
                <label for="name">Name:</label>
                <input id="name" type="text" class="form-control" :value=transactions.name autocomplete="off" />
            </div>
            <div class="form-group">
                <label for="amount">Amount:</label>
                <input id="amount" type="text" class="form-control" :value=Math.abs(transactions.amount) autocomplete="off" />
            </div>
            <div class="form-group">
                <label for="transaction-date">Transaction date:</label>
                <input id="transaction-date" type="date" class="form-control" :value=transactions.transactionDate required />
            </div>
            <div class="form-group">
                <label for="categories">Category:</label>
                <select name="categories" id="categories">
                    <option v-for="item in categories" :key="item.id" :value="item.id" :selected="item.id === transactions.referencedCategory.id">{{ item.name }}</option>
                </select>
            </div>
            <button class="transaction-button" @click="editData()">Edit</button>
        </div>
    </main>
</template>

<script>
    const transactionsUri = 'https://localhost:7007/transactions';
    const CategoriesUri = 'https://localhost:7007/categories';

    export default {
        name: "EditView",
        props: ['id', 'type'],
        data() {
            return {
                loading: false,
                transactions: null,
                categories: null,
            }
        },
        created() {
            this.fetchTransactions();
            this.fetchCategories();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            fetchTransactions() {
                this.transactions = null;
                this.loading = true;

                fetch(`${transactionsUri}/${this.id}`)
                    .then(r => r.json())
                    .then(json => {
                        this.transactions = json;
                        this.loading = false;
                        return
                    });
            },

            fetchCategories() {
                fetch(`${CategoriesUri}/${this.type}`)
                    .then(r => r.json())
                    .then(json => {
                        this.categories = json;
                        this.loading = false;
                        return
                    });
            },

            async editData() {
                const postData = {
                    id: document.getElementById('id').value,
                    name: document.getElementById('name').value,
                    amount: document.getElementById('amount').value,
                    transactionDate: document.getElementById('transaction-date').value,
                    categoryID: document.getElementById("categories").value
                };

                try {
                    await fetch(`${transactionsUri}/edit/${this.type}/${this.id}`, {
                        method: 'POST',
                        headers: {  
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData),
                    }).then(this.$router.push('/transactions'))
                        .catch(error => console.error('Unable to update item.', error));
                } catch (err) {
                    console.log(err);
                }
            },
        },
    }
</script>