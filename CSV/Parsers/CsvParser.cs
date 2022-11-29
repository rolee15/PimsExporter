using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CSV.Parsers
{
    public class CsvParser<T> where T : class, new()
    {
        private readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");

        public Action<T, string>[] Parsers { get; set; }

        public T ParseFields(string[] fields)
        {
            if (fields.Length != Parsers.Length)
                throw new ArgumentException("Number of columns doesn't match number of parsers!");

            var entity = new T();
            for (int i = 0; i < fields.Length; i++)
            {
                Parsers[i](entity, fields[i]);
            }
            return entity;
        }

        protected bool ParseBool(string raw)
        {
            return raw.ToUpper().Equals("TRUE");
        }

        protected double ParseDouble(string raw)
        {
            return double.Parse(raw, CultureInfo.InvariantCulture);
        }

        protected double? ParseNullableDouble(string raw)
        {
            double? result = null;
            try
            {
                result = double.Parse(raw, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
            }

            return result;
        }

        protected User ParseUser(string raw)
        {
            var pattern = @"([\w-]+,( [\w-]+)+)( <(.*)>)?";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = regex.Match(raw);
            
            if (!match.Success) return null;

            var name = match.Groups[1].Value;
            var email = match.Groups[4].Value;
            
            return new User(name, email);
        }

        protected DateTime? ParseNullableDate(string raw)
        {            
            try
            {
                return DateTime.ParseExact(raw, "O", culture, DateTimeStyles.RoundtripKind);
            }
            catch (FormatException)
            {                
            }

            return null;
        }

        protected IEnumerable<string> ParseListOfStrings(string raw)
        {
            return raw.Split(new string[] { "; " }, StringSplitOptions.None);
        }
    }
}