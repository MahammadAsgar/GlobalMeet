using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class ProfessionService : IProfessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProfessionRepository _professionRepository;
        public ProfessionService(IUnitOfWork unitOfWork, IMapper mapper, IProfessionRepository professionRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _professionRepository = professionRepository;
        }

        public async Task<ServiceResult> AddProfession(AddProfessionDto professionDto)
        {
            var profession = _mapper.Map<Profession>(professionDto);
            await _unitOfWork.Repository<Profession>().AddAsync(profession);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public Task<ServiceResult> DeleteProfession(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> GetProfession(int id)
        {
            var profession = await _professionRepository.GetProfession(id);
            if (profession != null)
            {
                var response = _mapper.Map<GetProfessionDto>(profession);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetProfessions()
        {
            var professions = await _professionRepository.GetProfessions();
            if (professions != null)
            {
                var response = _mapper.Map<IEnumerable<GetProfessionDto>>(professions);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateProfession(AddProfessionDto professionDto, int id)
        {
            var profession = await _professionRepository.GetProfession(id);
            if (profession != null)
            {
                if (!string.IsNullOrEmpty(professionDto.ProfessionTitle))
                {
                    profession.ProfessionTitle = professionDto.ProfessionTitle;
                }
                _unitOfWork.Repository<Profession>().Update(profession);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
