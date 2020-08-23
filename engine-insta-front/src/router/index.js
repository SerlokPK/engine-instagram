import Vue from 'vue';
import Router from 'vue-router';

import AuthorizationLayout from '../layouts/AuthorizationLayout';
import MemberLayout from '../layouts/MemberLayout';

import LoginPage from '../views/account/Login';
import RegisterPage from '../views/account/Register';
import ActivatePage from '../views/account/ActivateAccount';
import ForgotPasswordPage from '../views/account/ForgotPassword';
import ResetPasswordPage from '../views/account/ResetPassword';
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
        },
        {
          path: 'activate/:userKey',
          name: 'Activate account',
          component: ActivatePage
        },
        {
          path: 'forgot-password',
          name: 'Forgot password',
          component: ForgotPasswordPage
        },
        {
          path: 'reset-password/:resetKey',
          name: 'Reset password',
          component: ResetPasswordPage
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