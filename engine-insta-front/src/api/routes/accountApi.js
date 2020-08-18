import api from "../index";

export default {
    logIn(credentials) {
        return api.post('/account/login', credentials);
    }
};