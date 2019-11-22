

namespace QuickType
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
     
        public partial class Welcome
        {
            [JsonProperty("package")]
            public Package[] Package { get; set; }
        }

        public partial class Package
        {
            [JsonProperty("availability")]
            public Availability Availability { get; set; }

            [JsonProperty(" basedUpon")]
            public BasedUpon BasedUpon { get; set; }

            [JsonProperty(" checkSum")]
            public string CheckSum { get; set; }

            [JsonProperty(" fileName")]
            public string FileName { get; set; }

            [JsonProperty(" fileSize")]
            public string FileSize { get; set; }

            [JsonProperty(" isForced")]
            public IsForced IsForced { get; set; }

            [JsonProperty(" name")]
            public string Name { get; set; }

            [JsonProperty(" requires")]
            public BasedUpon Requires { get; set; }

            [JsonProperty(" system")]
            public SystemEnum System { get; set; }

            [JsonProperty(" type")]
            public TypeEnum Type { get; set; }

            [JsonProperty(" url")]
            public Url Url { get; set; }

            [JsonProperty(" version")]
            public string Version { get; set; }

            [JsonProperty("priority")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Priority { get; set; }
        }

        public enum Availability { ForDeliveringThroughApi };

        public enum BasedUpon { Empty };

        public enum IsForced { False };

        public enum SystemEnum { AdminClient, HddUpdate, IspaServer, IstaLauncher, IstaNf, IstaP, IstaSdp, KeyReader };

        public enum TypeEnum { The1, The2 };

        public enum Url { Http127001 };

        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }

   

    internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                BasedUponConverter.Singleton,
                IsForcedConverter.Singleton,
                SystemEnumConverter.Singleton,
                TypeEnumConverter.Singleton,
                UrlConverter.Singleton,
                AvailabilityConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class BasedUponConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(BasedUpon) || t == typeof(BasedUpon?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == " ")
                {
                    return BasedUpon.Empty;
                }
                throw new Exception("Cannot unmarshal type BasedUpon");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (BasedUpon)untypedValue;
                if (value == BasedUpon.Empty)
                {
                    serializer.Serialize(writer, " ");
                    return;
                }
                throw new Exception("Cannot marshal type BasedUpon");
            }

            public static readonly BasedUponConverter Singleton = new BasedUponConverter();
        }

        internal class IsForcedConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(IsForced) || t == typeof(IsForced?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == " False")
                {
                    return IsForced.False;
                }
                throw new Exception("Cannot unmarshal type IsForced");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (IsForced)untypedValue;
                if (value == IsForced.False)
                {
                    serializer.Serialize(writer, " False");
                    return;
                }
                throw new Exception("Cannot marshal type IsForced");
            }

            public static readonly IsForcedConverter Singleton = new IsForcedConverter();
        }

        internal class SystemEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(SystemEnum) || t == typeof(SystemEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case " Admin Client":
                        return SystemEnum.AdminClient;
                    case " HDD Update":
                        return SystemEnum.HddUpdate;
                    case " ISPA Server":
                        return SystemEnum.IspaServer;
                    case " ISTA Launcher":
                        return SystemEnum.IstaLauncher;
                    case " ISTA NF":
                        return SystemEnum.IstaNf;
                    case " ISTA P":
                        return SystemEnum.IstaP;
                    case " ISTA SDP":
                        return SystemEnum.IstaSdp;
                    case " KeyReader":
                        return SystemEnum.KeyReader;
                }
                throw new Exception("Cannot unmarshal type SystemEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (SystemEnum)untypedValue;
                switch (value)
                {
                    case SystemEnum.AdminClient:
                        serializer.Serialize(writer, " Admin Client");
                        return;
                    case SystemEnum.HddUpdate:
                        serializer.Serialize(writer, " HDD Update");
                        return;
                    case SystemEnum.IspaServer:
                        serializer.Serialize(writer, " ISPA Server");
                        return;
                    case SystemEnum.IstaLauncher:
                        serializer.Serialize(writer, " ISTA Launcher");
                        return;
                    case SystemEnum.IstaNf:
                        serializer.Serialize(writer, " ISTA NF");
                        return;
                    case SystemEnum.IstaP:
                        serializer.Serialize(writer, " ISTA P");
                        return;
                    case SystemEnum.IstaSdp:
                        serializer.Serialize(writer, " ISTA SDP");
                        return;
                    case SystemEnum.KeyReader:
                        serializer.Serialize(writer, " KeyReader");
                        return;
                }
                throw new Exception("Cannot marshal type SystemEnum");
            }

            public static readonly SystemEnumConverter Singleton = new SystemEnumConverter();
        }

        internal class TypeEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case " 1":
                        return TypeEnum.The1;
                    case " 2":
                        return TypeEnum.The2;
                }
                throw new Exception("Cannot unmarshal type TypeEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (TypeEnum)untypedValue;
                switch (value)
                {
                    case TypeEnum.The1:
                        serializer.Serialize(writer, " 1");
                        return;
                    case TypeEnum.The2:
                        serializer.Serialize(writer, " 2");
                        return;
                }
                throw new Exception("Cannot marshal type TypeEnum");
            }

            public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
        }

        internal class UrlConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Url) || t == typeof(Url?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == " http://127.0.0.1")
                {
                    return Url.Http127001;
                }
                throw new Exception("Cannot unmarshal type Url");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Url)untypedValue;
                if (value == Url.Http127001)
                {
                    serializer.Serialize(writer, " http://127.0.0.1");
                    return;
                }
                throw new Exception("Cannot marshal type Url");
            }

            public static readonly UrlConverter Singleton = new UrlConverter();
        }

        internal class AvailabilityConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Availability) || t == typeof(Availability?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "forDeliveringThroughApi")
                {
                    return Availability.ForDeliveringThroughApi;
                }
                throw new Exception("Cannot unmarshal type Availability");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Availability)untypedValue;
                if (value == Availability.ForDeliveringThroughApi)
                {
                    serializer.Serialize(writer, "forDeliveringThroughApi");
                    return;
                }
                throw new Exception("Cannot marshal type Availability");
            }

            public static readonly AvailabilityConverter Singleton = new AvailabilityConverter();
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
 
}

