using EmpleadoCrud.Shared;
using System.Net.Http.Json;

namespace EmpleadoCrud.Client.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _http;

        public EmpleadoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EmpleadoDTO>> ListE()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<EmpleadoDTO>>>("api/empleado/List");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<EmpleadoDTO> GetEmpleado(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<EmpleadoDTO>>($"api/Empleado/GetEmpleado/{id}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Insert(EmpleadoDTO empleadoDTO)
        {
            var result = await _http.PostAsJsonAsync("api/Empleado/Insert", empleadoDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }


        public async Task<int> Update(EmpleadoDTO empleadoDTO)
        {
            var result = await _http.PutAsJsonAsync($"api/Empleado/Update/{empleadoDTO.IdEmpleado}", empleadoDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/Empleado/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }
    }
}
