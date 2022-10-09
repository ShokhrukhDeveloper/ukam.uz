#pragma warning disable
using Backend.Uckam.Models;
using Backend.Uckam.Entities.Enums;
using Backend.Uckam.Repositories;
using ukam.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Uckam.Services;

namespace Backend.Uckam.Services;

public partial class CategoryTypeService : ICategoryTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoryTypeService> _logger;

    public CategoryTypeService(IUnitOfWork unitOfWork, ILogger<CategoryTypeService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async ValueTask<Result<CategoryType>> CreateCategoryType(ulong categoryId, ulong creatorId, string name)
    {

        var existingCreator = await _unitOfWork.Users.GetAll().FirstOrDefaultAsync(c => c.Id == creatorId);
        var existingCategory = await _unitOfWork.Categories.GetAll().FirstOrDefaultAsync(c => c.Id == categoryId);

        if (string.IsNullOrWhiteSpace(name))
            return new("Name is inivalid");

        if (existingCreator is null)
            return new("Admin is not exist");

        if (existingCategory is null)
            return new("Category is not exist");

        var createdEntity = new Backend.Uckam.Entities.CategoryType(name, creatorId, categoryId);

        try
        {
            var createdCategoryType = await _unitOfWork.CategoryTypes.AddAsync(createdEntity);

            if (createdCategoryType is null)
                return new("CategoryType is not created");

            return new(true) { Data = ToModel(createdCategoryType, existingCreator, existingCategory) };
        }
        catch (System.Exception)
        {
            throw new NotImplementedException();
        }
    }
    public async ValueTask<Result<CategoryType>> DeleteCategoryType(ulong categoryTypeId)
    {
        var existingCategoryType = await _unitOfWork.CategoryTypes.GetAll().FirstOrDefaultAsync(t => t.Id == categoryTypeId);

        if (existingCategoryType is null)
            return new("Type is not found");

        try
        {
            var result = await _unitOfWork.CategoryTypes.Remove(existingCategoryType);

            return new(true) { Data = ToModelResult(result) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(CategoryTypeService)}", e);
            throw new("Couldn't delete category. Plaese contact support", e);
        }
    }

    public async ValueTask<Result<List<CategoryType>>> GetAllAsync()
    {
        var existingTypes = _unitOfWork.CategoryTypes
                                .GetAll()
                                .Select(ToModelResult)
                                .ToList();

        if (existingTypes is null)
            return new("Types are not found.");

        try
        {
            return new(true) { Data = existingTypes };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't get Types. Contact support.", e);
        }
    }

    public async ValueTask<Result<CategoryType>> GetByIdAsync(ulong categoryTypeId)
    {
        var existingCategoryType = await _unitOfWork.CategoryTypes.GetAll().FirstOrDefaultAsync(t => t.Id == categoryTypeId);

        if (existingCategoryType is null)
            return new("Type is not found");

        try
        {
            var result = ToModelResult(existingCategoryType);

            return new(true) { Data = result };
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Error occured at {nameof(CategoryTypeService)}");
            throw new("Couldn't create Type, Contact support", e);
        }
    }

    public async ValueTask<Result<CategoryType>> UpdateCategoryType(ulong categoryTypeId, ulong userId, ulong categoryId, string name)
    {
        var existingAdmins = await _unitOfWork.Users.GetAll().FirstOrDefaultAsync(u => u.Id == userId);
        var existingCategory = await _unitOfWork.Categories.GetAll().FirstOrDefaultAsync(c => c.Id == categoryId);
        var existingCategoryType = await _unitOfWork.CategoryTypes.GetAll().FirstOrDefaultAsync(t => t.Id == categoryTypeId);

        if ((existingAdmins is null) || (existingCategory is null) || existingCategoryType is null)
            return new("Type is invalid");

        existingCategoryType.Name = name;
        existingCategoryType.CategoryId = categoryId;
        existingCategoryType.CreatorId = userId;
        
        try
        {
            var UpdatedType = await _unitOfWork.CategoryTypes.Update(existingCategoryType);

            return new(true) { Data = ToModelResult(existingCategoryType) };
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Error occured at {nameof(CategoryTypeService)}");
            throw new("Couldn't create Type, Contact support", e);
        }

    }
}

