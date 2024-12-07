using AniDefteri.Application.Features.Families.DTOs;
using AniDefteri.Application.Features.Families.Rules;
using AniDefteri.Application.Services.Interfaces;
using AniDefteri.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace AniDefteri.Application.Features.Families.Commands;

public class AddPersonCommand : IRequest<AddedPersonDTO>
{
    public AddPersonDTO AddPersonDto { get; set; }
}

public class AddPersonCommandHandler(
    IPersonRepository personRepository,
    IFamilyRepository familyRepository,
    IMapper mapper,
    FamilyBusinessRules familyBusinessRules)
    : IRequestHandler<AddPersonCommand, AddedPersonDTO>
{
    public async Task<AddedPersonDTO> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {
        Family? family = await familyRepository.GetAsync(f => f.Id == request.AddPersonDto.FamilyId, cancellationToken: cancellationToken);
        familyBusinessRules.FamilyMustExist(family);
        Person person = mapper.Map<Person>(request.AddPersonDto);
        Person addedPerson = await personRepository.CreateAsync(person);
        AddedPersonDTO addedPersonDto = mapper.Map<AddedPersonDTO>(addedPerson);
        return addedPersonDto;
    }
}