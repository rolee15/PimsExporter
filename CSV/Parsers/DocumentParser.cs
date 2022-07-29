using Domain.Entities;
using System;
using System.Globalization;

namespace CSV.Parsers
{
    public class DocumentParser<T> where T : class, new()
    {
        public Action<T, string>[] Parsers { get; set; }

        public T ParseFields(string[] fields)
        {
            var entity = new T();
            for (int i = 0; i < fields.Length; i++)
            {
                Parsers[i](entity, fields[i]);
            }
            return entity;
        }
        
        protected DateTime ParseDate(string raw)
        {
            return DateTime.ParseExact(raw, "O", CultureInfo.CurrentCulture);
        }
    }
}