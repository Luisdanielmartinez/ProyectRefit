
namespace ProyectRefit.Validation
{
    using Plugin.ValidationRules.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class EmailRule<T> : IValidationRule<T>
    {
        //implementacion de la interfaces IValidationRule
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value==null)
            {
                return false;
            }
            var parameter = value as string;
            //aqui verifico si el email esta correcto
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(parameter);

            return match.Success;
        }
    }
}
