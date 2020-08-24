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
            
            return response.data.users;
        }catch (error) {
            context.dispatch('errorNotification', error.data.errorMessage);
        }
    }
};