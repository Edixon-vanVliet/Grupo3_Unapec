using AutoMapper;
using Grupo3_Unapec.Application.Common.Interfaces;
using Grupo3_Unapec.Application.Subjects;
using Grupo3_Unapec.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Grupo3_Unapec.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ISubjectRepository _subjectRepository;

    private readonly ITeacherRepository _teacherRepository;

    private readonly IMapper _mapper;

    public TestController(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    [HttpGet("subject/{id}")]
    public async Task<ActionResult<GetCompleteSubjectDto?>> GetSubjectAsync(int id)
    {
        var subject = await _subjectRepository.GetWithAllInformationAsync(id, HttpContext.RequestAborted);

        if (subject is null)
        {
            return NotFound();
        }

        return _mapper.Map<GetCompleteSubjectDto>(subject);
    }

    [HttpGet("teacher/{id}")]
    public async Task<ActionResult<Teacher?>> GetTeacherAsync(int id)
    {
        return await _teacherRepository.GetWithAllInformationAsync(id, HttpContext.RequestAborted);
    }
}