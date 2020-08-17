import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

const routes = [
    // {
    //   path: '/account',
    //   component: LayoutSimple,
    //   children: [
    //   ]
    // },
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