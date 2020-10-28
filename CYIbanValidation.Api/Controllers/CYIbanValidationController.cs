using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CYIbanValidaitonLib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CYIbanValidation.Api.Controllers
{
    [ApiController]
    public class CYIbanValidationController : ControllerBase
    {
        private readonly ILogger<CYIbanValidationController> _logger;
        private readonly ICYIbanValidator _cyIbanValidator;

        public CYIbanValidationController(ILogger<CYIbanValidationController> logger, ICYIbanValidator cyIbanValidator)
        {
            _logger = logger;
            _cyIbanValidator = cyIbanValidator;
        }

        [HttpGet]
        [Route("validate-cy-iban")]
        public bool ValidateCYIban(string iban)
        {
            return _cyIbanValidator.CheckIban(iban);
        }
    }
}
