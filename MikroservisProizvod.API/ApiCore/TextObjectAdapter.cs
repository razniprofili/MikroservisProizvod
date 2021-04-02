using MikroServisProizvod.Application;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.BaseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.ApiCore
{
    public class TextObjectAdapter
    {
        public string GenerateString(object value)
        {
            if (value is not null)
            {
                if (value is IEnumerable && value.GetType().IsGenericType)
                {
                    return HandleCollection((IEnumerable)value);
                }
                if (value is ILoggableObject)
                {
                    return HandleBaseDtosString(value);
                }
                else
                {
                    return value.ToString();
                }
            }
            return " null ";
        }

        private string HandleBaseDtosString(object value)
        {
            var stringObject = "{ ";
            var properties = value.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(value);
                stringObject += property.Name + " : " + GenerateString(property.GetValue(value)) + ", ";
            }
            stringObject += " }";
            return stringObject;
        }

        private string HandleCollection(IEnumerable value)
        {
            var stringToReturn = "[";
            
                foreach (var singleValue in value)
                {
                    stringToReturn += GenerateString(singleValue) + ", ";
                }
            
            stringToReturn += "]";
            return stringToReturn;
        }
    }
}
