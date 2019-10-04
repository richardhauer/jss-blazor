using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JssBlazor.Core.Models.LayoutService.Fields
{
    public class Field
    {
        [JsonConverter(typeof(FieldValueJsonConverter))]
        public IFieldValue Value { get; set; }

        public string Editable { get; set; }

        public string Src { get; set; }

        public string Title { get; set; }

        public string DisplayName { get; set; }

        public T GetFieldValue<T>()
        {
            var rawValue = Value?.RawValue;
            if (rawValue == null) return default;
            return rawValue.Value<T>();
        }

        public T GetFieldValue<T>(string key)
        {
            var rawValue = Value?.RawValue?[key];
            if (rawValue == null) return default;
            return rawValue.Value<T>();
        }
    }
}
