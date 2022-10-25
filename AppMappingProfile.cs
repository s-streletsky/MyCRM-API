using AutoMapper;
using MyCRM_API.Models.DTO.Clients;
using MyCRM_API.Models.DTO.ExchangeRates;
using MyCRM_API.Models.DTO.Manufacturers;
using MyCRM_API.Models.DTO.Orders;
using MyCRM_API.Models.DTO.OrdersItems;
using MyCRM_API.Models.DTO.Payments;
using MyCRM_API.Models.DTO.StockArrivals;
using MyCRM_API.Models.DTO.StockItems;
using MyCRM_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ClientEntity, ClientAllResponse>();
            CreateMap<ClientRequest, ClientEntity>();
            CreateMap<ClientEditRequest, ClientEntity>();
            CreateMap<ClientEntity, ClientResponse>();
            CreateMap<ClientEntity, ClientProfileResponse>();
            CreateMap<ExchangeRateEntity, ExchangeRateAllResponse>();
            CreateMap<ExchangeRateRequest, ExchangeRateEntity>();
            CreateMap<ExchangeRateEntity, ExchangeRateResponse>();
            CreateMap<ExchangeRateEditRequest, ExchangeRateEntity>();
            CreateMap<ManufacturerEntity, ManufacturerResponse>().ReverseMap();
            CreateMap<ManufacturerRequest, ManufacturerEntity>();
            CreateMap<OrderEntity, OrderResponse>();
            CreateMap<OrderEntity, OrderFullResponse>();
            CreateMap<OrderRequest, OrderEntity>();
            CreateMap<OrderEditRequest, OrderEntity>();
            CreateMap<StockItemEntity, StockItemAllResponse>();
            CreateMap<StockItemRequest, StockItemEntity>();
            CreateMap<StockItemEntity, StockItemResponse>().ReverseMap();
            CreateMap<StockArrivalEntity, StockArrivalAllResponse>();
            CreateMap<StockArrivalRequest, StockArrivalEntity>();
            CreateMap<StockArrivalEntity, StockArrivalResponse>().ReverseMap();
            CreateMap<OrderItemRequest, OrderItemEntity>();
            CreateMap<OrderItemEntity, OrderItemResponse>().ReverseMap();
            CreateMap<PaymentEntity, AllPaymentsDto>();
            CreateMap<PaymentCreateDto, PaymentEntity>();
            CreateMap<PaymentEditDto, PaymentEntity>().ReverseMap();
        }
    }
}
