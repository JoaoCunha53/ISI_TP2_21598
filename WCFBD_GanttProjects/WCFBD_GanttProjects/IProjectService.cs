using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFBD_GanttProjects
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IProjectService" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        List<Project> GetAllProjects();

        [OperationContract]
        Project GetProjectById(int id);

        [OperationContract]
        void AddProject(Project project);

        [OperationContract]
        void UpdateProject(Project project);

        [OperationContract]
        void DeleteProject(int id);
    }

    [DataContract]
    public class Project
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public DateTime startDate { get; set; }

        [DataMember]
        public DateTime endDate { get; set; }
    }
}
