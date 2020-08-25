import store from "../../store";

export const storeInitialInfo = async () => {
    try {
        const token = localStorage.getItem('token');
        if(token) {
            store.commit('SET_TOKEN', token);
        }

        let userId = localStorage.getItem('userId');
        if(userId) {
            await store.dispatch('getUser', userId);
        }
    } catch(error) {
        Promise.resolve(error);
    }
}; 