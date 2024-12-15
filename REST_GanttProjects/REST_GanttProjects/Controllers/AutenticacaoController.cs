using AuthCore.Services;
using Microsoft.AspNetCore.Mvc;
using AuthenticateService;
using Swashbuckle.AspNetCore.Annotations;

namespace REST_GanttProjects.Controllers
{
    [ApiController]
    [Route("api")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AuthenticateServiceClient _soapClient;

        public AutenticacaoController(AuthenticateServiceClient soapClient)
        {
            _soapClient = soapClient;
        }

        #region GetUserFromDatabase
        /// <summary>
        /// Realizar um login.
        /// </summary>
        /// <returns>Devolve um token de acesso</returns>
         
        [HttpGet("SingIn")]
        [Consumes("application/xml")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(User))]
        [SwaggerResponse(401, "Não tem premissões suficientes.")]
        [SwaggerResponse(404, "Nenhum registo encontrado.")]
        public async Task<IActionResult> GetUserFromDatabase(string username, string password)
        {
            var aux = await _soapClient.LoginAsync(username, password);
            if (aux == null)
                return NotFound();
            User user = aux as User;

            string token = AuthService.GenerateToken(user);

            return Ok(token);
        }
        #endregion

    }
}
