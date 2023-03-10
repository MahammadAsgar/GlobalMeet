//using AutoMapper;
//using GlobalMeet.Business.Results;
//using GlobalMeet.Business.Services.Abstractions.Main;
//using GlobalMeet.DataAccess.Entities.Main;
//using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
//using GlobalMeet.DataAccess.UnitOfWorks;

//namespace GlobalMeet.Business.Services.Implementations.Main
//{
//    public class ProfessionService : IProfessionService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;
//        private readonly ICategoryRepository _professionRepository;
//        public ProfessionService(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository professionRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _professionRepository = professionRepository;
//        }

//        public async Task<ServiceResult> AddProfession(AddProfessionDto professionDto)
//        {
//            var profession = _mapper.Map<Category>(professionDto);
//            await _unitOfWork.Repository<Category>().AddAsync(profession);
//            _unitOfWork.Commit();
//            return new ServiceResult(true);
//        }

//        public Task<ServiceResult> DeleteProfession(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<ServiceResult> GetProfession(int id)
//        {
//            var profession = await _professionRepository.GetProfession(id);
//            if (profession != null)
//            {
//                var response = _mapper.Map<GetProfessionDto>(profession);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> GetProfessions()
//        {
//            var professions = await _professionRepository.GetProfessions();
//            if (professions != null)
//            {
//                var response = _mapper.Map<IEnumerable<GetProfessionDto>>(professions);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }


//    }
//}
