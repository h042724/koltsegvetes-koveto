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

                try {
                    await fetch(`${uri}/login`, {
                        method: "POST",
                        mode: 'cors',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        credentials: 'include',
                        body: JSON.stringify(postData)
                    }).then(response => {
                        for (let header of response.headers.entries()) {
                            console.log(header);
                        } }).then(this.$router.push('/transactions'))
                } catch (err) {
                    console.log(err)
                }

                /*try {
                    await fetch(`${uri}/login`, {
                        method: 'POST',
                        headers: {
                            'Access-Control-Allow-Origin' : '*',
                            'Content-type': 'application/json'
                        },
                        body: JSON.stringify(postData),
                    }).then((response) => {
                        console.log(response.body);
                        console.log(response.json())
                    }).then((rb) => {
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
                        .then((response) => {
                            // 1. check response.ok
                            console.log(response);
                            if (response.ok) {
                                this.$router.push('/transactions');
                                //return response.json();
                            }
                            return Promise.reject(response); // 2. reject instead of throw
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
                    }*/
            },
        }
    }
</script>

<style>
</style>