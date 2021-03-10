﻿using Favolog.Service.Models;
using Favolog.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Favolog.Service.Controllers
{
    [ApiController]
    [Authorize(Policy = "access")]
    [Route("api/[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly IFavologRepository _repository;
        public FeedController(IFavologRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("user/{id}")]        
        public ActionResult GetUser([FromRoute] int id)
        {
            var user = _repository.Get<User>(id).SingleOrDefault();
            if (user == null)
                return NotFound();

            var feedUserIds = _repository.Get<UserFollow>().Where(f => f.FollowerId == user.Id).Select(f => f.UserId).ToList();
            feedUserIds.Add(user.Id.Value);

            var result = _repository.Get<UserFeed>().Where(f => feedUserIds.Contains(f.UserId)).OrderByDescending(f=>f.Id).ToList();

            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            var result = _repository.Get<UserFeed>().OrderByDescending(f => f.Id).Take(20).ToList();

            return Ok(result);
        }
    }
}
