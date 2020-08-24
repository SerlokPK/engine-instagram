export default class User {
    constructor(item) {
      this.userId = item.UserId;
      this.email = item.Email;
      this.username = item.Username;
      this.description = item.Description;
      this.status = item.Status;
    }
}