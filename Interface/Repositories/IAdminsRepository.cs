namespace Interface.Repositories
{
    public interface IAdminsRepository
    {
        void AssureTestUserExist(string email, string password);
    }
}
