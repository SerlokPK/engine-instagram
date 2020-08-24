import { BaseTransformer } from '../BaseTransformer';
import UserSearchedModel from '../../models/users/UserSearched';

class LoginTransformer extends BaseTransformer {
  constructor() {
    super();
  }

  transformMultiple(data = {}) {
    const users = data?.map(item => new UserSearchedModel(item));
    return { users };
  }
}

export default new LoginTransformer();