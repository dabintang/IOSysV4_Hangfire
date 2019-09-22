using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tdb.Helper.Http
{
    public class PropertyParameterHandle
    {
        /// <summary>
        /// Handle Normal type info,to key/value
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public List<PropertyParameterKeyValue> HandleNormal(string keyName, object val)
        {
            List<PropertyParameterKeyValue> result = new List<PropertyParameterKeyValue>();

            result.Add(new PropertyParameterKeyValue()
            {
                Key = keyName,
                Value = val
            });

            return result;
        }

        /// <summary>
        /// Handle Array type info,to key/value
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="arrayType"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public List<PropertyParameterKeyValue> HandleArray(string keyName, Type arrayType, object val)
        {
            List<PropertyParameterKeyValue> result = new List<PropertyParameterKeyValue>();

            var elementType = arrayType.GetElementType();

            if (((Array)val).Length > 0 &&
                elementType != null)
            {
                if (elementType.IsPrimitive || elementType.IsValueType || elementType == typeof(string))
                {
                    for (int i = 0; i < ((Array)val).Length; i++)
                    {
                        result.Add(new PropertyParameterKeyValue()
                        {
                            Key = keyName + "[" + i.ToString() + "]",
                            Value = ((Array)val).GetValue(i)
                        });
                    }
                }
                else
                {
                    if (elementType == typeof(List<>) || elementType == typeof(IList<>))
                    {
                        for (int i = 0; i < ((Array)val).Length; i++)
                        {
                            string newKeyName = keyName + "[" + i.ToString() + "]";
                            result.AddRange(HandleList(newKeyName, elementType, ((Array)val).GetValue(i)));
                        }
                    }
                    else if (elementType.IsClass && !elementType.IsValueType)
                    {
                        //自定义class
                        for (int i = 0; i < ((Array)val).Length; i++)
                        {
                            string newKeyName = keyName + "[" + i.ToString() + "]";
                            result.AddRange(HandleClass(newKeyName, elementType, ((Array)val).GetValue(i)));
                        }

                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Handle Listt Type info,to key/value
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="listType"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public List<PropertyParameterKeyValue> HandleList(string keyName, Type listType, object val)
        {
            List<PropertyParameterKeyValue> result = new List<PropertyParameterKeyValue>();

            var elementType = listType.GetGenericArguments().FirstOrDefault();

            var listVal = val as IList;

            if (listVal.Count > 0 &&
                elementType != null)
            {
                if (elementType.IsPrimitive || elementType.IsValueType || elementType == typeof(string))
                {
                    for (int i = 0; i < listVal.Count; i++)
                    {
                        result.Add(new PropertyParameterKeyValue()
                        {
                            Key = keyName + "[" + i.ToString() + "]",
                            Value = listVal[i]
                        });
                    }
                }
                else
                {
                    if (elementType == typeof(List<>) || elementType == typeof(IList<>))
                    {
                        for (int i = 0; i < listVal.Count; i++)
                        {
                            var childElementType = listVal[0].GetType();
                            string newKeyName = keyName + "[" + i.ToString() + "]";

                            result.AddRange(HandleList(newKeyName, childElementType, listVal[i]));
                        }
                    }
                    else if (elementType.IsClass && !elementType.IsValueType)
                    {
                        //自定义class
                        for (int i = 0; i < listVal.Count; i++)
                        {
                            var childElementType = listVal[0].GetType();

                            string newKeyName = keyName + "[" + i.ToString() + "]";

                            result.AddRange(HandleClass(newKeyName, childElementType, listVal[i]));
                        }
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// Handle Class Type info,to key/value
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="classType"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public List<PropertyParameterKeyValue> HandleClass(string keyName, Type classType, object val)
        {
            List<PropertyParameterKeyValue> result = new List<PropertyParameterKeyValue>();

            var props = classType.GetProperties();

            foreach (var prop in props)
            {
                var propType = prop.PropertyType;
                var propVal = prop.GetValue(val, null);

                if (propVal == null)
                    continue;

                if (propType.IsPrimitive || propType.IsValueType || propType == typeof(string))
                {
                    result.Add(new PropertyParameterKeyValue()
                    {
                        Key = keyName + "." + prop.Name,
                        Value = propVal
                    });
                }
                else
                {
                    if (propType.Name == typeof(List<>).Name || propType.Name == typeof(IList<>).Name)
                    {
                        string newKeyName = keyName + "." + prop.Name;
                        result.AddRange(HandleList(newKeyName, propType, propVal));
                    }
                    else if (propType.IsClass && !propType.IsValueType)
                    {
                        //自定义class
                        string newKeyName = keyName + "." + prop.Name;

                        result.AddRange(HandleClass(newKeyName, propType, propVal));
                    }
                }
            }

            return result;
        }
    }
}
