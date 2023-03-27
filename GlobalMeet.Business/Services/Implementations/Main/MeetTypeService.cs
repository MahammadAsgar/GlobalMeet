using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class MeetTypeService : IMeetTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMeetTypeRepository _meetTypeRepository;
        public MeetTypeService(IUnitOfWork unitOfWork, IMapper mapper, IMeetTypeRepository meetTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _meetTypeRepository = meetTypeRepository;
        }

        public async Task<ServiceResult> AddMeetType(AddMeetTypeDto meetTypeDto)
        {
            var type = _mapper.Map<MeetType>(meetTypeDto);
            await _unitOfWork.Repository<MeetType>().AddAsync(type);
            _unitOfWork.Commit();
            return new ServiceResult(true);

        }

        public async Task<ServiceResult> GetMeetType(int id)
        {
            var type = await _meetTypeRepository.GetMeetType(id);
            if (type != null)
            {
                var response = _mapper.Map<GetMeetTypeDto>(type);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeetTypes()
        {
            var type = await _meetTypeRepository.GetMeetTypes();
            if (type != null)
            {
                var response = _mapper.Map<ICollection<GetMeetTypeDto>>(type);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
    }
}
