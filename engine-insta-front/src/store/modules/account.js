import AccountApi from '../../api/routes/accountApi';
import USER_CONSTANTS from '../../constants/user';

export const state = () => ({
    token: null
});

export const mutations = {
    SET_TOKEN(state, payload) {
        state.token = payload;
    },
    REMOVE_TOKEN(state) {
        state.token = null;
    }
};

export const getters = {
    isAuthenticated: state => !!state.token,
    getToken: state => state.token
};

export const actions = {
    async logIn(context, payload) {
        try {
            const response = await AccountApi.logIn(payload);
            if(response.data.login.user.status === USER_CONSTANTS.statusActive) {
                localStorage.setItem('token', response.data.login.token);
                context.commit("SET_TOKEN", response.data.login.token);
                localStorage.setItem('user', JSON.stringify(response.data.login.user));
                context.commit("SET_USER", response.data.login.user);

                context.dispatch('successNotification', "login.successfulLogin");
            }
        }catch (error) {
            console.log(error);
            context.dispatch('errorNotification', error.data.errorMessage);
            
            return Promise.reject();
        }
    },
    async register(context, payload) {
        try {
            await AccountApi.register(payload);
            context.dispatch('successNotification', "register.successfulRegistration");
        }catch (error) {
            context.dispatch('errorNotification', error.data.errorMessage);

            return Promise.reject();
        }
    },
    async activateAccount(context, payload) {
        try {
            await AccountApi.activateAccount(payload);
            context.dispatch('successNotification', "activateAccount.successfulActivation");
        }catch (error) {
            context.dispatch('errorNotification', error.data.errorMessage);
        }
    },
    async forgotPassword(context, payload) {
        try {
            await AccountApi.forgotPassword(payload);
            context.dispatch('successNotification', "forgotPassword.resetPasswordInitiated");
        }catch (error) {
            context.dispatch('errorNotification', error.data.errorMessage);
        }
    },
    logOut() {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
    }
};