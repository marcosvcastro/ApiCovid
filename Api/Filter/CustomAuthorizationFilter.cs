using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Filter {
    public class CustomAuthorizationFilter :IAuthorizationFilter {
        public void OnAuthorization(AuthorizationFilterContext context) {
            /*var listaHeaders = context.HttpContext.Request.Headers.ToList();
            var teste = listaHeaders.FirstOrDefault(x => x.Key == "teste").Value.ToString();
            var rota = context.HttpContext.Request.Path.ToString();


            if (AutorizarRotasExcecoes(rota)) {
                context.Result = new CustomUnauthorizedResult("Rota não permitida");
            }*/

        }
    }

    public class CustomUnauthorizedResult : JsonResult {
        public CustomUnauthorizedResult(string message) : base(new CustomError(message)) {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
    public class CustomError {
        public string Error { get; }

        public CustomError(string message) {
            Error = message;
        }
    }
}
