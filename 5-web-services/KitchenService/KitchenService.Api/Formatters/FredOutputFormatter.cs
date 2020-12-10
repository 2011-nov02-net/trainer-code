using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace KitchenService.Api.Formatters
{
    public class FredOutputFormatter : TextOutputFormatter
    {
        public FredOutputFormatter()
        {
            SupportedMediaTypes.Add("application/fred");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            await context.HttpContext.Response.WriteAsync("{ \"fred\": true }");
        }
    }
}
