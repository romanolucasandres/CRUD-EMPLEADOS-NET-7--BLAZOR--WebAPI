using EmpleadoCrud.Shared;

namespace EmpleadoCrud.Client.Service
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> ListE();
        Task<EmpleadoDTO> GetEmpleado(int id);
        Task<int> Insert(EmpleadoDTO empleadoDTO);
        Task<int> Update(EmpleadoDTO empleadoDTO);
        Task<bool> Delete(int id);

    }
}
