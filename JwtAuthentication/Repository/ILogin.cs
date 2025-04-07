using JwtAuthentication.Model;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Repository
{
    public interface ILogin
    {
        IEnumerable<Login> Get();
        Login Get(int id);
        void Post([FromBody] Login login);
        void Put([FromBody] Login login);
        void Delete(int id);

    }
}
