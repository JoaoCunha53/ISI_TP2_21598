using System.Collections.Generic;
using System.Data.SqlClient;

namespace WCFBD_GanttProjects
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "ProjectService" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione ProjectService.svc ou ProjectService.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class ProjectService : IProjectService
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

        #region GetAllProjects
        /// <summary>
        /// Devolve todos os projetos já criados.
        /// </summary>
        /// <returns>Devolve todos os projetos</returns>
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Projects";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Project project = new Project
                            {
                                id = reader.GetInt32(reader.GetOrdinal("Id")),
                                name = reader.GetString(reader.GetOrdinal("Name")),
                                description = reader.GetString(reader.GetOrdinal("Description")),
                                startDate = reader.GetDateTime(reader.GetOrdinal("StartData")),
                                endDate = reader.GetDateTime(reader.GetOrdinal("EndData"))
                            };

                            projects.Add(project);
                        }
                    }
                }
                connection.Close();
            }
            return projects;
        }
        #endregion

        #region GetProjectById
        /// <summary>
        /// Devolve um projeto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns name="Project">Devolve um projeto</returns>
        public Project GetProjectById(int id)
        {
            Project project = new Project();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Projects WHERE Id = @ProjectId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", project.id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            project = new Project
                            {
                                id = reader.GetInt32(reader.GetOrdinal("Id")),
                                name = reader.GetString(reader.GetOrdinal("Name")),
                                description = reader.GetString(reader.GetOrdinal("Description")),
                                startDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                endDate = reader.GetDateTime(reader.GetOrdinal("EndDate"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return project;
        }
        #endregion

        #region AddProject
        /// <summary>
        /// Insere um projeto.
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        public void AddProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Projects (Name, Description, StartDate, EndDate) VALUES (@Name, @Description, @StartDate, @EndDate)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Adiciona os parâmetros com os valores fornecidos
                    command.Parameters.AddWithValue("@Name", project.name);
                    command.Parameters.AddWithValue("@Description", project.description);
                    command.Parameters.AddWithValue("@StartDate", project.startDate);
                    command.Parameters.AddWithValue("@EndDate", project.endDate);

                    // Executa a query para inserir o novo projeto
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region UpdateProject
        /// <summary>
        /// Atualiza um projeto.
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        public void UpdateProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Projects SET Name = @Name, Description = @Description, StartDate = @StartDate, EndDate = @EndDate WHERE Id = @ProjectId";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", project.name);
                    command.Parameters.AddWithValue("@Description", project.description);
                    command.Parameters.AddWithValue("@StartDate", project.startDate);
                    command.Parameters.AddWithValue("@EndDate", project.endDate);
                    command.Parameters.AddWithValue("@ProjectId", project.id);

                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region DeleteProject
        /// <summary>
        /// Elimina um projeto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteProject(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Projects WHERE Id = @ProjectId";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        #endregion
    }
}
