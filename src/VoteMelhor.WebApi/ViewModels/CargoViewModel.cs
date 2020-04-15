using System;

namespace VoteMelhor.WebApi.ViewModels
{
    public class CargoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Atual { get; set; }
        public PoliticoViewModel Politico { get; set; }
    }
}
