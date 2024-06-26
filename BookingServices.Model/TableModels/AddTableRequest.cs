﻿namespace BookingServices.Model.TableModels;

public class AddTableRequest
{
    public AddTableRequest(Guid restaurantFloorId, string tableName, int tableType, int capacity, string extensionData)
    {
        RestaurantFloorId = restaurantFloorId;
        TableName = tableName;
        TableType = tableType;
        Capacity = capacity;
        ExtensionData = extensionData;
    }
    public AddTableRequest()
    {
        
    }
    public Guid RestaurantFloorId { get; set; }
    public string TableName { get; set; }
    public int TableType { get; set; }
    public int Capacity { get; set; }
    public string ExtensionData { get; set; }
}