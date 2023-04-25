<template>
    <main id="create">
        <h1>Sign Up</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Sign Up</p>
            <div>
                <div class="form-group">
                    <label for="firstname">First name:</label>
                    <input id="firstname" type="text" class="form-control" ref="firstname" required autocomplete="off"/>
                </div>
                <div class="form-group">
                    <label for="lastname">Last name:</label>
                    <input id="lastname" type="text" class="form-control" ref="lastname" required autocomplete="off"/>
                </div>
                <div class="form-group">
                    <label for="email">E-mail:</label>
                    <input id="email" type="text" class="form-control" ref="email" required autocomplete="off"/>
                </div>
                <div class="form-group">
                    <label for="password">Password:</label>
                    <input id="password" type="password" class="form-control" ref="password" required />
                </div>
                <div class="form-group">
                    <label for="confirm-password">Confirm password:</label>
                    <input id="confirm-password" type="password" class="form-control" ref="confirmPassword" required />
                </div>
                <button class="transaction-button" @click="addUser()">Sign Up</button>
            </div>
        </div>
    </main>
</template>

<script>
    const uri = 'https://localhost:7007/account';

    export default {
        name: "SignUpView",
        mounted() {
            this.$refs.firstname.focus()
            this.$refs.lastname.focus()
            this.$refs.email.focus()
            this.$refs.password.focus()
        },
        methods: {
            async addUser() {
                const postData = {
                    firstName: this.$refs.firstname.value,
                    lastName: this.$refs.lastname.value,
                    email: this.$refs.email.value,
                    password: this.$refs.password.value,
                    roles: [
                        "User"
                    ]
                };

                try {
                    await fetch(`${uri}/signup`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData),
                    //}).then(console.log(postData))
                    }).then(this.$router.push('/login'))
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