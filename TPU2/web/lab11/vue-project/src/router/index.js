import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import FoodView from '../views/FoodView.vue'
import DrinkView from '../views/DrinkView.vue'
import FavosView from '../views/FavosView.vue'

const routes = [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/food',
      name: 'food',
      component: FoodView,
    },
    {
      path: '/drinks',
      name: 'drinks',
      component: DrinkView,
    },
    {
      path: '/favorites',
      name: 'favorites',
      component: FavosView,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
})  


export default router;
