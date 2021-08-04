using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DAL;


namespace Library.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
        }
    }
}