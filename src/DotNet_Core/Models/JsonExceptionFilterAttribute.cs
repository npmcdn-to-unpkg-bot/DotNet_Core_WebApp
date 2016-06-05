using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bristrong.Official.WebService.Models
{
    public class JsonExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string message = context.Exception.Message;
            context.Result = new JsonResult(new { error = message });

            base.OnException(context);
        }
    }
}
