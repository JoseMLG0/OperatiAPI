using Microsoft.AspNetCore.Mvc;
using OperatiAPI.Context;
using OperatiAPI.Models;

namespace OperatiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private OperatiContext _operatiContext;

        public UserController(OperatiContext operatiContext)
        {
            _operatiContext = operatiContext;
            _operatiContext.Seed();
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _operatiContext.Users.ToArray<User>();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _operatiContext.Users.FirstOrDefault(s => s.UserId == id);
            return user;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            if (value.Email == null || value.FullName == null || value.Pass == null || !Validations.IsValidEmail(value.Email))
            {
                throw new InvalidOperationException("Datos invalidos");
            }

            _operatiContext.Users.Add(value);
            _operatiContext.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var user = _operatiContext.Users.FirstOrDefault(s => s.UserId == id);
            if (user != null)
            {
                _operatiContext.Entry<User>(user).CurrentValues.SetValues(value);
                _operatiContext.SaveChanges();
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _operatiContext.Users.FirstOrDefault(s => s.UserId == id);
            if (user != null)
            {
                _operatiContext.Users.Remove(user);
                _operatiContext.SaveChanges();
            }
        }
    }

    static class Validations
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}