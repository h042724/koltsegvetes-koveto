<template>
    <div id="expense">
        <h1>Expense delete - Vue</h1>
        <h3>Are you sure you want to delete this?</h3>
        <dl class="row" v-if="post">
            <dt class="col-sm-2">
                <label>ID</label>
            </dt>
            <dd class="col-sm-10">
                {{ post.id }}
            </dd>
            <dt class="col-sm-2">
                <label>Name</label>
            </dt>
            <dd class="col-sm-10">
                {{ post.name }}
            </dd>
            <dt class="col-sm-2">
                <label>Amount</label>
            </dt>
            <dd class="col-sm-10">
                {{ post.amount }}
            </dd>
            <dt class="col-sm-2">
                <label>Transaction Date</label>
            </dt>
            <dd class="col-sm-10">
                {{ post.transactionDate }}
            </dd>
        </dl>
        <button class="btn btn-sm btn-primary" @click="postData">Delete</button>
        <button class="btn btn-sm btn-primary">
            <router-link :to="{ name: 'IndexExpenses' }">Back to List</router-link>
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