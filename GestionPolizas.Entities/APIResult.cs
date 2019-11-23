using System.Collections.Generic;

namespace GestionPolizas.Entities
{
    public class APIResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIResult"/> class.
        /// </summary>
        public APIResult()
        {
            DataError = false;
            ResultMessage = string.Empty;
        }

        public List<T> ResultObject { get; set; }
        public long TotalRecordsByQuery { get; set; }
        public string ResultMessage { get; set; }
        public bool DataError { get; set; }
    }
}
