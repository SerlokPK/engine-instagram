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
    }
};