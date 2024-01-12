using EmpleadoCrud.Shared;

namespace EmpleadoCrud.Client.Service
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoDTO>> ListD();
    }
}
