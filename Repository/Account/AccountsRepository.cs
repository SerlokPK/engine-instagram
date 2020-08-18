using Common.Helpers;
using Interface.Repositories;
using Models.Users;
using System;
using System.Linq;

namespace Repository.Account
{
    public class AccountsRepository : BaseRepository, IAccountsRepository
    {
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
    }
}
