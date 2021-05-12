using apiPrueba.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace consolaApi
{

        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            [WebInvoke(Method = "GET",
                 ResponseFormat = WebMessageFormat.Json,
                 BodyStyle = WebMessageBodyStyle.Wrapped,
                 UriTemplate = "login/{username}/{password}")]
            [return: MessageParameter(Name = "Data")]
            USER DoLogin(string username, string password);
        }


        public class Artist
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public List<AlbumDTO> Albums { get; set; } = new List<AlbumDTO>();
    }
 
}
