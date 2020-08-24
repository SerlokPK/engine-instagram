import UsersApi from '../../api/routes/usersApi';

export const state = () => ({
    user: null
});

export const mutations = {
    SET_USER(state, payload) {
        state.user = payload;
    }
};

export const getters = {
    getUser: state => state.user,
};

export const actions = {
    async searchUsers(context, payload) {
        try {
            const response = await UsersApi.search(payload);
            
            return response.data;
        }catch (error) {
            context.dispatch('errorNotification', error.data.errorMessage);
        }
    },
    async getSelfUser(context) {
        try {
            const response = await UsersApi.getUser(context.getters.getUser.userId);
            
            return response.data;
        }catch (error) {
            context.dispatch('errorNotification', error.data.errorMessage);
        }
    },
    async getUser(context, payload) {
        try {
            const response = await UsersApi.getUser(payload);
            context.commit('SET_USER', response.data.user);
            
            return response.data;
        }catch (error) {
            context.dispatch('errorNotification', error.data.errorMessage);
        }
    }
};