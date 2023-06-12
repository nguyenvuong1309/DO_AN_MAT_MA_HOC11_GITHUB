using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEN_NGAN_HANG
{
    public class Contract
    {
        [BsonElement("CONTRACT")]
        public string CONTRACT { get; set; }
        public Contract(string c)
        {
            this.CONTRACT = c;
        }
    }
}
