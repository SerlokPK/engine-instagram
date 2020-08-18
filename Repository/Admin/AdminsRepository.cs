using Common.Helpers;
using Interface.Repositories;
using Models.Users;
using System;
using System.Linq;

namespace Repository.Admin
{
    public class AdminsRepository : BaseRepository, IAdminsRepository
    {
        private const int DefaultUserId = 1;
        public void AssureTestUserExist(string email, string password)
        {
            using (var context = GetContext())
            {
                var user = context.Users.SingleOrDefault(u => u.UserId == DefaultUserId);
                var saltPassword = PasswordHelper.GenerateRandomPassword(Common.Constants.Account.UniqueKeyLength, false, false);
                var shaPassword = HashHelper.Hash(saltPassword + password);
                if (user != null)
                {
                    user.Email = email;
                    user.Password = shaPassword;
                    user.PasswordSalt = saltPassword;
                }
                else
                {
                    context.Users.Add(new Data.User
                    {
                        UserId = DefaultUserId,
                        Email = email,
                        Password = shaPassword,
                        PasswordSalt = saltPassword,
                        Status = UserStatus.Active.Status,
                        Username = "Serlok",
                        Created = DateTime.Now
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
