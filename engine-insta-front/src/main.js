import Vue from 'vue';
import App from './App.vue';
import BootstrapVue from 'bootstrap-vue';
import router from './router';
import store from './store';
import i18n from './plugins/i18n';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

import { storeInitialInfo } from './router/middlewares/initialization';

Vue.config.productionTip = false;
Vue.use(BootstrapVue);

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth) && !store.getters.isAuthenticated) {
      next({ path: '/account/login' });
  } else {
      if(!to.matched.some(record => record.meta.requiresAuth) && store.getters.isAuthenticated) {
        next({ path: '/' });
      } else {
        next();
      }
  }
});

storeInitialInfo().then(() => {
  new Vue({
    router,
    store,
    i18n,
    render: h => h(App),
  }).$mount('#app');
});
