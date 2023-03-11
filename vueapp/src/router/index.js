import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/HomeView.vue'
import About from '../views/AboutView.vue'
import IndexExpenses from '../views/Expenses/IndexView.vue'
import CreateExpenses from '../views/Expenses/CreateView.vue'
import EditExpenses from '../views/Expenses/EditView.vue'
import DeleteExpenses from '../views/Expenses/DeleteView.vue'
import DetailsExpenses from '../views/Expenses/DetailsView.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    component: About
  },
  {
    path: '/expenses',
    name: 'IndexExpenses',
    component: IndexExpenses
  },
  {
    path: '/expenses/create',
    name: 'CreateExpenses',
    component: CreateExpenses
  },
  {
    path: '/expenses/edit/:id',
    name: 'EditExpenses',
    component: EditExpenses,
    props: true
  },
  {
    path: '/expenses/delete/:id',
    name: 'DeleteExpenses',
    component: DeleteExpenses,
    props: true
  },
  {
    path: '/expenses/details/:id',
    name: 'DetailsExpenses',
    component: DetailsExpenses,
    props: true
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
