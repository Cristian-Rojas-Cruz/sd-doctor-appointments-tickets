using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "BlogService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione BlogService.svc o BlogService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class BlogService : IBlogService
    {
        public async Task<SuperPost> GetPost(int PostId)
        {
            try
            {
                HttpClient client = new HttpClient();
                var PostResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/" + PostId);
                var CommentsResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/" + PostId + "/comments");
                var PostContent = PostResponse.Content.ReadAsStringAsync().Result;
                var CommentsContent = CommentsResponse.Content.ReadAsStringAsync().Result;
                var post = JsonConvert.DeserializeObject<SuperPost>(PostContent);
                var comments = JsonConvert.DeserializeObject<List<Comment>>(CommentsContent);
                post.comments = comments;

                return post;
            }
            catch (Exception e)
            {
                var data = new SuperPost();
                data.title = "Not found";
                return data;
            }
        }
    }
}
