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

        public Team(long teamId, string name, string flag)
        {
            TeamId = teamId;
            Name = name;
            Flag = flag;
        }

        public override string ToString()
        {
            return $"{TeamId.ToString()} {Name} {Flag}";
        }
    }
}
