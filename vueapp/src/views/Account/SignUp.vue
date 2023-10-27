<template>
    <main id="create">
        <h1>Sign Up</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Sign Up</p>
            <div>
                <error v-if="error" :text="error" />
                <div class="form-group">
                    <label for="firstname">First name:</label>
                    <input id="firstname" type="text" class="form-control" ref="firstname" required autocomplete="off" />
                </div>
                <div class="form-group">
                    <label for="lastname">Last name:</label>
                    <input id="lastname" type="text" class="form-control" ref="lastname" required autocomplete="off" />
                </div>
                <div class="form-group">
                    <label for="email">E-mail:</label>
                    <input id="email" type="email" class="form-control" ref="email" required autocomplete="off" />
                </div>
                <div class="form-group">
                    <label for="password">Password:</label> <br>
                    <span id="pw-req">Passwords must have at least one digit, one uppercase and one non alphanumeric character and be at least 6 characters long.</span>
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
    import Error from '../../components/ErrorComponent.vue';
    const uri = 'https://localhost:7007/Register';
    const sessionStorage = window.sessionStorage;

    export default {
        name: "SignUpView",
        components: {
            Error
        },
        data() {
            return {
                error: null
            }
        },
        mounted() {
            this.$refs.firstname.focus()
            this.$refs.lastname.focus()
            this.$refs.email.focus()
            this.$refs.password.focus()
            this.$refs.confirmPassword.focus()
        },
        methods: {
            async addUser() {
                const postData = {
                    firstName: this.$refs.firstname.value,
                    lastName: this.$refs.lastname.value,
                    email: this.$refs.email.value,
                    password: this.$refs.password.value,
                    confirmPassword: this.$refs.confirmPassword.value
                };

                try {
                    await fetch(`${uri}/register`, {
                        method: 'POST',
                        headers: {
                            'Content-type': 'application/json'
                        },
                        body: JSON.stringify(postData)
                    }).then((response) => {
                        if (response.ok) {
                            sessionStorage.isAuthenticated = true;
                            this.$router.push('/transactions');
                        }

                        return response.json();
                    }).then(json => {
                        this.error = [];
                        console.log(JSON.parse(JSON.stringify(json)));
                        var errors = json.errors;
                        for (const [key, value] of Object.entries(errors)) {
                            this.error.push(JSON.stringify(value));
                        }
                    });
                } catch (err) {
                    console.log(err);
                    this.error = err;
                }
            },
        }
    }
</script>

<style>
</style>