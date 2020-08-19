import store from "../../store";

export const storeInitialInfo = async () => {
    try {
        const token = localStorage.getItem('token');
        if(token) {
            store.commit('SET_TOKEN', token);
        }
    } catch(error) {
        Promise.resolve(error);
    }
}; 