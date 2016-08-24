using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ugroop.API.SQL.Helper.Json {

    public static class JSON {

        public static string JsonSerialize(this object obj) {
            return JsonConvert.SerializeObject(obj);
        }

        public static object JsonDeserialize(this string jsonStr) {
            return JsonConvert.DeserializeObject(jsonStr);
        }

    }

    public class JsonData {
        private static JObject dataX;

        private static readonly JsonData instance = new JsonData();

        public static JsonData Instance(JObject data) {
            dataX = data;
            return instance;
        }

        public JToken Get_JsonObject(string objectName) {
            return dataX.GetValue(objectName);
        }

        public JObject JsonObject {
            get { return dataX; }
        }
    }

    public class JEntity<T> {

        private static readonly JEntity<T> instance = new JEntity<T>();

        public static JEntity<T> Instance() {
            return instance;
        }

        public T Get_Entity(JObject data) {
            var tName = typeof(T).Name;
            var model = data.GetValue(tName);
            return model.ToObject<T>();
        }

        public T Get_Entity(JsonData data) {
            var tName = typeof(T).Name;
            var model = data.JsonObject.GetValue(tName);
            return model.ToObject<T>();
        }

        public void Add_DataService(JsonData data) {
            //var tName = typeof(T).Name;
            //var token = typeof(T) as JToken;

            //var model = data.JsonObject.ad(tName);

            //data.JsonObject.Add("AccountService", token);
        }
    }

}