

namespace ProyectRefit.Validation
{
    using Plugin.ValidationRules.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ValidationIsNull<T> : IValidationRule<T>
    {
        public string ValidationMessage { get ; set ; }

        public bool Check(T value)
        {
            if (value==null)
            {
                return false;
            }
            var parameter = value as string;
            return !string.IsNullOrWhiteSpace(parameter);
        }
    }
}
