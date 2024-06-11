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
using Microsoft.Extensions.Localization;

namespace EFreelancer.API
{
    [Route("api/Admin")]
    public class AdminAPI : BaseAPI
    {
        public AdminAPI(ApplicationDbContext db, UserManager<UserLogins> um, SignInManager<UserLogins> sm, RoleManager<IdentityRole<int>> rm, IHttpContextAccessor cx) : base(db, um, sm, rm, cx)
        {
        }
        [HttpGet("Freelancer")]
        public async Task<IActionResult> GetFreelancerList(int pageIndex, int pageSize, string sortField, string sortOrder, string filterFreelancerUserName, int? filterDateJoined, DateTime? filterDateJoinedStart, DateTime? filterDateJoinedEnd)
        {
            // var ca = CurrentAdmin;

            // if (ca == null)
            // {
            //     return ReturnUnauthorizedStatus();
            // }

            try
            {
                var freelancer = _db.Freelancers.AsQueryable();

                switch (sortField)
                {
                    case "username":
                        if (sortOrder == "asc")
                        {
                            freelancer = freelancer.OrderBy(s => s.Username);
                        }
                        else
                        {
                            freelancer = freelancer.OrderByDescending(s => s.Username);
                        }
                        break;

                    case "dateJoined":
                        if (sortOrder == "asc")
                        {
                            freelancer = freelancer.OrderBy(s => s.DateJoin);
                        }
                        else
                        {
                            freelancer = freelancer.OrderByDescending(s => s.DateJoin);
                        }
                        break;
                    default:
                        freelancer = freelancer.OrderByDescending(s => s.DateJoin);
                        break;
                }

                if (filterFreelancerUserName != null)
                {
                    freelancer = freelancer.Where(s => s.Username.Contains(filterFreelancerUserName));
                }

                var freeCount = await freelancer.CountAsync();
                var fln = await freelancer.Skip((pageIndex - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

                var userDetailsList = new AdminFreeLancerList()
                {
                    FreelancerList = new List<AdminFreeLancerDetails>(),
                    ItemsCount = freeCount
                };

                foreach (var user in fln)
                {
                    var userDetails = new AdminFreeLancerDetails()
                    {
                        FreeLancerId = user.FreelancerId,
                        Username = user.Username,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Skillsets = user.Skillsets,
                        Hobby = user.Hobby,
                        DateJoined = user.DateJoin.ToMalaysiaDateTime().ToString("dd/MM/yyyy hh:mmtt")
                    };

                    userDetailsList.FreelancerList.Add(userDetails);
                }

                return Ok(new APIJsonReturnObject(userDetailsList));
            }
            catch (Exception ex)
            {
                await HandleException(ex, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIJsonReturnObject("Failed to fetch Freelancer Details. Please try again later."));
            }
        }

        [HttpGet("Freelance/{freeLancerId}/FreelancerDetails")]
        public async Task<IActionResult> GetFreelancerDetails(int freeLancerId)
        {
            // var ca = CurrentAdmin;

            // if (ca == null)
            // {
            //     return ReturnUnauthorizedStatus();
            // }

            try
            {
                var user = await _db.Freelancers.
                Where(x => x.FreelancerId == freeLancerId).
                FirstAsync();

                if (user == null)
                {
                    return NotFound(new APIJsonReturnObject("User not found"));
                }

                var freelancerD = new AdminFreeLancerDetail()
                {
                    FreeLancerId = user.FreelancerId,
                    Username = user.Username,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Skillsets = user.Skillsets,
                    Hobby = user.Hobby,
                    DateJoined = user.DateJoin.ToString("dd/MM/yyyy hh:mmtt")
                };

                return Ok(new APIJsonReturnObject(freelancerD));
            }
            catch (Exception ex)
            {
                await HandleException(ex, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIJsonReturnObject("Failed to fetch Freelancer Details. Please try again later."));
            }
        }

        [HttpPut("Freelancer/{id}/UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] AdminFreeLancerDetail data)
        {
            try
            {
                var user = await _db.Freelancers.
                Where(x => x.FreelancerId == id)
                .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(new APIJsonReturnObject("User not found"));
                }

                user.Username = data.Username;
                user.Email = data.Email;
                user.PhoneNumber = data.PhoneNumber;
                user.Skillsets = data.Skillsets;
                user.Hobby = data.Hobby;

                _db.Freelancers.Update(user);
                await _db.SaveChangesAsync();

                return Ok(new APIJsonReturnObject(data));
            }
            catch (Exception ex)
            {
                await HandleException(ex, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIJsonReturnObject("Failed to update user. Please try again later."));
            }
        }

        [HttpDelete("Freelancer/{id}/DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _db.Freelancers.
                Where(x => x.FreelancerId == id)
                .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(new APIJsonReturnObject("User not found"));
                }

                _db.Freelancers.Remove(user);
                await _db.SaveChangesAsync();

                return Ok(new APIJsonReturnObject("User deleted successfully"));
            }
            catch (Exception ex)
            {
                await HandleException(ex, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIJsonReturnObject("Failed to delete user. Please try again later."));
            }
        }

    }
}