<template>
    <div class="main-block">
        <app-container>
            <div class="main-block__wrapper">
                <div class="main-block__info">
                    <h1 ref="title"
                        class="main-block__title">
                        If you're looking for a  <span>simple</span> and <span>effective</span> way to <span>manage your money</span>, look no further than this app!
                    </h1>
                    <div ref="description"
                         class="main-block__description">
                        This app helps you track your incomes and expenses, analyze your spending patterns and set realistic budgeting goals for the month.
                        You can see how much you can afford to spend, how much you need to save and how you can optimize your finances.
                        Whether you want to plan for the future, reduce your debt or just enjoy your money, this app will make it easy for you.
                        Try this app now and discover the power of budgeting!
                    </div>
                    <div ref="button"
                         class="main-block__btn">
                        <AppButton ref="button"
                                   text="Sign Up Now!"
                                   color="coral"
                                   size="medium"
                                   routeTo="/signup"
                                   class="main-block__button" />
                        <AppButton ref="button"
                                   text="Sign In Here!"
                                   color="coral"
                                   size="medium"
                                   routeTo="/login"
                                   class="main-block__button" />
                    </div>
                </div>
                <div ref="image"
                     class="main-block__image"></div>
            </div>
        </app-container>
    </div>
</template>

<script>
    import AppContainer from "@/components/components/AppContainer.vue";
    import AppButton from "@/components/components/AppButton.vue";
    import { gsap } from 'gsap';

    export default {
        name: 'HomeView',

        components: {
            AppContainer,
            AppButton
        },

        mounted() {
            this.AnimationMainBlock();
        },

        methods: {
            AnimationMainBlock() {
                const title = this.$refs.title;
                const description = this.$refs.description;
                const button = this.$refs.button;
                const image = this.$refs.image;

                gsap.to(title, {
                    opacity: '1',
                    y: -50,
                    duration: 0.2,
                });
                gsap.to(description, {
                    opacity: '1',
                    y: -50,
                    duration: 0.2,
                });
                gsap.to(button, {
                    opacity: '1',
                    y: -50,
                    duration: 0.3,
                });
                gsap.to(image, {
                    opacity: '1',
                    y: -50,
                    duration: 0.3
                });
            }
        }

    }
</script>

<style lang="scss">
    .main-block {
        background: url("../assets/images/bg-shape-left.png");
        background-repeat: no-repeat;
        background-size: cover;

        &__wrapper {
            display: flex;
            justify-content: space-between;

            @media screen and (max-width: 768px) {
                flex-wrap: wrap;
                justify-content: center;
            }
        }

        &__info {
            width: 594px;
            margin-top: 48px;

            @media screen and (max-width: 1200px) {
                width: 400px;
            }

            @media screen and (max-width: 768px) {
                width: 100%;
                margin-top: 10px;
            }
        }

        &__title {
            font-style: normal;
            font-weight: 400;
            font-size: 48px;
            line-height: 60px;
            letter-spacing: 1.8px;
            color: #08090A;
            margin-bottom: 27px;
            opacity: 0;
            transform: translateY(100px);
            transition: all .5s linear;

            & span {
                color: #9fc5e8;
            }

            @media screen and (max-width: 768px) {
                font-size: 48px;
            }

            @media screen and (max-width: 576px) {
                font-size: 38px;
                text-align: center;
            }
        }

        &__description {
            font-style: normal;
            font-weight: 400;
            font-size: 18px;
            line-height: 24px;
            letter-spacing: 0.36px;
            color: #546285;
            width: 500px;
            opacity: 0;
            transform: translateY(100px);
            transition: all .5s linear;

            @media screen and (max-width: 1200px) {
                width: 400px;
            }

            @media screen and (max-width: 768px) {
                font-size: 16px;
            }

            @media screen and (max-width: 576px) {
                width: 100%;
                font-size: 14px;
                text-align: center;
            }
        }

        &__btn {
            opacity: 0;
            transform: translateY(100px);
            transition: all .5s linear;
            display: flex;
            justify-content: space-evenly;
        }

        &__button {
            margin-top: 53px;
            margin-bottom: 40px;

            @media screen and (max-width: 768px) {
                width: 86%;
            }

            @media screen and (max-width: 576px) {
                width: 80%;
                margin: 20px 0;
            }
        }

        &__image {
            width: 600px;
            height: 580px;
            background: url("../assets/images/main-image-delivered.png");
            background-repeat: no-repeat;
            background-size: cover;
            margin-top: 100px;
            margin-bottom: 140px;
            opacity: 0;
            transition: all .5s linear;

            @media screen and (max-width: 1200px) {
                width: 500px;
                height: 544px;
            }

            @media screen and (max-width: 576px) {
                width: 100%;
                background-position-x: center;
                border-radius: 10px;
                margin: 50px 0;
            }
        }
    }
</style>