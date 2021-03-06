using System;
using System.Collections.Generic;
using JssBlazor.Core.Models.LayoutService.Fields;
using Newtonsoft.Json;

namespace JssBlazor.Core.Models.LayoutService
{
    public class ComponentDefinition : IRendering
    {
        public Guid? Uid { get; set; }
        public string ComponentName { get; set; }
        public Guid? DataSource { get; set; }

        [JsonProperty(ItemConverterType = typeof(FieldJsonConverter))]
        public IDictionary<string, Field> Fields { get; set; }

        public IDictionary<string, IEnumerable<ComponentDefinition>> Placeholders { get; set; }
        public IDictionary<string, string> Params { get; set; }

        // Properties used by "raw components"
        public string Name { get; set; }
        public string Type { get; set; }
        public string Contents { get; set; }
        public IDictionary<string, string> Attributes { get; set; }
    }
}
