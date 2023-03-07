using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class ArchivedMeetService : IArchivedMeetService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArchivedMeetRepository _archivedMeetRepository;
        public ArchivedMeetService(IMapper mapper, IUnitOfWork unitOfWork, IArchivedMeetRepository archivedMeetRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _archivedMeetRepository = archivedMeetRepository;
        }
        public async Task<ServiceResult> GetArchivedMeet(int id)
        {
            var archivedMeet = await _archivedMeetRepository.GetArchivedMeet(id);
            if (archivedMeet != null)
            {
                var response = _mapper.Map<GetArchivedMeetDto>(archivedMeet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetArchivedMeetsByUser(int userId)
        {
            var archivedMeets = await _archivedMeetRepository.GetArchivedMeetByUser(userId);
            if (archivedMeets != null)
            {
                var response = _mapper.Map<ICollection<GetArchivedMeetDto>>(archivedMeets);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
    }
}
