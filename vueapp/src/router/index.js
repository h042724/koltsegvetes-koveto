import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/HomeView.vue'
import Login from '../views/Account/Login.vue'
import SignUp from '../views/Account/SignUp.vue'
import IndexTransactions from '../views/Transactions/IndexView.vue'
import CreateTransactions from '../views/Transactions/CreateView.vue'
import EditTransactions from '../views/Transactions/EditView.vue'
import DeleteTransactions from '../views/Transactions/DeleteView.vue'
import DetailsTransactions from '../views/Transactions/DetailsView.vue'
const sessionStorage = window.sessionStorage;

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
    props: true,
    meta: {
        disableIfLoggedIn: true
    }
  },
  {
    path: '/signup',
    name: 'SignUp',
    component: SignUp,
    meta: {
        disableIfLoggedIn: true
    }
  },
  {
    path: '/transactions',
    name: 'IndexTransactions',
    component: IndexTransactions,
    meta: {
        requiresAuth: true
    }
  },
  {
    path: '/transactions/create/:type',
    name: 'CreateTransactions',
    component: CreateTransactions,
    props: true,
    meta: {
        requiresAuth: true
    }
  },
  {
    path: '/transactions/edit/:type/:id',
    name: 'EditTransactions',
    component: EditTransactions,
    props: true,
    meta: {
        requiresAuth: true
    }
  },
  {
    path: '/transactions/delete/:id',
    name: 'DeleteTransactions',
    component: DeleteTransactions,
    props: true,
    meta: {
        requiresAuth: true
    }
  },
  {
    path: '/transactions/details/:id',
    name: 'DetailsTransactions',
    component: DetailsTransactions,
    props: true,
    meta: {
        requiresAuth: true
    }
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach((to, from) => {
    if (to.meta.requiresAuth && !sessionStorage.isAuthenticated) {
        return { name: 'Login' }
    } else if (to.meta.disableIfLoggedIn && sessionStorage.isAuthenticated) {
        return { name: 'Home' }
    }
})

export default router
