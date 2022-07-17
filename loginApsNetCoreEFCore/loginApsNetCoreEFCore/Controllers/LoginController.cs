using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Claims;

namespace loginApsNetCoreEFCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
            if (User.Identity.IsAuthenticated)
            {
                return Json(new { Msg = "Usuario já logado!" });
            }
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string username, string senha)
        {
            MySqlConnection mySqlconnection = new MySqlConnection("server=localhost;port= 7224;database=usuariosdb;uid=root;password=admin");

            await mySqlconnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlconnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM usuarios WHERE username = '{username}' AND senha = '{senha}' ";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {
                int usuarioId = reader.GetInt32(0);
                string nome = reader.GetString(1);

                List<Claim> direitosAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,usuarioId.ToString()),
                    new Claim(ClaimTypes.Name,nome)
                };

                var identity = new ClaimsIdentity(direitosAcesso, "Identity.login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTimeOffset.Now.AddHours(1),
                    });

                return Json(new { Msg = "Usuário Logado com sucesso!" });
            }

            return Json(new { Msg = "Usuário não encontrado! Verifique suas credencias!" });
        }

        public async Task<IActionResult> Logout()
        {
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
            return RedirectToAction("Index","");
        }
    }
}
