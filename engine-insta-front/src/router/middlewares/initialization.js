import store from "../../store";

export const storeInitialInfo = async () => {
    try {
        const token = localStorage.getItem('token');
        if(token) {
            store.commit('SET_TOKEN', token);
        }

        let user = localStorage.getItem('user');
        if(user) {
            user = JSON.parse(user);
            store.commit("SET_USER", user);
        }
    } catch(error) {
        Promise.resolve(error);
    }
}; 