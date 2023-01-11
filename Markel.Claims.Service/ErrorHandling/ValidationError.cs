using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Markel.Claims.Service
{
    public class ValidationError
    {
        public string Field { get; }
        public int Code { get; set; }
        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }

}
