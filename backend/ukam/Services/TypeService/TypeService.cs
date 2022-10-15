using Backend.Uckam.data;
using Microsoft.EntityFrameworkCore;
using ukam.Dtos.TypeDTO;
using Type = ukam.Models.Type;

namespace ukam.Services.TypeService
{
    public class TypeService : ITypeService
    {
        private readonly AppDbContext context;

        public TypeService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Type>> GetAllAsync()
        {
            List<Type> types = await context.Types.ToListAsync();
            return types;
        }

        public async Task<TypeResponseDTO> AddAsync(TypeDTO dto)
        {
            Type type = new Type()
            {
                Name = dto.Name,
                CreatorId = dto.CreatorId,
                CreatedAt = DateTime.Now
            };

            context.Types.Add(type);
            await context.SaveChangesAsync();

            return new TypeResponseDTO { Success = true, Message = "New type created successfully!", Type = type };
        }

        public async Task<TypeResponseDTO> GetByIdAsync(int id)
        {
            int a = Convert.ToInt32(id);
            var type = await context.Types.FindAsync(a);
            if (type is null)
                return new TypeResponseDTO { Message = "Type not found!" };

            return new TypeResponseDTO { Success = true, Message = "Type found!", Type = type };
        }

        public async Task<TypeResponseDTO> UpdateAsync(int id, TypeDTO dto)
        {
            var type = await context.Types.FindAsync(id);
            if (type is null)
                return new TypeResponseDTO { Message = "Type not found!" };

            type.Name = dto.Name;
            type.CreatorId = dto.CreatorId;
            type.UpdatedAt = DateTime.Now;

            await context.SaveChangesAsync();

            return new TypeResponseDTO { Success = true, Message = "Type updated successfully!", Type = type };
        }

        public async Task<TypeResponseDTO> DeleteAsync(int id)
        {
            var type = await context.Types.FindAsync(id);
            if (type is null)
                return new TypeResponseDTO { Message = "Type not found!" };

            context.Types.Remove(type);
            await context.SaveChangesAsync();

            return new TypeResponseDTO { Success = true, Message = "Type has been deleted!" };
        }
    }
}
