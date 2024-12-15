﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Esse código foi gerado por uma ferramenta.
//
//     As alterações no arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Project", Namespace="http://schemas.datacontract.org/2004/07/WCFBD_GanttProjects")]
    public partial class Project : object
    {
        
        private string DescriptionField;
        
        private System.DateTime EndDateField;
        
        private int IdField;
        
        private string NameField;
        
        private System.DateTime StartDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndDate
        {
            get
            {
                return this.EndDateField;
            }
            set
            {
                this.EndDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDate
        {
            get
            {
                return this.StartDateField;
            }
            set
            {
                this.StartDateField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IProjectService")]
    public interface IProjectService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProjectService/GetAllProjects", ReplyAction="http://tempuri.org/IProjectService/GetAllProjectsResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Project[]> GetAllProjectsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProjectService/GetProjectById", ReplyAction="http://tempuri.org/IProjectService/GetProjectByIdResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Project> GetProjectByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProjectService/AddProject", ReplyAction="http://tempuri.org/IProjectService/AddProjectResponse")]
        System.Threading.Tasks.Task AddProjectAsync(ServiceReference1.Project project);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProjectService/UpdateProject", ReplyAction="http://tempuri.org/IProjectService/UpdateProjectResponse")]
        System.Threading.Tasks.Task UpdateProjectAsync(ServiceReference1.Project project);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProjectService/DeleteProject", ReplyAction="http://tempuri.org/IProjectService/DeleteProjectResponse")]
        System.Threading.Tasks.Task DeleteProjectAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IProjectServiceChannel : ServiceReference1.IProjectService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class ProjectServiceClient : System.ServiceModel.ClientBase<ServiceReference1.IProjectService>, ServiceReference1.IProjectService
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar o ponto de extremidade de serviço.
        /// </summary>
        /// <param name="serviceEndpoint">O ponto de extremidade a ser configurado</param>
        /// <param name="clientCredentials">As credenciais do cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ProjectServiceClient() : 
                base(ProjectServiceClient.GetDefaultBinding(), ProjectServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IProjectService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProjectServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ProjectServiceClient.GetBindingForEndpoint(endpointConfiguration), ProjectServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProjectServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ProjectServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProjectServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ProjectServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProjectServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Project[]> GetAllProjectsAsync()
        {
            return base.Channel.GetAllProjectsAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Project> GetProjectByIdAsync(int id)
        {
            return base.Channel.GetProjectByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task AddProjectAsync(ServiceReference1.Project project)
        {
            return base.Channel.AddProjectAsync(project);
        }
        
        public System.Threading.Tasks.Task UpdateProjectAsync(ServiceReference1.Project project)
        {
            return base.Channel.UpdateProjectAsync(project);
        }
        
        public System.Threading.Tasks.Task DeleteProjectAsync(int id)
        {
            return base.Channel.DeleteProjectAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IProjectService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Não foi possível encontrar o ponto de extremidade com o nome \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IProjectService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:61570/ProjectService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Não foi possível encontrar o ponto de extremidade com o nome \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ProjectServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IProjectService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ProjectServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IProjectService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IProjectService,
        }
    }
}
