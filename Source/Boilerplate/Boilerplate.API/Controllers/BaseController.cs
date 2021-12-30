using System;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers
{
	[Route("[controller]")]
	[Produces("application/json")]
	public class BaseController : ControllerBase
	{
		public BaseController()
		{
		}
	}
}

