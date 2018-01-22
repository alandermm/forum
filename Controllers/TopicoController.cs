using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    public class TopicoController:Controller
    {
        Topico topico = new Topico();
        DAOTopico dao = new DAOTopico();

        [HttpGet]
        public IEnumerable<Topico> Get(){
            return dao.Listar();
        }

        [HttpGet("{id}",Name="TopicoAtual")]
        public Topico GetTopico(int id){
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Topico topico){
            dao.Cadastrar(topico);
            return CreatedAtRoute("TopicoAtual", new {id = topico.Id}, topico);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Topico topico){
            dao.Editar(topico);
            return CreatedAtRoute("TopicoAtual", new {id = topico.Id}, topico);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id){
            return dao.Apagar(id);
            //return CreatedAtRoute("Topicos", null, null);
        }


    }
}