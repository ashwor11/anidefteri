using AniDefteri.Application.Features.Families.DTOs;
using AniDefteri.Application.Features.Families.Queries;
using AniDefteri.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AniDefteri.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FamilyController : BaseController
{
    

    [HttpGet("{familyId}")]
    public async Task<IActionResult> GetFamily([FromRoute] int familyId)
    {
        GetFamilyDTO request = new GetFamilyDTO() { FamilyId = familyId };
        GetFamilyResponseDto family = await Mediator.Send(new GetFamilyQuery(){Request = request});
        return Ok(family);
    }
}