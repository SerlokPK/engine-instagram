namespace Repository
{
    public class BaseRepository
    {
        public InstagramContext GetContext()
        {
            return new InstagramContext();
        }
    }
}
