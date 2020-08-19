export const state = () => ({
    user: null,
});

export const mutations = {
    SET_USER(state, payload) {
        state.user = payload.user;
    }
};

export const getters = {
    getUser: state => state.user,
};

export const actions = {
    
};