<template>
    <main id="create">
        <h1>Login</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Login</p>
            <div>
                <error v-if="error" :error="error" />
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
    const uri = 'https://localhost:7007/account';

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
                    password: this.$refs.password.value
                };

                try {
                    await fetch(`${uri}/login`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData)
                    }).then((response) => response.body)
                        .then((rb) => {
                            const reader = rb.getReader();
                            return new ReadableStream({
                                start(controller) {
                                    function push() {
                                        reader.read().then(({ done, value }) => {
                                            if (done) {
                                                controller.close();
                                                return;
                                            }
                                            controller.enqueue(value);
                                            push();
                                        });
                                    }
                                    push();
                                },
                            });
                        })
                        .then((stream) => new Response(stream, { headers: { "Content-Type": "text/html" } }).text()
                        )
                        .then((result) => {
                            localStorage.setItem("user", JSON.parse(result).token)
                            console.log(JSON.parse(result).token);
                        })
                        .then(this.$router.push('/transactions'))
                        .then((response) => {
                            // 1. check response.ok
                            if (response.ok) {
                                this.$router.push('/transactions');
                                //return response.json();
                            }
                            return Promise.reject(response); // 2. reject instead of throw
                        })
                        .then((json) => {
                            // all good, token is ready
                            //this.store.commit("token", json.access_token);
                            console.log("all good, token is ready" + json);
                            this.success = "Your account has been created. Please log in!"
                        })
                        .catch((response) => {
                            console.log(response.status, response.statusText);
                            // 3. get error messages, if any
                            response.json().then((json) => {
                                console.log(json);
                                this.error = 'Incorrect email or password!';
                            })
                        });
                    } catch (err) {
                        console.log(err);
                    }
                },
            }
        }
</script>

<style>
</style>