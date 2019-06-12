using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlackSeaConstruction.Web.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static Dictionary<int, string> GetStatusPairs()
        {
            var dictionary = new Dictionary<int, string>();
            foreach (Status item in Enum.GetValues(typeof(Status)))
            {
                var description = item.GetDescription();
                var id = (int)item;
                dictionary.Add(id, description);
            }
            return dictionary;
        }
    }
}
