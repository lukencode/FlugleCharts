using System;
using System.Reflection;

namespace FlugleCharts
{
    internal static class EnumUtils
    {
        public class CodeAttribute : Attribute
        {
            public string Code { get; protected set; }

            public CodeAttribute(string value)
            {
                this.Code = value;
            }
        }

        public static string GetCode(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            CodeAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(CodeAttribute), false) as CodeAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].Code : null;
        }
    }
}
