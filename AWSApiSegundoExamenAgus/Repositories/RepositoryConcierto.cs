using AWSApiSegundoExamenAgus.Data;
using AWSApiSegundoExamenAgus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSApiSegundoExamenAgus.Repositories
{
    public class RepositoryConcierto
    {
        private ConciertoContext context;

        public RepositoryConcierto(ConciertoContext context)
        {
            this.context = context;
        }

        public List<Evento> GetEventos()
        {
            return this.context.Eventos.ToList();
        }

        public Evento FindEvento(int idevento)
        {
            return this.context.Eventos.FirstOrDefault(x => x.IdEvento == idevento);
        }

        public List<CategoriaEvento> GetCategoriaEventos()
        {
            return this.context.CategoriaEventos.ToList();
        }

        public List<Evento> GetEventosPorCategoria(int idcategoria)
        {
            var consulta = from datos in this.context.Eventos where datos.IdCategoria == idcategoria select datos;
            return consulta.ToList();
        }

        public void NuevoEvento(Evento evento)
        {
            this.context.Eventos.Add(evento);
            this.context.SaveChanges();
        }

        public void EliminarEvento(int idevento)
        {
            Evento ev = this.FindEvento(idevento);
            this.context.Remove(ev);
            this.context.SaveChanges();
        }

        public void CambiarEventoCategoria(int idevento, int idcategoria)
        {
            Evento evento = this.FindEvento(idevento);
            evento.IdCategoria = idcategoria;
            this.context.SaveChanges();
        }

        public string GetNombreCategoria(int idcategoria)
        {
            var consulta = from datos in this.context.CategoriaEventos where datos.IdCategoria == idcategoria select datos.Nombre;
            return consulta.FirstOrDefault();
        }

    }
}
