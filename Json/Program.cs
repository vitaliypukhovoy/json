using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Json
{
    class Program
    {

        static void Main(string[] args)
        {

            var _json = new JObject(
                                       new JProperty("error", new JObject(
                                              new JProperty("bool", new JObject(
                                                   new JProperty("prop", new JObject(
                                                   new JProperty("match", new JObject(new JProperty("prop", "data1"))),
                                                   new JProperty("match2", new JObject(new JProperty("prop", "data")))
              )))))));

            Console.WriteLine(_json.ToString());

            var d = new Director(new JsonBuilder());
            Console.WriteLine(d.Json.ToString());
            Console.ReadKey();
        }

    }


    public class Director
    {
        //private IJsonBuilder _jsonBuilder;
        public JObject Json { get { return json; } }
        private JObject json;
        public Director(IJsonBuilder jsonBuilder)
        {
             jsonBuilder.CreateJObject(jsonBuilder.CreateObjectProperty("error",
                                                              jsonBuilder.CreateObjectProperty("bool",
                                                                    jsonBuilder.CreateObjectProperty("prop",
                                                                        //jsonBuilder.CreateObjectProperty("would", 
                                                                            //  jsonBuilder.CreateObjectObject("prop1", "data1")
                                                                            jsonBuilder.CreatePropertyArray("would",

                                                                            jsonBuilder.CreateJArray(jsonBuilder.CreateObjectProperty("prop1", "data1"))
                                                                            
                                                                                   
                                                                                // jsonBuilder.CreateJArray(null
                                                                                // jsonBuilder.CreateProperty("prop1", "data1")
                                                                                //  jsonBuilder.CreateProperty("prop2", "data2")

                                                                                )))));
            json = jsonBuilder.GetJson();
        }
    }

    public abstract class IJsonBuilder
    {
        public abstract JArray CreateJArray(JObject jObject);
       // public abstract string CreateProperty1(string prop, string data);
        public abstract void CreateJObject(JProperty jProperty);
        public abstract JProperty CreateObjectObject(string prop, string data);
        public abstract JProperty CreateObjectProperty(string prop, JProperty jProperty);
        public abstract JObject CreateObjectProperty(string prop, string data);
        public abstract JProperty CreatePropertyArray(string prop, JArray jArray);
        public abstract JProperty CreateProperty( string prop, string data);
        public abstract void CreateSelectJObjectJProperty();
        public abstract JObject GetJson();

    }

    public class JsonBuilder : IJsonBuilder
    {
        private JsonObject _jsonObject;
        private JObject _json;
        public JsonBuilder()
        {          
        }
        public override JArray CreateJArray(JObject jObject)
        {
            return  new JArray(jObject);
        }

        public override JProperty CreatePropertyArray(string prop, JArray jArray)
        {
            return  new JProperty(prop, jArray);
        }

        public override JProperty CreateObjectObject(string prop,string data)
        {
            return new JProperty(prop, data);
        }

        public override void CreateJObject(JProperty jProperty)
        {
            _json = new JObject(jProperty);
        }

        public override JProperty CreateObjectProperty(string prop, JProperty jProperty)
        {
            return new JProperty(prop, new JObject(jProperty));
        }

        public override JObject CreateObjectProperty(string prop, string data)
        {

            return new JObject(new JProperty(prop, data));
        }

        public override JProperty CreateProperty(string prop, string data)
        {
            return new JProperty(prop, data);
        }

        public override void CreateSelectJObjectJProperty()
        {
            throw new NotImplementedException();
        }

        public override JObject GetJson()
        {
            //_jsonObject = new JsonObject(_json);
            return _json;
        }
    }

    public class JsonObject
    {
        private JObject json;
        public JsonObject(JObject _json)
        {
            json = _json;
        }
        public JObject Json { get; set; }
    }

}
