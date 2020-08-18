import Vue from 'vue';
import App from './App.vue';
import BootstrapVue from 'bootstrap-vue';
import router from './router';
import store from './store';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.config.productionTip = false;
Vue.use(BootstrapVue);

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth) && !store.getters['account/isAuthenticated']) {
      next({ path: '/account/login' });
  } else {
      if(!to.matched.some(record => record.meta.requiresAuth) && store.getters['account/isAuthenticated']) {
        next();
      } else {
        next();
      }
  }
});

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app');
