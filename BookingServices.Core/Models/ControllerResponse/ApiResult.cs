namespace BookingServices.Core.Models.ControllerResponse
{
    public class ApiResult<T> where T : class
    {
        /// <summary>
        /// Thông báo
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Kết quả
        /// </summary>
        public T Data { get; set; }

    }
    public class ApiResult
    {

        /// <summary>
        /// Thông báo
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Kết quả
        /// </summary>
        public bool? Data { get; set; }

    }
}
