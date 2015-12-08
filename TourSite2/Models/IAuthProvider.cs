using System.Linq;


namespace TourSite2.Models
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}