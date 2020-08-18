import Vue from 'vue';
import Router from 'vue-router';

import AuthorizationLayout from '../layouts/AuthorizationLayout';
import LoginPage from '../views/Login';

Vue.use(Router);

const routes = [
    {
      path: '/account',
      component: AuthorizationLayout,
      children: [
        {
          path: 'login',
          name: 'Log in',
          component: LoginPage
        }
      ]
    },
    // {
    //   path: '/',
    //   component: LayoutBackend,
    //   meta: {
    //     requiresAuth: true
    //   },
    //   children: []
    // }
];
  
  // Router Configuration
export default new Router({
    mode: 'history',
    linkActiveClass: 'active',
    linkExactActiveClass: '',
    scrollBehavior() {
      return { x: 0, y: 0 };
    },
    routes
});