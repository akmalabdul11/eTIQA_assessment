using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Net;
using System.Web;
using System.Text;
using EFreelancer.Data;
using EFreelancer.Entities;
using EFreelancer.Services;
using EFreelancer.Global;
using EFreelancer.Global.Enums.Common;
using EFreelancer.Models.Admin;

using Newtonsoft.Json;

namespace EFreelancer.API
{
    public abstract class BaseAPI : Controller
    {
        protected readonly ApplicationDbContext _db;
        protected readonly UserManager<UserLogins> _um;
        protected readonly SignInManager<UserLogins> _sm;
        protected readonly RoleManager<IdentityRole<int>> _rm;
        // protected readonly IStringLocalizer<BaseAPI> _l;
        protected IHttpContextAccessor _cx;




        public BaseAPI(ApplicationDbContext db, UserManager<UserLogins> um, SignInManager<UserLogins> sm, RoleManager<IdentityRole<int>> rm, IHttpContextAccessor cx)
        {
            _db = db;
            _um = um;
            _sm = sm;
            _rm = rm;
            _cx = cx;
            // _l = l;


        }
        private bool IsProductionEnvironment()
        {
            var environment = Environment.GetEnvironmentVariable("APP_ENVIRONMENT");
            return !string.IsNullOrEmpty(environment) && environment.Equals("Production", StringComparison.OrdinalIgnoreCase);
        }

        protected async Task HandleException(Exception e, string dataString)
        {
            if (IsProductionEnvironment())
            {
                _db.ChangeTracker.Clear();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var ne = new Exceptions()
                {
                    Data = dataString,
                    ExceptionTitle = e.Message,
                    ExceptionType = e.GetType().ToString(),
                    ExceptionMessage = e.StackTrace,
                    DateAdded = DateTime.UtcNow,
                    UserId = 0
                };

                if (!string.IsNullOrEmpty(userId))
                {
                    ne.UserId = Int32.Parse(userId);
                }

                _db.Exceptions.Add(ne);

                await _db.SaveChangesAsync();

                // _es.SendErrorMessageEmail(ne.ExceptionTitle, ne.ExceptionMessage, dataString, ne.DateAdded.ToMalaysiaDateTime().ToString("dd/MM/yyyy h:mm tt"));
            }
        }

        // protected CurrentTraderObj CurrentAdmin
        // {
        //     get
        //     {
        //         var sessionInfo = _cx.HttpContext.Session.GetString(Constants.Common.CurrentAdminClaimKey);

        //         if (sessionInfo != null)
        //         {
        //             return JsonConvert.DeserializeObject<CurrentTraderObj>(sessionInfo);
        //         }
        //         else
        //         {
        //             return null;
        //         }
        //     }
        // }



        protected StatusCodeResult ReturnUnauthorizedStatus()
        {
            return StatusCode((int)HttpStatusCode.Unauthorized);
        }
    }
}



