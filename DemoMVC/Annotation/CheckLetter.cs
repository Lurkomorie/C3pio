using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Annotation
{
    public class CheckLetter: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null) { return false; }
            string fieldValue = value.ToString();
            return !fieldValue.ToUpper().StartsWith("A");
        }
    }
}