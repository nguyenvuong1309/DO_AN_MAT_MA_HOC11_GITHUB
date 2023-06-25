using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BEN_BAN
{
    public class Contract
    {
        [BsonElement("CONTRACT")]
        public string CONTRACT { get; set; }
        public List<string> parties { get; set; }
        public DateTime dateTime { get; set; }
        public List<string> arrayKey { get; set; }
        public List<string> arrayIv { get; set; }
        public Contract(string c,List<string> p, DateTime d, List<string> arrKey, List<string> arrayIv)
        {
            this.CONTRACT = c;
            this.parties = p;
            this.dateTime = d;
            this.arrayKey = arrKey;
            this.arrayIv = arrayIv;
        }
    }
}
