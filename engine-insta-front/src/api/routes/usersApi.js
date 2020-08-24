import api from "../index";
import UserTransformer from '../transformers/users/UserTransformer';

export default {
    search(username) {
        return api.get(`/users/search/${username}`);
    },
    getUser(userId) {
        return api.get(`/users/${userId}`, {
            transformResponse: [
                ...api.defaults.transformResponse,
                UserTransformer.transform
            ]
        });
    }
};