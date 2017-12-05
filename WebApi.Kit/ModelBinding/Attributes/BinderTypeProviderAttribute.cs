using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace WebApi.Kit.ModelBinding.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public abstract class BinderTypeProviderAttribute : Attribute, IModelNameProvider,
        IBinderTypeProviderMetadata, IBindingSourceMetadata
    {
        public abstract Type BinderType
        {
            get;
        }

        public virtual BindingSource BindingSource
        {
            get { return BindingSource.Custom; }
        }

        public string Name
        {
            get; set;
        }
    }
}
