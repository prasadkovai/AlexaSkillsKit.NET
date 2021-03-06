﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace AlexaSkillsKit.Speechlet
{
    public class Deserializer<T>
    {
        private static IDictionary<string, Func<JObject, T>> deserializers = new Dictionary<string, Func<JObject, T>>();

        public static void RegisterDeserializer(string name, Func<JObject, T> fromJson) {
            deserializers.Add(name, fromJson);
        }

        public static T FromJson(JProperty json) {
            if (json == null || !deserializers.ContainsKey(json.Name)) return default(T);

            return deserializers[json.Name](json.Value as JObject);
        }
    }
}
