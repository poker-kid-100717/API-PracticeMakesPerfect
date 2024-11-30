﻿using API.Data;
using API.Models;
using API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public MeetingsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllMeetings()
        {
            var meetings = dbContext.Meetings.ToList();
            return Ok(meetings);
        }

        [HttpPost]
        public IActionResult AddMeeting(AddMeetingRequestDto request)
        {
            var domainModelMeeting = new Meeting
            {
                Id = Guid.NewGuid(),
                OrganizationName = request.OrganizationName,
                Position = request.Position,
                IsRemote = request.IsRemote,
                PaymentType = request.PaymentType,
                RateHourlyOrSalary = request.RateHourlyOrSalary,
                POCPhone = request.POCPhone,
                Round = request.Round,
                InterviewDateAndTime = request.InterviewDateAndTime,
                ContactId = request.Contact.Id,

            };

            dbContext.Meetings.Add(domainModelMeeting);
            dbContext.SaveChanges();
            return Ok(domainModelMeeting);
        }
    }
}