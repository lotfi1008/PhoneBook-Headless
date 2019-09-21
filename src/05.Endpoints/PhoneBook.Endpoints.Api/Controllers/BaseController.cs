using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.Api.Infrastractures.Filters;

namespace PhoneBook.Endpoints.Api.Controllers
{
    [ApiResultFilter]
    public class BaseController : ControllerBase
    {
        
    }
}