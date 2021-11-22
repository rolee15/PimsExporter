using Microsoft.SharePoint.Client.Taxonomy;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePoint
{
    internal static class TaxonomyHelper
    {
        private const string ChildItems = "_Child_Items_";
        private const string ObjectType = "_ObjectType_";
        internal static IEnumerable<string> MapTaxonomy(object value)
        {

            var taxonomyFieldValueCollection = value as TaxonomyFieldValueCollection;
            if (taxonomyFieldValueCollection != null)
            {
                return taxonomyFieldValueCollection.Select(item => item.Label).ToList();
            }

            var dictionary = value as Dictionary<string, object>;
            if (dictionary != null)
            {
                return ConvertDictionaryToTaxonomyFieldValueCollection(dictionary).Select(item => item.Label).ToList();
            }


            return Enumerable.Empty<string>();
        }

        private static List<TaxonomyFieldValue> ConvertDictionaryToTaxonomyFieldValueCollection(Dictionary<string, object> dictionary)
        {


            var list = new List<TaxonomyFieldValue>();
            foreach (var value in (object[])dictionary[ChildItems])
            {
                var childDictionary = (Dictionary<string, object>)value;
                list.Add(ConvertDictionaryToTaxonomyFieldValue(childDictionary));
            }

            return list;
        }

        private static TaxonomyFieldValue ConvertDictionaryToTaxonomyFieldValue(Dictionary<string, object> dictionary)
        {

            if (!dictionary.ContainsKey(ObjectType) || !dictionary[ObjectType].Equals("SP.Taxonomy.TaxonomyFieldValue"))
            {
                throw new InvalidOperationException("Dictionary value represents no TaxonomyFieldValue.");
            }

            return new TaxonomyFieldValue
            {
                Label = dictionary["Label"].ToString(),
                TermGuid = dictionary["TermGuid"].ToString(),
                WssId = int.Parse(dictionary["WssId"].ToString(), CultureInfo.InvariantCulture)
            };
        }
    }
}
