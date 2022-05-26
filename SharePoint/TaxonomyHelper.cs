using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.SharePoint.Client.Taxonomy;

namespace SharePoint
{
    internal static class TaxonomyHelper
    {
        private const string ChildItems = "_Child_Items_";
        private const string ObjectType = "_ObjectType_";

        internal static IEnumerable<string> MapTaxonomy(object value)
        {
            switch (value)
            {
                case TaxonomyFieldValueCollection taxonomyFieldValueCollection:
                    return taxonomyFieldValueCollection.Select(item => item.Label).ToList();
                case Dictionary<string, object> dictionary:
                    return ConvertDictionaryToTaxonomyFieldValueCollection(dictionary).Select(item => item.Label)
                        .ToList();
                default:
                    return Enumerable.Empty<string>();
            }
        }

        private static IEnumerable<TaxonomyFieldValue> ConvertDictionaryToTaxonomyFieldValueCollection(
            IReadOnlyDictionary<string, object> dictionary)
        {
            var childItems = (object[])dictionary[ChildItems];
            return childItems.Select(x => ConvertDictionaryToTaxonomyFieldValue((Dictionary<string, object>)x));
        }

        private static TaxonomyFieldValue ConvertDictionaryToTaxonomyFieldValue(
            IReadOnlyDictionary<string, object> dictionary)
        {
            if (!dictionary.ContainsKey(ObjectType) || !dictionary[ObjectType].Equals("SP.Taxonomy.TaxonomyFieldValue"))
                throw new InvalidOperationException("Dictionary value represents no TaxonomyFieldValue.");

            return new TaxonomyFieldValue
            {
                Label = dictionary["Label"].ToString(),
                TermGuid = dictionary["TermGuid"].ToString(),
                WssId = int.Parse(dictionary["WssId"].ToString(), CultureInfo.InvariantCulture)
            };
        }
    }
}