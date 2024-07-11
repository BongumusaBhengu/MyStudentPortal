using AutoMapper;
using MyStudentPortal.Application.Features.Courses;
using MyStudentPortal.Application.Features.Enrollments.Queries;
using MyStudentPortal.Application.Features.Users;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        #region Public Constructors

        public MappingProfile()
        {
            //Entity to Dto Application User
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            //Dto to Entity Application User
            CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            //Dto to Entity Application Enrollment
            CreateMap<EnrollmentsDto, Enrollment>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => src.EnrollmentDate))
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId));

            //Entity to Dto Course
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        #endregion Public Constructors
    }
}