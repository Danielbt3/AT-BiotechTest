using ATBiotechTest.Dtos;
using ATBiotechTest.Services.Interfaces;
using ATBiotechTest.Services.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ATBiotechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {

        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsService _contactsService;

        public ContactsController(ILogger<ContactsController> logger,
            IContactsService contactsService)
        {
            _logger = logger;
            _contactsService = contactsService;
        }

        [HttpPost("/create")]
        public ActionResult Create(ContactDto input)
        {
            try
            {
                _logger.LogInformation("START Create IP: " + Utilities.GetIpValue(Request));
                _contactsService.Create(input);
                _logger.LogInformation("END Create IP: " + Utilities.GetIpValue(Request));
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR Create IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }

        [HttpPost("/getQuery")]
        public ActionResult<List<ContactDto>> GetQuery(ContactQueryDto input)
        {
            try
            {
                _logger.LogInformation("START GetQuery IP: " + Utilities.GetIpValue(Request));
                var res = _contactsService.Get(input);
                _logger.LogInformation("END GetQuery IP: " + Utilities.GetIpValue(Request));
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR GetQuery IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }

        [HttpPost("/get/{id}")]
        public ActionResult<List<ContactDto>> Get(long id)
        {
            try
            {
                ContactQueryDto tempQuery = new ContactQueryDto();
                tempQuery.Id = id; tempQuery.maxItemsPerPage = 1;
                _logger.LogInformation("START Get IP: " + Utilities.GetIpValue(Request));
                var res = _contactsService.Get(tempQuery);
                _logger.LogInformation("END Get IP: " + Utilities.GetIpValue(Request));
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR Get IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }

        [HttpPut("/update/{id}")]
        public ActionResult<List<ContactDto>> Update(ContactDto input, long id)
        {
            try
            {
                _logger.LogInformation("START Update IP: " + Utilities.GetIpValue(Request));
                _contactsService.Update(input, id);
                _logger.LogInformation("END Update IP: " + Utilities.GetIpValue(Request));
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR Update IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }

        [HttpDelete("/delete")]
        public ActionResult<List<ContactDto>> Delete(long id)
        {
            try
            {
                _logger.LogInformation("START Delete IP: " + Utilities.GetIpValue(Request));
                _contactsService.Delete(id);
                _logger.LogInformation("END Delete IP: " + Utilities.GetIpValue(Request));
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR Delete IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }
    }
}
