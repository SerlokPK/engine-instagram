using Common;
using Common.Constants;
using Common.Helpers;
using Interface.Repositories;
using Models.Account;
using Models.Users;
using System;
using System.Linq;

namespace Repository.Account
{
    public class AccountsRepository : BaseRepository, IAccountsRepository
    {
        public UserActivated ActivateAccount(string userKey)
        {
            using (var context = GetContext())
            {
                var user = context.Users.SingleOrDefault(u => u.UserKey == userKey && u.Status == UserStatus.Pending.Status);
                if (user != null)
                {
                    user.Status = UserStatus.Active.Status;
                    context.SaveChanges();

                    return new UserActivated
                    {
                        Email = user.Email,
                        Username = user.Username
                    };
                }

                return null;
            }
        }

        public UserReset ForgotPassword(string email)
        {
            using (var context = GetContext())
            {
                if (string.IsNullOrEmpty(email))
                {
                    return null;
                }

                var user = context.Users.SingleOrDefault(x => x.Email == email);

                if (user != null)
                {
                    user.ResetKey = PasswordHelper.GenerateUniqueKey(Common.Constants.Account.UniqueKeyLength);
                    user.ResetKeyTime = DateTime.Now.AddMinutes(AppSettings.ResetKeyDurationInMinutes);
                    context.SaveChanges();

                    return new UserReset()
                    {
                        Username = user.Username,
                        Email = user.Email,
                        ResetKey = user.ResetKey,
                        ResetKeyTime = user.ResetKeyTime
                    };
                }

                return null;
            }
        }

        public UserAuth Login(string email, string password)
        {
            using (var context = GetContext())
            {
                if (string.IsNullOrEmpty(password))
                {
                    return null;
                }

                var user = context.Users.SingleOrDefault(x => x.Email == email);
                if (user == null)
                {
                    return null;
                }

                if (user.Status != UserStatus.Active.Status)
                {
                    return new UserAuth()
                    {
                        User = new User
                        {
                            UserId = user.UserId,
                            Status = user.Status,
                            Email = user.Email
                        },
                    };
                }

                var shaPassword = HashHelper.Hash(user.PasswordSalt + password);
                if (!shaPassword.SequenceEqual(user.Password.ToArray()))
                {
                    return null;
                }

                var userAuth = new UserAuth
                {
                    User = new User
                    {
                        UserId = user.UserId,
                        Status = user.Status,
                        Email = user.Email,
                        Username = user.Username,
                        Description = user.Description
                    },
                };

                user.LastLogin = DateTime.Now;

                var logId = context.UserLogs.Any(l => l.UserId == user.UserId) ? context.UserLogs.Where(l => l.UserId == user.UserId).Max(l => l.LogId) + 1 : 1;

                context.UserLogs.Add(new Data.UserLog
                {
                    UserId = userAuth.User.UserId,
                    LogId = logId,
                    LogKey = PasswordHelper.GenerateUniqueKey(Common.Constants.Account.UniqueKeyLength),
                    LogTime = DateTime.Now
                });

                context.SaveChanges();

                return userAuth;
            }
        }
        public RegisteredUser Register(string email, string username, string password, string confirmPassword)
        {
            using (var context = GetContext())
            {
                if (context.Users.Any(u => u.Email == email))
                {
                    return null;
                }
                if (context.Users.Any(u => u.Username == username))
                {
                    return new RegisteredUser { ErrorMessage = Localization.Register_UsernameTaken };
                }

                var saltPassword = PasswordHelper.GenerateRandomPassword(Common.Constants.Account.UniqueKeyLength, false, false);
                var shaPassword = HashHelper.Hash(saltPassword + password);
                var userId = context.Users.Any() ? context.Users.Max(x => x.UserId) + 1 : 1;

                var newUser = new Data.User
                {
                    UserId = userId,
                    Username = username,
                    Password = shaPassword,
                    PasswordSalt = saltPassword,
                    Created = DateTime.Now,
                    Status = UserStatus.Pending.Status,
                    UserKey = PasswordHelper.GenerateUniqueKey(Common.Constants.Account.UniqueKeyLength),
                    ResetKey = PasswordHelper.GenerateUniqueKey(Common.Constants.Account.UniqueKeyLength),
                    Email = email,
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return new RegisteredUser { UserId = userId, UserKey = newUser.UserKey };
            }
        }
    }
}
