using AWSApiSegundoExamenAgus.Models;
using AWSApiSegundoExamenAgus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSApiSegundoExamenAgus.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ConciertosController : ControllerBase
    {
        private RepositoryConcierto repo;

        public ConciertosController(RepositoryConcierto repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Evento>> GetEventos()
        {
            return this.repo.GetEventos();
        }

        [HttpGet]
        [Route("[action]/{idcategoria}")]
        public ActionResult<string> GetNombreCategoria(int idcategoria)
        {
            return this.repo.GetNombreCategoria(idcategoria);
        }


        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<CategoriaEvento>> GetCategoriaEvento()
        {
            return this.repo.GetCategoriaEventos();
        }

        [HttpGet]
        [Route("[action]/{idevento}")]
        public ActionResult<Evento> FindEvento(int idevento)
        {
            return this.repo.FindEvento(idevento);
        }

        [HttpGet]
        [Route("[action]/{idcategoria}")]
        public ActionResult<List<Evento>> GetEventosPorCategoria(int idcategoria)
        {
            return this.repo.GetEventosPorCategoria(idcategoria);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult InsertarEvento(Evento evento)
        {
            this.repo.NuevoEvento(evento);
            return Ok();
        }
        [HttpPut]
        [Route("[action]/{idevento}/{idcategoria}")]
        public ActionResult CambiarEventoCategoria(int idevento, int idcategoria)
        {
            this.repo.CambiarEventoCategoria(idevento, idcategoria);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{idevento}")]
        public ActionResult DeleteEvento(int idevento)
        {
            this.repo.EliminarEvento(idevento);
            return Ok();
        }
    }
}
