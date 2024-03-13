using DietitianTrackingSystemApp.Core.GeneralModels;
using System.ComponentModel;
using System.Reflection;

namespace DietitianTrackingSystemApp.Core.Extensions
{
    public static class EnumerationExtensions
    {
        public static List<DropdownDataModel> GetDropdownModel<T>()
        {
            List<DropdownDataModel> dropdownModel = new List<DropdownDataModel>();

            var values = Enum.GetValues(typeof(T));

            for (int i = 0; i < values.Length; i++)
            {
                dropdownModel.Add(new DropdownDataModel
                {
                    Value = Convert.ToInt32(values.GetValue(i)),
                    Key = values.GetValue(i).ToString()
                });
            }

            return dropdownModel;
        }

        public static string GetDescription<T>(this T data)
        {
            FieldInfo fi = data.GetType().GetField(data.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            return data.ToString();
        }

        public static int ToInt<T>(this T data)
        {
            return Convert.ToInt32(data);
        }

        public static byte ToByte<T>(this T data)
        {
            return Convert.ToByte(data);
        }

        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ParseEnum<T>(this byte value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}