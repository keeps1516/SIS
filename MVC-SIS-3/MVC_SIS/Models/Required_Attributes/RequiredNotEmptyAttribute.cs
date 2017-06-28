using Exercises.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models
{
    public class RequiredNotEmptyAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
               if(string.IsNullOrEmpty((string) value)) 
               {
                    return false;

               }
                

            return base.IsValid(value);
        }

    }
}