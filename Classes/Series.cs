using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series
{
    public class Series : BaseEntity
    {

        public Series(int id, Genero genero, string descricao, string titulo, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Descricao = descricao;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Excluido = false;
        }
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set;}


        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano do Título: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            
             return retorno;
        }

        public string retornaTitulo(){
            return Titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public bool retornaExcluido(){
            return this.Excluido;
        }

        public void Excluir(){
            this.Excluido = true;
        }
    }
}