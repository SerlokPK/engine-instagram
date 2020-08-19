import LoginModel from '../../models/accounts/Login';
import { BaseTransformer } from '../BaseTransformer';

class LoginTransformer extends BaseTransformer {
  constructor() {
    super();
  }

  transformSingle(data = {}) {
    const login = new LoginModel(data);
    return { login };
  }
}

export default new LoginTransformer();