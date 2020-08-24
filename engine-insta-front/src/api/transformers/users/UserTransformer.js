import UserModel from '../../models/users/User';
import { BaseTransformer } from '../BaseTransformer';

class UserTransformer extends BaseTransformer {
  constructor() {
    super();
  }

  transformSingle(data = {}) {
    const user = new UserModel(data);
    return { user };
  }
}

export default new UserTransformer();