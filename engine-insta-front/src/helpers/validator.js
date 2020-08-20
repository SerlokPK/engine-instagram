import { helpers } from 'vuelidate/lib/validators';

export const passwordValidation = helpers.regex('passwordValidation'
                                                , /(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!"#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).*/);
export const noWhitespaceValidation = helpers.regex('noWhitespaceValidation', /^\S*$/);
