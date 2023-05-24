<template>
    <main id="create">
        <h1>Sign Up</h1>
        <div id="create-transactions" class="transactions-body">
            <p>Sign Up</p>
            <div>
                <error v-if="error" :error="error" />
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
    const uri = 'https://localhost:7007/register';

    export default {
        name: "SignUpView",
        components: {
            Error
        },
        data() {
            return {
                error: ''
            }
        },
        mounted() {
            this.$refs.firstname.focus()
            this.$refs.lastname.focus()
            this.$refs.email.focus()
            this.$refs.password.focus()
        },
        methods: {
            async addUser() {
                /*const postData = {
                    //firstName: this.$refs.firstname.value,
                    //lastName: this.$refs.lastname.value,
                    email: this.$refs.email.value,
                    password: this.$refs.password.value,
                    roles: [
                        "User"
                    ]
                };*/

                try {
                    await fetch(`${uri}`, {
                        method: 'POST',
                        mode: 'cors',
                        cache: 'no-cache',
                        credentials: 'same-origin',

                        headers: {
                            'content-type': 'application/json'
                        },
                        body: JSON.stringify({
                            email: document.getElementById("email"),
                            password: document.getElementById("password")
                        }),
                    })
                } catch (err) {
                    console.log(err);
                }

                /*try {
                    await fetch(`${uri}`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(postData),
                    }).then((response) => {
                        if (response.ok) {
                            this.$router.push('/login')
                            return response.json();
                        }
                        return Promise.reject(response);
                    }).then((json) => {
                        console.log("all good, token is ready" + json);
                    }).catch((response) => {
                        console.log(response.status, response.statusText);
                        //3. get error messages, if any
                        response.json().then((json) => {
                            console.log(json);
                            switch (true) {
                                case json['errors']['Email'] != false: this.error = 'Invalid e-mail!'
                                break;
                                case json['errors']['Password'] != false: this.error = 'Invalid password!'
                                break;
                                case json['errors']['Email'] != false && json['errors']['Password'] != false: this.error = 'Invalid e-mail and password!';
                                break;
                                case json['DuplicateEmail']['DuplicateEmail'] != false: this.error = 'E-mail is already taken!';
                                break;
                            }
                        })
                    });
                } catch (err) {
                    console.log(err);
                    this.error = err;
                }*/
            },
        }
    }
</script>

<style>
</style>