using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tdb.Helper.Http
{
    /// <summary>
    /// RestSharp扩展类
    /// </summary>
    public static class RestSharpExtensions
    {
        /// <summary>
        ///     Calls AddParameter() for all public, readable properties specified in the includedProperties list
        /// </summary>
        /// <example>
        ///     request.AddObject(product, "ProductId", "Price", ...);
        /// </example>
        /// <param name="obj">The object with properties to add as parameters</param>
        /// <param name="includedProperties">The names of the properties to include</param>
        /// <returns>This request</returns>
        public static IRestRequest AddGetObject(this IRestRequest restRequest, object obj, params string[] includedProperties)
        {
            // automatically create parameters from object props
            var type = obj.GetType();
            var props = type.GetProperties();

            PropertyParameterHandle propertyParameterHandle = new PropertyParameterHandle();

            foreach (var prop in props)
            {
                var isAllowed = includedProperties.Length == 0 ||
                                includedProperties.Length > 0 && includedProperties.Contains(prop.Name);

                if (!isAllowed)
                    continue;

                var propType = prop.PropertyType;
                var val = prop.GetValue(obj, null);

                if (val == null)
                    continue;

                List<PropertyParameterKeyValue> keyValueParameters = new List<PropertyParameterKeyValue>();
                if (propType.IsPrimitive || propType.IsValueType || propType == typeof(string))
                {
                    keyValueParameters = propertyParameterHandle.HandleNormal(prop.Name, val);
                }
                else if (propType.IsArray)
                {
                    keyValueParameters = propertyParameterHandle.HandleArray(prop.Name, propType, val);
                }
                else if (propType.Name == typeof(List<>).Name || propType.Name == typeof(IList<>).Name)
                {
                    keyValueParameters = propertyParameterHandle.HandleList(prop.Name, propType, val);
                }
                else if (propType.IsClass && !propType.IsValueType)
                {
                    keyValueParameters = propertyParameterHandle.HandleClass(prop.Name, propType, val);
                }
                else
                {
                    keyValueParameters = propertyParameterHandle.HandleNormal(prop.Name, val);
                }

                //AddParameter(prop.Name, val);
                foreach (var item in keyValueParameters)
                {
                    restRequest.AddParameter(item.Key, item.Value);
                }
            }

            return restRequest;
        }

        /// <summary>
        ///     Calls AddParameter() for all public, readable properties of obj
        /// </summary>
        /// <param name="obj">The object with properties to add as parameters</param>
        /// <returns>This request</returns>
        public static IRestRequest AddGetObject(this IRestRequest restRequest, object obj)
        {
            AddGetObject(restRequest, obj, new string[] { });

            return restRequest;
        }
    }
}
