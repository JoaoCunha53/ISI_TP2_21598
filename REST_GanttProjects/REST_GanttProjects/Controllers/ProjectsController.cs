using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectService;
using Swashbuckle.AspNetCore.Annotations;

namespace REST_GanttProjects.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectServiceClient _soapClient;

        public ProjectsController(ProjectServiceClient soapClient)
        {
            _soapClient = soapClient;
        }

        #region GetAllProjects
        /// <summary>
        /// Devolve todos os projetos já criados.
        /// </summary>
        /// <returns>Devolve todos os projetos</returns>
        [Authorize(Policy = "Administrador")]
        [HttpGet("ObterProjetos")]
        [SwaggerResponse(200, Type = typeof(Project))]
        [SwaggerResponse(401, "Não tem premissões suficientes.")]
        [SwaggerResponse(404, "Nenhum registo encontrado.")]

        public async Task<IActionResult> GetAllProjects()
        {
            var projects = _soapClient.GetAllProjectsAsync();
            return Ok(projects);
        }
        #endregion

        #region GetProjectById
        /// <summary>
        /// Devolve um projeto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns name="Project">Devolve um projeto</returns>
        [Authorize(Policy = "Administrador")]
        [HttpGet("ObterProjeto/{id}")]
        [Consumes("application/xml")]
        [SwaggerResponse(200, Type = typeof(Project))]
        [SwaggerResponse(401, "Não tem premissões suficientes.")]
        [SwaggerResponse(404, "Nenhum registo encontrado.")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _soapClient.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }
        #endregion

        #region CreateProject
        /// <summary>
        /// Insere um projeto.
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        [Authorize(Policy = "Administrador")]
        [HttpPost("CriarNovoProjeto")]
        [SwaggerResponse(200, Type = typeof(Project))]
        [SwaggerResponse(401, "Não tem premissões suficientes.")]
        [SwaggerResponse(404, "Nenhum registo encontrado.")]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            await _soapClient.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.id }, project);
        }
        #endregion 

        #region UpdateProject
        /// <summary>
        /// Atualiza um projeto.
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        [Authorize(Policy = "Administrador")]
        [HttpPut("AtualizarProjeto/{id}")]
        [SwaggerResponse(200, Type = typeof(Project))]
        [SwaggerResponse(401, "Não tem premissões suficientes.")]
        [SwaggerResponse(404, "Nenhum registo encontrado.")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            var existingProject = await _soapClient.GetProjectByIdAsync(id);
            if (existingProject == null)
                return NotFound();

            await _soapClient.UpdateProjectAsync(project);
            return NoContent();
        }
        #endregion 

        #region DeleteProject
        /// <summary>
        /// Elimina um projeto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Policy = "Administrador")]
        [HttpDelete("EliminarProjeto/{id}")]
        [SwaggerResponse(200, Type = typeof(Project))]
        [SwaggerResponse(401, "Não tem premissões suficientes.")]
        [SwaggerResponse(404, "Nenhum registo encontrado.")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var existingProject = await _soapClient.GetProjectByIdAsync(id);
            if (existingProject == null)
                return NotFound();

            await _soapClient.DeleteProjectAsync(id);
            return NoContent();
        }
        #endregion 
    }
}
