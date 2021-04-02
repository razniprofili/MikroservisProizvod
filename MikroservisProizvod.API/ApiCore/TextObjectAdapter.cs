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
                    return HandleCollection(value);
                }
                if (value is ITrackableObject)
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

        private string HandleCollection(object value)
        {
            var stringToReturn = "[";
            var genericType = value.GetType().GetGenericArguments().FirstOrDefault();
            if (genericType == typeof(int))
            {
                foreach (var singleValue in (IEnumerable<int>)value)
                {
                    stringToReturn += GenerateString(singleValue) + ", ";
                }
            }
            else if (genericType == typeof(long))
            {
                foreach (var singleValue in (IEnumerable<long>)value)
                {
                    stringToReturn += GenerateString(singleValue) + ", ";
                }
            }
            else
            {
                foreach (var singleValue in (IEnumerable<object>)value)
                {
                    stringToReturn += GenerateString(singleValue) + ", ";
                }
            }
            stringToReturn += "]";
            return stringToReturn;
        }
    }
}
