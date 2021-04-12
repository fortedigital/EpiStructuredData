using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiStructuredData.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EpiStructuredData
{
    public static class StructuredDataBuilder
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
            {NullValueHandling = NullValueHandling.Ignore, Converters = new List<JsonConverter> {new StringEnumConverter()}};

        public static HtmlString StructuredData(this HtmlHelper html, ContentReference contentReference)
        {
            if (contentReference == null) return null;
            
            ServiceLocator.Current.GetInstance<IContentLoader>().TryGet(contentReference, out IContentData data);

            var result = new StringBuilder();

            GetByAttributes(result, data);
            GetByInterfaces(result, data);
            GetCustomStructuredData(result, data);
            
            return new HtmlString(result.ToString());
        }

        private static void GetByAttributes(StringBuilder result, object data)
        {
            foreach (var attr in data.GetType().GetCustomAttributes<StructuredDataAttribute>())
            {
                if (!(ServiceLocator.Current.GetInstance(attr.GeneratorType) is IStructuredDataGenerator generator)) continue;

                var structuredData = generator.GetStructuredData(data);
                AppendStructuredData(result, structuredData);
            }
        }

        private static void GetByInterfaces(StringBuilder result, object data)
        {
            var factoryInterfaces = data.GetType().GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IStructuredDataFactory<>));

            foreach (var factoryInterface in factoryInterfaces)
            {
                var structuredData = factoryInterface.GetMethod(nameof(IStructuredDataFactory<object>.GetStructuredData))?.Invoke(data, null);
                AppendStructuredData(result, structuredData);
            }
        }

        private static void GetCustomStructuredData(StringBuilder result, object data)
        {
            if (!(data is IStructuredDataSource structuredDataSource)) return;

            if (structuredDataSource.StructuredData.Models == null) return;
            
            foreach (var model in structuredDataSource.StructuredData.Models)
            {
                result.AppendLine(GetScriptTag(model));
            }
        }

        private static void AppendStructuredData(StringBuilder result, object structuredData)
        {
            if (structuredData == null) return;
            var serializedData = JsonConvert.SerializeObject(structuredData, Formatting.None, SerializerSettings);
            result.AppendLine(GetScriptTag(serializedData));
        }

        private static string GetScriptTag(string structuredData)
        {
            var e = new TagBuilder("script");
            e.Attributes.Add("type", "application/ld+json");
            e.InnerHtml = structuredData;
            return e.ToString();
        }
    }
}