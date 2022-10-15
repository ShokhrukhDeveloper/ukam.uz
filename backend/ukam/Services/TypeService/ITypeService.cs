using ukam.Dtos.TypeDTO;
using Type = ukam.Models.Type;

namespace ukam.Services.TypeService
{
    public interface ITypeService
    {
        public Task<List<Type>> GetAllAsync();
        public Task<TypeResponseDTO> GetByIdAsync(int id);
        public Task<TypeResponseDTO> AddAsync(TypeDTO dto);
        public Task<TypeResponseDTO> UpdateAsync(int id, TypeDTO dto);
        public Task<TypeResponseDTO> DeleteAsync(int id);
    }
}
