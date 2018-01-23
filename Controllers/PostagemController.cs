using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    public class PostagemController:Controller
    {
        Postagem postagem = new Postagem();
        DAOPostagem dao = new DAOPostagem();
        
        [HttpGet]
        public IEnumerable<Postagem> Get(){
            return dao.Listar();
        }

        [HttpGet("{id}", Name="PostagemAtual")]
        public Postagem GetPostagem(int id){
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Postagem postagem){
            dao.Cadastrar(postagem);
            return CreatedAtRoute("PostagemAtual", new{id = postagem.Id}, postagem);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Postagem postagem){
            dao.Editar(postagem);
            return CreatedAtRoute("PostagemAtual", new{id = postagem.Id}, postagem);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id){
            return dao.Apagar(id);
            //return CreatedAtRoute("Postagens", null, null);
        }
    }
}