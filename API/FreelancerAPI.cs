using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EFreelancer.Data;
using EFreelancer.Entities;
using EFreelancer.Global;

using EFreelancer.Models.Users;
using EFreelancer.Services;
using EFreelancer.Models.Global;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using EFreelancer.Models.Admin;
using EFreelancer.Global.Enums.Common;
using EFreelancer.Global.Enums.Organization;
using EFreelancer.Global.Enums.Trader;
using EFreelancer.Global.Enums;
using System.Transactions;
using EFreelancer.Global.Enums.Transaction;
using EFreelancer.Models.FreeLancer;
using Microsoft.Extensions.Localization;

namespace EFreelancer.API
{
    [Route("api/Freelancer")]
    public class FreelancerAPI : BaseAPI
    {
        public FreelancerAPI(ApplicationDbContext db, UserManager<UserLogins> um, SignInManager<UserLogins> sm, RoleManager<IdentityRole<int>> rm, IHttpContextAccessor cx) : base(db, um, sm, rm, cx)
        {
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] FreelancerSignUpRequest data)
        {

            IDbContextTransaction transaction = _db.Database.BeginTransaction();

            try
            {
                var existingUser = await _db.Freelancers
                    .Where(u => u.Username == data.Username || u.Email == data.Email)
                    .FirstOrDefaultAsync();

                if (existingUser != null)
                {
                    return Conflict(new APIJsonReturnObject("Username or email already exists"));
                }

                if (data.Password.Length <= 8)
                {
                    return BadRequest(new APIJsonReturnObject("Password must be more than 8 characters long"));
                }
                
                var hashedPassword = HashPassword(data.Password);

                var newUser = new Freelancers()
                {
                    Username = data.Username,
                    Email = data.Email,
                    PhoneNumber = hashedPassword,
                    Password = data.Password,
                    Skillsets = data.Skillsets,
                    Hobby = data.Hobby,
                    DateJoin = data.DateJoined.ToMalaysiaDateTime()
                };

                _db.Freelancers.Add(newUser);
                await _db.SaveChangesAsync();
                transaction.Commit();

                return Ok(new APIJsonReturnObject("User registered successfully"));
            }
            catch (Exception ex)
            {
                await HandleException(ex, null);
                transaction.Rollback();
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIJsonReturnObject("Failed to register user. Please try again later."));
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


    }
}