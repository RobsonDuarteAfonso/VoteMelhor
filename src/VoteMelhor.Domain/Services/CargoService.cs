using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
{
    public class CargoService : Service<Cargo>, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository) : base(cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public Cargo VerifyExist(Cargo cargo)
        {
            return _cargoRepository.VerifyExist(cargo);
        }

        public void SetAtual(int politicoId, int valor)
        {
            _cargoRepository.SetAtual(politicoId, valor);
        }
    }
}
