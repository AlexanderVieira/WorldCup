using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCup.Domain.Entities
{
    /// <summary>
    /// Entidade que representa um objeto time
    /// no contexto do dominio do projeto
    /// @Autor: Alexander Silva
    /// </summary>
    public class Team
    {
        public long TeamId { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }

        public Team()
        {

        }

        public Team(string name, string flag)
        {
            Name = name;
            Flag = flag;
        }

        public override string ToString()
        {
            return $"{Name} {Flag}";
        }
    }
}
