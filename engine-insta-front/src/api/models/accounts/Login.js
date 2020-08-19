import User from "../users/User";

export default class Login {
  constructor(item) {
    this.user = new User(item.User);
    this.token = item.Token;
  }
}