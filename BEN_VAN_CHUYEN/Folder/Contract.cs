using MongoDB.Bson.Serialization.Attributes;
namespace BEN_VAN_CHUYEN
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
