import NOTIFICATION_CONSTANTS from '../../constants/notification';
import Vue from 'vue';
import i18n from '../../plugins/i18n';
import { ToastPlugin } from 'bootstrap-vue';

Vue.use(ToastPlugin);
const toastVueInstance = new Vue();

export const actions = {
    successNotification(context, payload){
        toastVueInstance.$bvToast.toast(i18n.t(payload), {
          toaster: 'b-toaster-bottom-right',
          variant: NOTIFICATION_CONSTANTS.SUCCESS,
      });
    },
    errorNotification(context, payload){
        toastVueInstance.$bvToast.toast(i18n.t(payload), {
          toaster: 'b-toaster-bottom-right',
          variant: NOTIFICATION_CONSTANTS.DANGER,
        });
    }
};