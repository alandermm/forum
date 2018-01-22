using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("postagem/[controller")]
    public class PostagemController:Controller
    {
        Postagem postagem = new Postagem();
        DAOPostagem dao = new DAOPostagem();
        
        [HttpGet(Name = "Postagens")]
        public IEnumerable<Postagem> Get(){
            return dao.Listar();
        }

        [HttpGet("{id}", Name="PostagemAtual")]
        public Postagem GetPostagem(int id){
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post(Postagem postagem){
            dao.Cadastrar(postagem);
            return CreatedAtRoute("PostagemAtual", new{id = postagem.Id}, postagem);
        }

        [HttpPut]
        public IActionResult Put(Postagem postagem){
            dao.Editar(postagem);
            return CreatedAtRoute("PostagemAtual", new{id = postagem.Id}, postagem);
        }

        [HttpDelete]
        public IActionResult Delete(int id){
            dao.Apagar(id);
            return CreatedAtRoute("Postagens", null, null);
        }
        
    }
}