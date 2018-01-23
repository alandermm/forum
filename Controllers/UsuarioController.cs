using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController:Controller
    {
        Usuario usuario = new Usuario();
        DAOUsuario dao = new DAOUsuario();
        
        [HttpGet]
        public IEnumerable<Usuario> Get(){
            return dao.Listar();
        }

        /*[HttpGet("{id}",Name="UsuarioAtual")]
        public Usuario GetUsuario(int id){
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }*/

        [HttpGet("{id}",Name="UsuarioAtual")]
        public IActionResult Listar(int id){
            var rs = new JsonResult(dao.Listar().Where(x => x.Id == id).FirstOrDefault());
            rs.ContentType = "application/json";
            if(rs.Value == null){
                rs.StatusCode = 204;
                rs.Value = $"Resultado para id: {id} não retornou dados";
            } else {
                rs.StatusCode = 200;
            }
            return Json(rs);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario){
            dao.Cadastrar(usuario);
            return CreatedAtRoute("UsuarioAtual", new{id = usuario.Id}, usuario);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario){
            dao.Editar(usuario);
            return CreatedAtRoute("UsuarioAtual", new{id = usuario.Id}, usuario);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id){
            return dao.Apagar(id);
        }
    }
}