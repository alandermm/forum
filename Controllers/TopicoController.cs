using System.Collections.Generic;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("topico/[controller]")]
    public class TopicoController:Controller
    {
        Topico topico = new Topico();
        DAOTopico dao = new DAOTopico();
        [HttpGet]
        public IEnumerable<Topico> Get(){
            return dao.Listar(); 
        }
        
    }
}