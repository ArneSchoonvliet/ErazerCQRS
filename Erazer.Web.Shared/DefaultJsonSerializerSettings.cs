﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Erazer.Web.Shared
{
    public class DefaultJsonSerializerSettings
    {
        public static JsonSerializerSettings DefaultSettings { get; private set; }

        static DefaultJsonSerializerSettings()
        {
            DefaultSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                FloatFormatHandling = FloatFormatHandling.DefaultValue,
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                TypeNameHandling = TypeNameHandling.All
            };
        }
    }
}
