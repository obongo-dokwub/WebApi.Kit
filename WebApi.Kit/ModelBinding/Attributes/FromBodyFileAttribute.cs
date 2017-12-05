using System;
using WebApi.Kit.ModelBinding.Binders;

namespace WebApi.Kit.ModelBinding.Attributes
{
    /// <summary>
    /// Bind file (files) from body
    /// </summary>
    public class FromBodyFileAttribute : BinderTypeProviderAttribute
    {
        public override Type BinderType
        {
            get { return typeof(BodyFileModelBinder); }
        }

    }
}