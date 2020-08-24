import api from "../index";
import SearchedUsersTransformer from '../transformers/users/SearchedUsersTransformer';

export default {
    search(username) {
        return api.get(`/users/${username}`, {
            transformResponse: [
                ...api.defaults.transformResponse,
                SearchedUsersTransformer.transform
            ]
        });
    }
};