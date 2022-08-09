using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePoint.Extensions
{
    public static class FieldUserValueExtensions
    {
        private static Type type = typeof(FieldUserValue);
        public static void SetEmail(this FieldUserValue fieldUserValue, string email)
        {
            var prop = type.GetField("m_email", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(fieldUserValue, email);
        }
    }
}
