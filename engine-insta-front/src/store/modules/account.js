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
        const response = await AccountApi.logIn(payload);
        if(response.data.login.user.userStatus === USER_CONSTANTS.statusActive) {
            localStorage.setItem('token', response.data.login.token);
            context.commit("SET_TOKEN", response.data.login.token);
            //context.commit("user/SET_USER", response.data.login, { root:true });
        }
    }
};