using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Layer
{
    public class ObjectConvertFormatManager<T>
    {
        public T JsonToObject(string jsonString)
        {
            var ObjectData = JsonConvert.DeserializeObject<T>(jsonString);
            return ObjectData;
        }
        public string ObjectToJson(T t)
        {
            var json = JsonConvert.SerializeObject(t);
            return json;
        }
    }
}
