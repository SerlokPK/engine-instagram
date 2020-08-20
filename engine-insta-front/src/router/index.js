import Vue from 'vue';
import Router from 'vue-router';

import AuthorizationLayout from '../layouts/AuthorizationLayout';
import MemberLayout from '../layouts/MemberLayout';

import LoginPage from '../views/account/Login';
import RegisterPage from '../views/account/Register';
import TestPage from '../views/member/Test';

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
        },
        {
          path: 'register',
          name: 'Register',
          component: RegisterPage
        }
      ]
    },
    {
      path: '/',
      component: MemberLayout,
      meta: {
        requiresAuth: true
      },
      children: [
        {
          path: '/',
          name: 'Test',
          component: TestPage
        }
      ]
    }
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