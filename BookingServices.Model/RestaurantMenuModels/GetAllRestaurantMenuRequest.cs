﻿using BookingServices.Core.Models;
using BookingServices.Entities.Enum;

namespace BookingServices.Model.RestaurantMenuModels;

public class GetAllRestaurantMenuRequest : PagingRequest
{
    public EMenuType? MenuType { get; set; }
}