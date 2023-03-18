<template>
    <div id="expense">
        <h1>Expense details - Vue</h1>
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
        <div>
            <router-link :to="{ name: 'EditExpenses', params: { id: id}}">Edit</router-link> |
            <router-link :to="{ name: 'IndexExpenses' }">Back to List</router-link>
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
        }
    }
</script>

<style>

</style>