using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace KitchenService.Api.Formatters
{
    public class FredInputFormatter : TextInputFormatter
    {
        public FredInputFormatter()
        {
            SupportedMediaTypes.Add("application/fred");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public async override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            return await InputFormatterResult.SuccessAsync(new { fred = true });
        }
    }
}
