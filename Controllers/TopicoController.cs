using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("topico/[controller]")]
    public class TopicoController:Controller
    {
        Topico topico = new Topico();
        DAOTopico dao = new DAOTopico();
        [HttpGet(Name = "Topicos")]
        public IEnumerable<Topico> Get(){
            return dao.Listar(); 
        }

        [HttpGet("{id}",Name="TopicoAtual")]
        public Topico GetTopico(int id){
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Topico topico){
            dao.Cadastro(topico);
            return CreatedAtRoute("TopicoAtual", new {id = topico.Id}, topico);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Topico topico){
            dao.Editar(topico);
            return CreatedAtRoute("TopicoAtual", new {id = topico.Id}, topico);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            dao.Apagar(id);
            return CreatedAtRoute("Topicos", null, null);
        }


    }
}