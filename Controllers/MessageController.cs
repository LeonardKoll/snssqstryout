using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace snssqstryout.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;
        private readonly IConfiguration _config;

        public MessageController(ILogger<MessageController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public class PostContent
        {
            public string Message { get; set; }
        }

        [HttpPost]
        public void Enqueue ([FromBody] PostContent pst)
        {
            _logger.LogInformation(pst.Message, new object[0]);

            var credentials = new BasicAWSCredentials(_config["accessKey"], _config["secretKey"]);
            var snsClient = new AmazonSimpleNotificationServiceClient(credentials, RegionEndpoint.EUWest1);

            PublishRequest publishRequest = new PublishRequest(_config["arn"], pst.Message);
            PublishResponse publishResponse = snsClient.PublishAsync(publishRequest).Result;
        }
    }
}
