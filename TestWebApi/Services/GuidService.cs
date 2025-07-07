namespace TestWebApi.Services
{
    public interface IGuidService
    {
        string GetGuid();
    }

    public class GuidService : IGuidService
    {
        private readonly string _guid;

        public GuidService()
        {
            Random rnd = new Random();
            int month = rnd.Next(100000);
            _guid = Convert.ToString(month);
            //_guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return _guid;
        }
    }

}
