namespace BookingServices.Core.Models.ControllerResponse
{
    public class ApiPaged<T> where T : class
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
        /// Gets or sets the data.
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the total records.
        /// </summary>
        public int TotalRecords { get; set; }
    }
}
