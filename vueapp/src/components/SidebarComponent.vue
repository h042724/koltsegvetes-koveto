<template>
    <aside :class="`${is_expanded && 'is-expanded'}`" :key="isAuthenticated">
        <div class="menu-toggle-wrap">
            <button class="menu-toggle" @click="toggleMenu">
                <span class="material-icons">keyboard_double_arrow_right</span>
            </button>
        </div>

        <h3>Menu</h3>
        <div class="menu">
            <router-link class="button" to="/">
                <span class="material-icons">home</span>
                <span class="text">Home</span>
            </router-link>
            <div v-if="!isAuthenticated">
                <router-link class="button" to="/login">
                    <span class="material-icons">login</span>
                    <span class="text">Login</span>
                </router-link>
                <router-link class="button" to="/signup">
                    <span class="material-icons">draw</span>
                    <span class="text">Sign Up</span>
                </router-link>
            </div>
            <div v-else>
                <router-link class="button" to="/transactions">
                    <span class="material-icons">library_books</span>
                    <span class="text">Transactions</span>
                </router-link>
                <router-link class="button" to="/statistics">
                    <span class="material-icons">trending_up</span>
                    <span class="text">Statistics</span>
                </router-link>
                <router-link class="button" to="/account">
                    <span class="material-icons">person</span>
                    <span class="text">Account</span>
                </router-link>
            </div>
        </div>

        <div class="flex"></div>

        <div class="menu" v-if="isAuthenticated">
            <router-link class="button" to="/settings">
                <span class="material-icons">settings</span>
                <span class="text">Settings</span>
            </router-link>
            <router-link class="button" to="/" @click="signOut">
                <span class="material-icons">logout</span>
                <span class="text">Log out</span>
            </router-link>
        </div>
    </aside>
    </template>

    <script>
        import { ref } from 'vue'
        const sessionStorage = window.sessionStorage;

        export default {
            data() {
                return {
                    isAuthenticated: sessionStorage.isAuthenticated == null ? false : sessionStorage.isAuthenticated,
                    is_expanded: ref(localStorage.getItem("is_expanded") === "true")
                }
            },
            watch: {
                '$route': 'userIsAuthenticated'
            },
            methods: {
                userIsAuthenticated() {
                    this.isAuthenticated = sessionStorage.isAuthenticated == null ? false : sessionStorage.isAuthenticated
                },
                toggleMenu() {
                    this.is_expanded = !this.is_expanded;
                    localStorage.setItem("is_expanded", this.is_expanded.value);
                },
                signOut() {
                    sessionStorage.removeItem("isAuthenticated");
                    if(this.$route.name == "Home") {
                        this.$router.go();
                    }
                }
            }
        }

    </script>

    <style lang="scss" scoped>
        aside {
            display: flex;
            flex-direction: column;
            width: calc(2rem + 32px);
            min-height: 100vh;
            overflow: hidden;
            padding: 1rem;

            background-color: var(--dark);
            color: var(--light);

            transition: 0.2s ease-out;

            .flex {
                flex: 1 1 0;
            }

            .menu-toggle-wrap {
                display: flex;
                justify-content: flex-end;
                margin-bottom: 4rem;
                position: relative;
                top: 0;
                transition: 0.2s ease-out;

                .menu-toggle {
                    transition: 0.2s ease-out;

                    .material-icon {
                        font-size: 2rem;
                        color: var(--light);
                        transition: 0.2s ease-out;
                    }

                    &:hover {
                        .material-icons {
                            color: var(--primary);
                            transform: translatex(0.5rem);
                        }
                    }
                }
            }

            h3, .button .text {
                opacity: 0;
                transition: 0.3s ease-out;
            }

            h3 {
                color: var(--grey);
                font-size: 0.875rem;
                margin-bottom: 0.5rem;
                text-transform: uppercase;
            }

            .menu {
                margin: 0 -1rem;

                .button {
                    display: flex;
                    align-items: center;
                    text-decoration: none;
                    padding: 0.5rem 1rem;
                    transition: 0.2s ease-out;

                    .material-icons {
                        font-size: 2rem;
                        color: var(--light);
                        transition: 0.2s ease-out;
                    }

                    .text {
                        color: var(--light);
                        transition: 0.2s ease-out;
                    }

                    &:hover, &.router-link-exact-active {
                        background-color: var(--dark-alt);

                        .material-icons, .text {
                            color: var(--primary);
                        }
                    }

                    &.router-link-exact-active {
                        border-right: 5px solid var(--primary);
                    }
                }
            }

            &.is-expanded {
                width: var(--sidebar-width);

                .menu-toggle-wrap {
                    top: -3rem;

                    .menu-toggle {
                        transform: rotate(-180deg);
                    }
                }

                h3, .button .text {
                    opacity: 1;
                }

                .button {
                    .material-icons {
                        margin-right: 1rem;
                    }
                }
            }

            @media (max-width: 768px) {
                position: fixed;
                z-index: 99;
            }
        }
    </style>
