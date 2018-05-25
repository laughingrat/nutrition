using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Nutrition.Models;
using System.Web.Security;
using System.Web;

using Nutrition.Authentication;


namespace Nutrition.Controllers
{
    public class UsersController : ApiController
    {
        private NutritionContext db = new NutritionContext();

        // GET: api/Users
        [RequestAuthorize]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        [RequestAuthorize]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //POST: api/Users
       [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        [HttpPost]
        [Route("api/Users/Login")]
        public async Task<IHttpActionResult> Login(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password))
            {
                User loginUser = db.Users
                            .Where(u => u.Username == user.Username || u.Phone == user.Username)
                            .FirstOrDefault();

                if (loginUser != null)
                {
                    if (loginUser.Password == user.Password)
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, loginUser.Username, DateTime.Now, DateTime.Now.AddDays(1),
                            true, string.Format("{0}:{1}", loginUser.Username, loginUser.UserId), FormsAuthentication.FormsCookiePath);

                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                        cookie.HttpOnly = true;
                        HttpContext.Current.Response.Cookies.Add(cookie);

                        return Ok();
                    }
                }
            }

            return BadRequest("用户名或密码不正确。");
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}