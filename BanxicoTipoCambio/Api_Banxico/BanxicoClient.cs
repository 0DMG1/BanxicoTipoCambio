using System;
using System.Net;
using System.Runtime.Serialization.Json;

namespace BanxicoTipoCambio.Api_Banxico
{
    public class BanxicoClient
    {
        public string bmxToken { get; set; }
        public HttpWebRequest request { get; set; }
        public HttpWebResponse response { get; set; }
        public Response Respuesta { get; set; }
        public BanxicoClient(string token)
        {
            bmxToken = token;
            
            string serie = "SP74665,SF61745,SF60634,SF43718,SF43773";
            string url = $"https://www.banxico.org.mx/SieAPIRest/service/v1/series/{serie}/datos/{DateTime.Now.ToString("yyyy-MM-dd")}/{DateTime.Now.ToString("yyyy-MM-dd")}";
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Accept = "application/json";
            request.Headers["Bmx-Token"] = bmxToken;
            response = request.GetResponse() as HttpWebResponse;
            Respuesta = serializeResponseSeries();

        }

        public Response serializeResponseSeries()
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
            object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
            return objResponse as Response;
        }
       
    }
}
