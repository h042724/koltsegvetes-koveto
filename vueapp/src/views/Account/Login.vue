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
                    <input id="password" type="password" class="form-control" ref="password" required />
                </div>
                <button class="transaction-button" @click="login()">Login</button>
            </div>
        </div>
    </main>
</template>

<script>
    const uri = 'https://localhost:7007/account';

    export default {
        name: "LoginView",
        mounted() {
            this.$refs.email.focus()
            this.$refs.password.focus()
        },
        methods: {
            async login() {
                const postData = {
                    email: this.$refs.email.value,
                    password: this.$refs.password.value
                };

                try {
                    const response = await fetch(`${uri}/login`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData)
                    }).then(this.$router.push('/transactions'))
                      .catch(err => console.log(err))
                } catch (err) {
                    console.log(err);
                }
            },
        }
    }
</script>

<style>
</style>