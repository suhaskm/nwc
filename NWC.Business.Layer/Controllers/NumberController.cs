using log4net;
using NWC.Business.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Number.Business.Layer.Controllers
{
    public class NumberController : ApiController
    {
        private INumberData _service;
        private ILog _logger;

        public NumberController(INumberData service, ILog logger)
        {
            _service = service;
            _logger = logger;

        }
        /// <summary>
        /// Responsible to convert the number to word. API format is GET api/number/5.0/
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/number/{number}")]
        public string Get(double number)
        {
            return _service.ProcessNumbers(number);
           
        }

    }
}
