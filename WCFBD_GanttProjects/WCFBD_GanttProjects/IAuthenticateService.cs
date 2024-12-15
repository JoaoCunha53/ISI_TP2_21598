using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFBD_GanttProjects
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IServicoAutenticacao" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IAuthenticateService
    {
        [OperationContract]
        User Login(string username, string password);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string role { get; set; }
    }
}
