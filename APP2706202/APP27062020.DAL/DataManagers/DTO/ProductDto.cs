using System;

namespace APP27062020.DAL.DTO
{
    public class ProductDto
    {
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public string TYPE { get; set; }
        public string FORSTAGE { get; set; }
        public string SHORTDESCRIPTION { get; set; }
        public string PRODUCTURL { get; set; }
        public string USERID { get; set; }
    }
}
