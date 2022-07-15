using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Series.interfaces;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Series>
    {
        // public SerieRepository()
        // {
        // }

        private List<Series> ListaSerie = new List<Series>();
        public List<Series> Lista(){
            
            return ListaSerie;
        }

        public void Atualiza(int id, Series entidade)
        {
            ListaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            ListaSerie.Add(entidade);
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}