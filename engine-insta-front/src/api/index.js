import axios from "axios";
import store from '../store';

const api = axios.create({
    baseURL: process.env.VUE_APP_API_URL,
    headers: {
      common: {
        Accept: "application/json",
        "Content-Type": "application/json"
      }
    }
});

const preRequestOptions = (request, store) => {
    const token = store.getters['account/getToken'];
    if(token) {
      request.headers.common = {
        ...request.headers.common,
        Authorization: `Bearer ${token}`,
      };
    }
    return request;
};
const handleRequestErrors = error => Promise.reject(error);
  
const handleResponseErrors = error => {
    if (error.response?.status === 500) {
        // TODO: redirect to router.push("/errors/500");
    }
  
    return Promise.reject(error.response);
};
  
api.interceptors.request.use(
    request => preRequestOptions(request, store),
    error => handleRequestErrors(error)
);
  
api.interceptors.response.use(
    response => response,
    error => handleResponseErrors(error)
);
  
export default api;