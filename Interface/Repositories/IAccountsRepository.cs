﻿using Models.Account;

namespace Interface.Repositories
{
    public interface IAccountsRepository
    {
        UserAuth Login(string email, string password);
        RegisteredUser Register(string email, string username, string password, string confirmPassword);
        UserActivated ActivateAccount(string userKey);
        UserReset ForgotPassword(string email);
        UserReset ResetPassword(string password, string resetKey);
    }
}
