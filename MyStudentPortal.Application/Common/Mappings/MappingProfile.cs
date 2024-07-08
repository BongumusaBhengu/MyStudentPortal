using AutoMapper;
using MyStudentPortal.Application.Features.Enrollments.Queries;
using MyStudentPortal.Application.Features.Students.Queries;
using MyStudentPortal.Application.Features.Students.Queries.Update;
using MyStudentPortal.Application.Features.Users;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        #region Public Constructors

        public MappingProfile()
        {
            //Entity to Dto Student
            CreateMap<Student, StudetDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.IdentityNumber))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            //Dto to Entity Student
            CreateMap<StudetDto, Student>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.IdentityNumber))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            //Entity to Dto Student
            CreateMap<Student, UpdateStudentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.IdentityNumber))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            //Dto to Entity Student
            CreateMap<UpdateStudentDto, Student>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.IdentityNumber))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            //Entity to Dto Application User
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

            //Dto to Entity Application User
            CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

            //Dto to Entity Application Enrollment
            CreateMap<EnrollmentsDto, Enrollment>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => src.EnrollmentDate))
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId));
        }

        #endregion Public Constructors
    }
}