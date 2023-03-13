using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.Repositories.Implementations.Main;
using GlobalMeet.DataAccess.UnitOfWorks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResult> AddCategory(AddCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.IsActive = true;
            await _unitOfWork.Repository<Category>().AddAsync(category);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
        public async Task<ServiceResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category != null)
            {
                category.IsActive = false;
                _unitOfWork.Repository<Category>().Update(category);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            if (categories != null)
            {
                var response = _mapper.Map<ICollection<GetCategoryDto>>(categories);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category != null)
            {
                var response = _mapper.Map<GetCategoryDto>(category);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateCategory(AddCategoryDto categoryDto, int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category != null)
            {
                if (!string.IsNullOrEmpty(categoryDto.CategoryTitle))
                {
                    category.CategoryTitle = categoryDto.CategoryTitle;
                }
                _unitOfWork.Repository<Category>().Update(category);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
