using System;
using WebApi.Kit.ModelBinding.Binders;

namespace WebApi.Kit.ModelBinding.Attributes
{
    public class FromBodyStringAttribute : BinderTypeProviderAttribute
    {
        public override Type BinderType
        {
            get { return typeof(BodyStringModelBinder); }
        }
    }
}
