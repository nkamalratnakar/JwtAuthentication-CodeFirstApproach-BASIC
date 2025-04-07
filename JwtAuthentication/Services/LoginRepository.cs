using JwtAuthentication.Data;
using JwtAuthentication.Model;
using JwtAuthentication.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace JwtAuthentication.Services
{
    public class LoginRepository : ILogin
    {
        private readonly AppDataContext _appDataContext;
        public LoginRepository(AppDataContext appDataContext)
        {
            _appDataContext= appDataContext;
        }
        public void Delete(int id)
        {
            var user = _appDataContext.Logins.FirstOrDefault(u => u.LoginId == id);
            _appDataContext.Remove(user);
            _appDataContext.SaveChanges();
        }

        public IEnumerable<Login> Get()
        {
            return _appDataContext.Logins.ToList();
        }

        public Login Get(int id)
        {
            return _appDataContext.Logins.FirstOrDefault(u => u.LoginId == id);
        }

        public void Post([FromBody] Login login)
        {
            _appDataContext.Logins.Add(login);
            _appDataContext.SaveChanges();
        }

        public void Put([FromBody] Login login)
        {
            var user = _appDataContext.Logins.FirstOrDefault(u => u.LoginId == login.LoginId);
            
            user.Username = login.Username;
            user.Role = login.Role;
            _appDataContext.SaveChanges();

        }
    }
}
