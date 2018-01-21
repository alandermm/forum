using System.Collections.Generic;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("usuario/[controller]")]
    public class UsuarioController:Controller
    {
        Usuario usuario = new Usuario();
        DAOUsuario dao = new DAOUsuario();
        
        [HttpGet]
        public IEnumerable<Usuario> Get(){
            return dao.Listar();
        }

    }
}