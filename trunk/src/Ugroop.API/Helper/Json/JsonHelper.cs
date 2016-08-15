using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ugroop.API.Helper.Json {

    public class JsonData {
        //dynamic jData;
        private static JObject dataX;

        private static readonly JsonData instance = new JsonData();

        public static JsonData Instance(JObject data) {
            dataX = data;
            return instance;
        }

        //public JsonData(JObject data) {
        //    jData = data;
        //    dataX = data;
        //}

        public JToken Get_JsonObject(string objectName) {
            return dataX.GetValue(objectName);
        }

        //public dynamic Dynamic {
        //    get { return jData; }
        //}

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