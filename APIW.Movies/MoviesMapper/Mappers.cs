using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using AutoMapper;
using System.Runtime;

namespace APIW.Movies.MoviesMapper
{
    public class Mappers : Profile 
    {
        public Mappers() 
        {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}
