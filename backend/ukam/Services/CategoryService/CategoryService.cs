using Backend.Uckam.Models;
using Backend.Uckam.Entities.Enums;
using Backend.Uckam.Repositories;
using ukam.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Uckam.Services;

namespace ukam.Services.CategoryService;

    public partial class CategoryService : ICategoryService
    {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoryService> _logger;

    public  CategoryService(IUnitOfWork unitOfWork,ILogger<CategoryService>logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;

    }
        public async ValueTask<Result<Category>> CreateCategory(Category category, IFormFile? formFile=null)
        {
        try
        {
            var filehelper = new FileHelper();
            if (category is null)
                return new("Null reference error");

            if (string.IsNullOrWhiteSpace(category.Name))
                return new("Category name invalid");

            var user =  _unitOfWork.Users.GetById(category.CreatorId);

            if (user is null) return new("User Not found");
            

            if (user.Role != Backend.Uckam.Entities.Enums.ERole.SuperAdmin) 
                return new("This user is not allowed to add a category");

            category.UpdatedAt = null;

            if (formFile is not null)
                if (filehelper.FileValidateImage(formFile))
                    category.Image = await filehelper.WriteFileAsync(formFile, FileFolders.CategoryImage);
                else return new("Given Image file extension invalid type");

            var result = await _unitOfWork.Categories.AddAsync(ToEntity(category));
            return new(true) 
                {
                    Data= ToModel(result)
                };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(CategoryService)}", e);

            throw new("Couldn't create category. Plaese contact support",e);
        }
        }

        public async ValueTask<Result<Category>> DeleteCategory(ulong categoryId,ulong userId)
        {
        try 
            { 

                var category= _unitOfWork.Categories.GetById(categoryId);
                if (category is null)
                    return new("Category with given Id Not Found");
                var user = _unitOfWork.Users.GetById(userId);

                if (user is null) 
                    return new("User Not found");

                if (user.Role != Backend.Uckam.Entities.Enums.ERole.SuperAdmin)
                    return new("This user is not allowed to add a category");

            var filehelper = new FileHelper();
            if (category.Image is not null)
              filehelper.DeleteFileByName(category.Image);

            var result = await _unitOfWork.Categories.Remove(category);
            return new(true) { Data=ToModel(result)};
            }
        catch(Exception e) 
        {
            _logger.LogError($"Error occured at {nameof(CategoryService)}", e);
            throw new("Couldn't delete category. Plaese contact support", e);
        
        }      
            

                
        
            
        }

        public async ValueTask<Result<List<Category>>> GetAllAsync()
        {
        try
        {
            var categories = await _unitOfWork.Categories.GetAll().ToListAsync();
            if (categories is null)
                return new(false) {ErrorMessage="Any category not found"};

            return new(true) {Data=categories.Select(ToModel).ToList()};
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(CategoryRepository)} .");
            throw new("Couldn't get Categories Please contact support");
        }
        }

        public async ValueTask<Result<Category>> GetByIdAsync(ulong categoryId)
        {
        try
        {
            if (categoryId == 0)
                return new("Given id invalid");
            var result=await _unitOfWork.Categories.GetAll().FirstOrDefaultAsync(c=>c.Id==categoryId);
            if (result is null)
                return new("Category given with id Not Found");
            
            return new(true) { Data = ToModel(result) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(CategoryRepository)} .");
            throw new("Couldn't get Categories Please contact support");
        }
      
        }

        public async ValueTask<Result<Category>> UpdateCategory(ulong categoryId, ulong userId, Category category, IFormFile? formFile=null)
        {
            try
            {
            var filehelper = new FileHelper();
            if (categoryId == default)
                return new("Given category Id invalid");

            if (userId == default)
                return new("Given user Id invalid");

            if (category is null)
                return new("Category update null reference error");

            if (string.IsNullOrEmpty(category.Name))
                return new("Given category Name invalid");

            var user = _unitOfWork.Users.GetById(userId);
            if(user is null)
                return new("User given Id not found");

            if(user.Role != Backend.Uckam.Entities.Enums.ERole.SuperAdmin)
                return new("This user is not allowed to edit a category");
            var result =await _unitOfWork.Categories.GetAll().FirstOrDefaultAsync(u=>u.Id==categoryId);

            if (result is null)
                return new("Category given Id Not Found");
            if(category.CreatorId!= userId)
                return new("This user is not allowed to edit a category. This category created by other user");

            
            result.Name = category.Name;
            if (formFile is not null)
                result.Image=filehelper.UpdateFileBy(result.Image,formFile);
            if(!string.IsNullOrEmpty(category.Image))
                result.Image = category.Image;
            
            result.UpdatedAt= DateTime.Now;
            var updated = await _unitOfWork.Categories.Update(result);
            return new(true) { Data=ToModel(updated)};
            } 
        catch(Exception e)
            {
                _logger.LogError($"Error occured at {nameof(CategoryService)}");
                throw new("Couldn't update category. Please contact support", e);
            }
        }
    }

