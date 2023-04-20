<template>
    <main id="create">
        <h1>Login</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Login</p>
            <div>
                <div class="form-group">
                    <label for="email">E-mail:</label>
                    <input id="email" type="text" class="form-control" ref="email" required />
                </div>
                <div class="form-group">
                    <label for="password">Password:</label>
                    <input id="password" type="text" class="form-control" ref="password" required />
                </div>
                <button class="transaction-button" @click="addData()">Login</button>
            </div>
        </div>
    </main>
</template>

<script>
    const uri = 'https://localhost:7007/expenses';

    export default {
        name: "LoginView",
        mounted() {
            this.$refs.email.focus()
            this.$refs.password.focus()
        },
        methods: {
            async addData() {
                const postData = {
                    email: this.$refs.email.value,
                    password: this.$refs.password.value
                };

                try {
                    await fetch(`${uri}/`, {
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
        }
    }
</script>

<style>
</style>