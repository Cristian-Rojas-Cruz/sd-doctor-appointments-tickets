using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IBlogService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        Task<SuperPost> GetPost(int PostId);
    }

    [DataContract]
    public class SuperPost
    {
        int UserId = 0;
        int Id = 0;
        string Title = "";
        string Body = "";
        List<Comment> Comments = new List<Comment>();

        [DataMember]
        public string title
        {
            get { return Title; }
            set { Title = value; }
        }

        [DataMember]
        public string body
        {
            get { return Body; }
            set { Body = value; }
        }

        [DataMember]
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        [DataMember]
        public int userId
        {
            get { return UserId; }
            set { UserId = value; }
        }

        [DataMember]
        public List<Comment> comments
        {
            get { return Comments; }
            set { Comments = value; }
        }
    }
    public class Comment 
    {
        int PostId = 0;
        int Id = 0;
        string Name = "";
        string Body = "";
        string Email = "";

        [DataMember]
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        [DataMember]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        [DataMember]
        public string body
        {
            get { return Body; }
            set { Body = value; }
        }

        [DataMember]
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        [DataMember]
        public int postId
        {
            get { return PostId; }
            set { PostId = value; }
        }
    }
}
