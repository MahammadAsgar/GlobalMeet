using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Entities.User;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Identity;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyRepository _companyRepository;

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository, UserManager<AppUser> userManager, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogRepository = blogRepository;
            _userManager = userManager;
            _companyRepository = companyRepository;
        }
        public async Task<ServiceResult> AddBlog(AddBlogDto blogDto, int userId)
        {
            var blog = _mapper.Map<Blog>(blogDto);
            blog.IsActive = true;
            var company = await _companyRepository.GetCompanyByUser(userId);
            blog.CompanyId = company.Id;
            await _unitOfWork.Repository<Blog>().AddAsync(blog);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetBlogDto>(blog);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeleteBlog(AddBlogDto blogDto, int id, int userId)
        {
            var blog = await _blogRepository.GetBlog(id);
            if (blog != null)
            {
                _unitOfWork.Repository<Blog>().Delete(blog);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetBlog(int id)
        {
            var blog = await _blogRepository.GetBlog(id);
            if (blog != null)
            {
                var response = _mapper.Map<GetBlogDto>(blog);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetBlogs()
        {
            var blogs = await _blogRepository.GetBlogs();
            if (blogs != null)
            {
                var response = _mapper.Map<ICollection<GetBlogDto>>(blogs);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetBlogsByUser(int userId)
        {
            var company = await _companyRepository.GetCompanyByUser(userId);
            var blogs = await _blogRepository.GetBlogsByCompany(company.Id);
            if (blogs != null)
            {
                var response = _mapper.Map<IEnumerable<GetBlogDto>>(blogs);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateBlog(AddBlogDto blogDto, int id)
        {
            var blog = await _blogRepository.GetBlog(id);
            if (blog != null)
            {
                if (!string.IsNullOrEmpty(blogDto.Title))
                {
                    blog.Title = blogDto.Title;
                }

                if (!string.IsNullOrEmpty(blogDto.Description))
                {
                    blog.Description = blogDto.Description;
                }
                _unitOfWork.Repository<Blog>().Update(blog);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
