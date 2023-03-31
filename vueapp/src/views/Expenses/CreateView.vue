<template>
    <div id="app" class="container">
        <div class="add">
            <p>Add new {{ this.type }}</p>
            <div class="add-body">
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
                <button @click="addData()">+</button>
            </div>
        </div>
    </div>
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
                    }).then(this.$router.push('/expenses'))
                } catch (err) {
                    alert(err); // Failed to fetch
                }
            },
        }
    }
</script>

<style>
    .add {
        max-width: 420px;
        margin: 30px auto;
        background: white;
        text-align: left;
        padding: 40px;
        border-radius: 10px;
    }
    p {
        color: #808080;
        margin: 25px 0 15px;
        font-size: 0.8em;
        text-transform: uppercase;
        letter-spacing: 1px;
        font-weight: bold;
    }
    label {
        color: #aaa;
        display: inline-block;
        margin: 25px 0 15px;
        font-size: 0.6em;
        text-transform: uppercase;
        letter-spacing: 1px;
        font-weight: bold;
    }
    .form-control {
        display: block;
        padding: 10px 6px;
        width: 100%;
        box-sizing: border-box;
        border: none;
        border-bottom: 1px solid #ddd;
        color: #555;
    }
    button {
        background: #222222;
        border: 0;
        padding: 10px 20px;
        margin-top: 20px;
        color: white;
        border-radius: 20px;
        text-align: center;
        cursor: pointer;
    }

    .control_wrapper {
        max-width: 250px;
        margin: 0 auto;
    }

    input[type="date"] {
        background-color: #192841;
        color: #ffffff;
        font-size: 18px;
        border: none;
        outline: none;
        border-radius: 5px;
    }

    ::-webkit-calendar-picker-indicator {
        background-color: #ffffff;
        cursor: pointer;
        border-radius: 3px;
    }
</style>