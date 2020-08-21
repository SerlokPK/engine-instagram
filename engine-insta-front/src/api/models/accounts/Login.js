import User from "../users/User";

export default class Login {
  constructor(item) {
    this.user = item.User ? new User(item.User) : null;
    this.token = item.Token;
  }
}