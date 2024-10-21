using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.ComponentModel;


namespace DotNet.ApplicationCore.Utils.Enums
{
    public static class EnumExtensions
    {
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            string displayName = "";
            if (enumValue != null)
            {
                displayName = enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .FirstOrDefault()?
                    .GetCustomAttribute<DisplayAttribute>()?
                    .GetName();
                if (String.IsNullOrEmpty(displayName))
                {
                    displayName = enumValue.ToString();
                }
            }
            return displayName;
        }
        public static string GetEnumDescription(this Enum value)
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
        }
    }
}
