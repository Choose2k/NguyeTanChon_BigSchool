using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NguyenTanChon_BigSchool.Models;

namespace NguyenTanChon_BigSchool.Controllers
{
        public class AttendencesController : ApiController
        {
            [HttpPost]
            public IHttpActionResult Attend(Course attendenceDto)
            {
                var userID = User.Identity.GetUserId();
                BigSchoolContext context = new BigSchoolContext();
                if (context.Attendences.Any(p => p.Attendee == userID && p.CourseId == attendenceDto.Id))
                {
                    context.Attendences.Remove(context.Attendences.SingleOrDefault(p =>
                    p.Attendee == userID && p.CourseId == attendenceDto.Id));
                    context.SaveChanges();
                    return Ok("cancel");
                    //return BadRequest("the attendence already exists");
                }
                var attendence = new Attendence()
                {
                    CourseId = attendenceDto.Id,
                    Attendee = User.Identity.GetUserId()
                };
                context.Attendences.Add(attendence);
                context.SaveChanges();
                return Ok();
            }
        }
}
