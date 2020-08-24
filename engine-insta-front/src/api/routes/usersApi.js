import api from "../index";

export default {
    search(username) {
        return api.get(`/users/${username}`);
    },
    getUser(userId) {
        return api.get(`/users/${userId}`);
    }
};