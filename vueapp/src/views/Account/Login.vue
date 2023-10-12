<template>
    <main id="create">
        <h1>Login</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Login</p>
            <div>
                <error v-if="error" :text="error" />
                <success v-if="success" :success="success" />
                <div class="form-group">
                    <label for="email">E-mail:</label>
                    <input id="email" type="text" class="form-control" ref="email" required autocomplete="off" />
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
    import Error from '../../components/ErrorComponent.vue';
    import Success from '../../components/SuccessComponent.vue';
    const sessionStorage = window.sessionStorage;
    const uri = 'https://localhost:7007/Login';

    export default {
        name: "LoginView",
        components: {
            Error,
            Success
        },
        prop: ['success'],
        data() {
            return {
                error: '',
                //success: ''
            }
        },
        mounted() {
            this.$refs.email.focus()
            this.$refs.password.focus()
        },
        methods: {
            async login() {
                const postData = {
                    email: this.$refs.email.value,
                    password: this.$refs.password.value,
                    rememberMe: false
                };

                await fetch(`${uri}/login`, {
                    method: 'POST',
                    headers: {
                        'Content-type': 'application/json'
                    },
                    body: JSON.stringify(postData)
                }).then((response) => {
                    // TODO: Response number should indicate whether theres a user or should sign up 
                    if (response.ok) {
                        sessionStorage.isAuthenticated = true;
                        this.$router.push('/transactions');
                    } else {
                        this.$refs.password.value = '';
                        this.error = 'Invalid email or password!';
                    }
                })/*.then((responseJson) => {
                    // Do something with the response
                }).catch((error) => {
                    console.log(error)
                })*/;
            },
        }
    }
</script>

<style>
</style>