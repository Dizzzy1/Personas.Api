using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using Personas.Api.Models;

namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PersonasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPersona(Persona persona)
        {
            string connectionString = "Server=tcp:personas-api-ronald-2026.database.windows.net,1433;Initial Catalog=PersonasDB;Persist Security Info=False;User ID=Ronald;Password=RonHac@1232025;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using var connection = new SqlConnection(connectionString);

            string sql = @"
                INSERT INTO Personas (Nombre, Apellido, Edad)
                VALUES (@Nombre, @Apellido, @Edad)";

            await connection.ExecuteAsync(sql, persona);

            return Ok("Persona guardada correctamente");
        }
    }
}