using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Kit.ModelBinding.Binders
{
    public class BodyStringModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.HttpContext.Request.ContentLength > 0)
            {
                if (bindingContext.ModelType == typeof(string))
                {
                    string value = bodyToString(bindingContext.HttpContext.Request.Body);

                    bindingContext.Result = ModelBindingResult.Success(value);
                }
            }

            return Task.FromResult(0);
        }

        private string bodyToString(Stream bodyStream)
        {
            using (var reader = new StreamReader(bodyStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
