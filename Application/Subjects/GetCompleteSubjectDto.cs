using AutoMapper;
using Grupo3_Unapec.Domain.Entities;
using System.Collections.ObjectModel;

namespace Grupo3_Unapec.Application.Subjects;

public class GetCompleteSubjectDto
{
    public required string Name { get; set; }

    public required string Code { get; set; }

    public required string Type { get; set; }

    public int Course { get; set; }

    public float Theoretical { get; set; }

    public float Laboratory { get; set; }

    public required string Duration { get; set; }

    public string? Title { get; set; }

    public string? Area { get; set; }

    public string? TitleConfiguration { get; set; }

    public ICollection<string> Teachers { get; set; } = new Collection<string>();

    public ICollection<string> IncompatiblesSubjects { get; set; } = new Collection<string>();

    public ICollection<string> EquivalentSubjects { get; set; } = new Collection<string>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Subject, GetCompleteSubjectDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code.ToString()))
                .ForMember(dest => dest.Theoretical, opt => opt.MapFrom(src => src.Credits.Theoretical))
                .ForMember(dest => dest.Laboratory, opt => opt.MapFrom(src => src.Credits.Laboratory))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Name))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area.Name))
                .ForMember(dest => dest.TitleConfiguration, opt => opt.MapFrom(src => src.TitleConfiguration.Name))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers.Select(teacher => teacher.Name)))
                .ForMember(dest => dest.IncompatiblesSubjects, opt => opt.MapFrom(src => src.IncompatiblesSubjects.Select(incompatibleSubject => incompatibleSubject.Name)))
                .ForMember(dest => dest.EquivalentSubjects, opt => opt.MapFrom(src => src.EquivalentSubjects.Select(equivalentSubject => equivalentSubject.Name)));
        }
    }
}