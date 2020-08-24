import api from "../index";

export default {
    search(username) {
        return api.get(`/users/${username}`);
    }
};