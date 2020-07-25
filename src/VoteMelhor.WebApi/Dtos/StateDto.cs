namespace VoteMelhor.WebApi.Dtos
{
    public class StateDto
    {
        public int Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }

        public StateDto(int id, string initials, string name)
        {
            Id = id;
            Initials = initials;
            Name = name;
        }
    }
}