using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.TableModels;

namespace BookingServices.Configs.Mappers;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<TableDTO, Tables>().ReverseMap();
        CreateMap<BookingTableDTO, Tables>().ReverseMap();
        CreateMap<AddTableRequest, Tables>().ReverseMap();
        CreateMap<UpdateTableRequest, Tables>().ReverseMap();
    }
}
