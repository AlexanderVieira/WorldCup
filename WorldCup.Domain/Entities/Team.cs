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
        public int Scoreboard { get; set; }

        public Team()
        {
        }

        public Team(string name, string flag)
        {
            Name = name;
            Flag = flag;
        }

        public Team(long teamId, string name, string flag) : this(name, flag)
        {
            TeamId = teamId;
        }

        public Team(long teamId, string name, string flag, int scoreboard) : this(teamId, name, flag)
        {                       
            Scoreboard = scoreboard;
        }

        public override string ToString()
        {
            return $"{Name} {Flag}";
        }
    }
}
