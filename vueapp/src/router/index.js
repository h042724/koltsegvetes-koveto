import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/HomeView.vue'
import Login from '../views/Account/Login.vue'
import SignUp from '../views/Account/SignUp.vue'
import IndexTransactions from '../views/Transactions/IndexView.vue'
import CreateTransactions from '../views/Transactions/CreateView.vue'
import EditTransactions from '../views/Transactions/EditView.vue'
import DeleteTransactions from '../views/Transactions/DeleteView.vue'
import DetailsTransactions from '../views/Transactions/DetailsView.vue'

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
    props: true
  },
  {
    path: '/signup',
    name: 'SignUp',
    component: SignUp
  },
  {
    path: '/transactions',
    name: 'IndexTransactions',
    component: IndexTransactions
  },
  {
    path: '/transactions/create/:type',
    name: 'CreateTransactions',
    component: CreateTransactions,
    props: true
  },
  {
    path: '/transactions/edit/:type/:id',
    name: 'EditTransactions',
    component: EditTransactions,
    props: true
  },
  {
    path: '/transactions/delete/:id',
    name: 'DeleteTransactions',
    component: DeleteTransactions,
    props: true
  },
  {
    path: '/transactions/details/:id',
    name: 'DetailsTransactions',
    component: DetailsTransactions,
    props: true
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
