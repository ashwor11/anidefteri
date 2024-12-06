using AniDefteri.Application.Features.Families.DTOs;
using AniDefteri.Application.Features.Families.Rules;
using AniDefteri.Application.Services.Interfaces;
using AniDefteri.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AniDefteri.Application.Features.Families.Queries;

public class GetFamilyQuery : IRequest<GetFamilyResponseDto>
{
    public GetFamilyDTO Request { get; set; }

    public class GetFamilyQueryHandler : IRequestHandler<GetFamilyQuery, GetFamilyResponseDto>
    {
        private readonly FamilyBusinessRules _familyBusinessRules;
        private readonly IFamilyRepository _familyRepository;
        private readonly IMapper _mapper;

        public GetFamilyQueryHandler(FamilyBusinessRules familyBusinessRules, IFamilyRepository familyRepository, IMapper mapper)
        {
            _familyBusinessRules = familyBusinessRules;
            _familyRepository = familyRepository;
            _mapper = mapper;
        }

        public async Task<GetFamilyResponseDto> Handle(GetFamilyQuery request, CancellationToken cancellationToken)
        {
            Family family = await _familyRepository.GetAsync(f => f.Id == request.Request.FamilyId,
                include: q => q.Include(f => f.Persons).ThenInclude(p => p.Relationships), cancellationToken: cancellationToken)!;
            _familyBusinessRules.FamilyMustExist(family);

            GetFamilyResponseDto familyDto = _mapper.Map<GetFamilyResponseDto>(family);
            
            return familyDto;
            
        }
    }
}