<template>
    <main id="create">
        <h1>Sign Up</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Sign Up</p>
            <div>
                <div class="form-group">
                    <label for="firstname">First name:</label>
                    <input id="firstname" type="text" class="form-control" ref="firstname" required />
                </div>
                <div class="form-group">
                    <label for="lastname">Last name:</label>
                    <input id="lastname" type="text" class="form-control" ref="lastname" required />
                </div>
                <div class="form-group">
                    <label for="email">E-mail:</label>
                    <input id="email" type="text" class="form-control" ref="email" required />
                </div>
                <div class="form-group">
                    <label for="password">Password:</label>
                    <input id="password" type="password" class="form-control" ref="password" required />
                </div>
                <div class="form-group">
                    <label for="confirm-password">Confirm password:</label>
                    <input id="confirm-password" type="password" class="form-control" ref="confirmPassword" required />
                </div>
                <button class="transaction-button" @click="addData()">Sign Up</button>
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
            this.$refs.confirmPassword.focus()
        },
        methods: {
            async addData() {
                const postData = {
                    email: this.$refs.email.value,
                    password: this.$refs.password.value,
                    confirmPassword: this.$refs.confirmPassword.value
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