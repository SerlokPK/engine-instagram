import api from "../index";
import LoginTransformer from '../transformers/accounts/LoginTransformer';

export default {
    logIn(credentials) {
        return api.post('/account/login', credentials, {
            transformResponse: [
                ...api.defaults.transformResponse,
                LoginTransformer.transform
            ]
        });
    },
    register(payload) {
        return api.post('/account/register', payload);
    },
    activateAccount(userKey) {
        return api.patch(`/account/activate/${userKey}`);
    },
    forgotPassword(payload) {
        return api.patch(`/account/forgotpassword`, payload);
    },
    resetPassword(payload) {
        return api.patch(`/account/resetpassword`, payload);
    }
};