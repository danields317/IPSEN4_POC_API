using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileData.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {

        readonly ProfileContext context;
        public ProfileController(ProfileContext ProfileContext)
        {
            context = ProfileContext;
        }

        [HttpGet]
        public IActionResult getProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            try
            {
                profiles = context.profile.ToList();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(profiles);
        }

        [HttpPost]
        public IActionResult PostProfile(Profile profile)
        {
            try
            {
                context.Add(profile);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Id already in use");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id)
        {
            try
            {
                context.profile.Remove(context.profile.Find(id));
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Something went wrong");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutProfile(int id, Profile profile)
        {

            if (id != profile.profile_id)
            {
                return BadRequest("ID's do not match");
            }

            try
            {
                var db_profile = context.profile.Find(id);
                if (db_profile == null) 
                {
                    return BadRequest("Profile with id " + id +" does not exist.");
                }
                db_profile.first_name = profile.first_name;
                db_profile.enabled = profile.enabled;
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Something went wrong");
            }
            return NoContent();
        }
    }
}