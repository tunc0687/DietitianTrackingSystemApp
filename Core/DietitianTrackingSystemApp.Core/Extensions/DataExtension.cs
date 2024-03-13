using System.Collections;
using System.ComponentModel;

namespace DietitianTrackingSystemApp.Core.Extensions
{
    public static class DataExtension
    {
        public static bool HasValue<T>(this T data)
        {
            var t = typeof(T);

            if (data == null)
            {
                return false;
            }

            if (data is String str && string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (t.IsGenericType && (data is IList list && list.Count == 0) || (data is Array array && array.Length == 0))
            {
                return false;
            }

            return true;
        }

        public static T ToConvert<T>(this object value)
        {
            Type conversionType = typeof(T);

            if (value == null)
            {
                return default(T);
            }

            if (conversionType == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value.ToString());
            }
            else
            {
                if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    conversionType = Nullable.GetUnderlyingType(conversionType);
                }

                return (T)Convert.ChangeType(value, conversionType);
            }
        }

        public static object ToConvert(this object value, Type conversionType)
        {
            if (value == null)
            {
                return default;
            }

            if (conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());
            }
            else
            {
                if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    conversionType = Nullable.GetUnderlyingType(conversionType);
                }

                return Convert.ChangeType(value, conversionType);
            }
        }
    }
}