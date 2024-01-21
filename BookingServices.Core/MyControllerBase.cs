using BookingServices.Core.Models.ControllerResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Core;

[Produces("application/json", new string[] { })]
[Authorize]
public abstract class MyControllerBase : ControllerBase
{

    protected IActionResult ApiOk(bool data = true) => Ok(new ApiResult { Data = data });

    protected IActionResult ApiOk<T>(ApiPaged<T> data) where T : class
    {
        return Ok(data);
    }

    protected IActionResult ApiOk<T>(T data) where T : class
    {
        return Ok(new ApiResult<T> { Data = data });
    }

    protected IActionResult ApiOk<T>(string message, T data) where T : class
    {
        return Ok(new ApiResult<T> { Message = message, Data = data });
    }

    protected IActionResult ApiOk<T>(string message, string code, T data) where T : class
    {
        return Ok(new ApiResult<T> { Message = message, Code = code, Data = data });
    }

    protected IActionResult ApiOk<T>(IEnumerable<T> data, int totalRecords) where T : class
    {
        return Ok(new ApiPaged<T> { Items = data, TotalRecords = totalRecords });
    }

    protected IActionResult ApiOk<T>(string message, string code, IEnumerable<T> data, int totalRecords, int page, int pageSize) where T : class
    {
        return Ok(new ApiPaged<T> { Message = message, Code = code, Items = data, TotalRecords = totalRecords });
    }


}
