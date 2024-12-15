using System;
using System.Data.SqlClient;

namespace WCFBD_GanttProjects
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "ServicoAutenticacao" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione ServicoAutenticacao.svc ou ServicoAutenticacao.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class AuthenticateService : IAuthenticateService
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

        #region Login
        /// <summary>
        /// Realiza o login.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string username, string password)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Name, Username, Email, Password, Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                name = reader["Name"].ToString(),
                                username = reader["Username"].ToString(),
                                email = reader["Email"].ToString(),
                                password = reader["Password"].ToString(),
                                role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }
        #endregion
    }
}
