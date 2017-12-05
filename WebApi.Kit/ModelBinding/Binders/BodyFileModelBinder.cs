using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApi.Kit.ModelBinding.Binders
{
    /// <summary>
    /// If ModelType binding context is byte[] or stream, bind body to stream. 
    /// If is it enumerable, bind it to enumerable IFile,
    /// If is it IFormFile bind it to IFormFile file.
    /// </summary>
    public class BodyFileModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.HttpContext.Request.ContentLength > 0)
            {
                if (bindingContext.ModelType == typeof(byte[]))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        bindingContext.HttpContext.Request.Body.CopyTo(memoryStream);

                        byte[] fileBytes = memoryStream.ToArray();

                        bindingContext.Result = ModelBindingResult.Success(fileBytes);
                    }
                }
                else if (bindingContext.ModelType == typeof(Stream))
                {
                    Stream fileStream = bindingContext.HttpContext.Request.Body;

                    bindingContext.Result = ModelBindingResult.Success(fileStream);
                }
                else if (bindingContext.ModelType == typeof(IEnumerable<IFormFile>))
                {
                    IFormFileCollection fileStreams = bindingContext.HttpContext.Request.Form.Files;
                    bindingContext.Result = ModelBindingResult.Success(fileStreams);
                }
                else if (bindingContext.ModelType == typeof(IFormFile))
                {
                    IFormFile formFile = bindingContext.HttpContext.Request.Form.Files[bindingContext.FieldName] ??
                        bindingContext.HttpContext.Request.Form.Files[0];
                    bindingContext.Result = ModelBindingResult.Success(formFile);
                }
            }

            return Task.FromResult(0);
        }
    }
}