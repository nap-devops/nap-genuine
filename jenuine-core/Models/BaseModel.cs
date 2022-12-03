using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Its.Jenuiue.Core.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime ModifiedDtm { get; set; }
        
        public DateTime CreatedDtm { get; set; }

        public List<Label> Labels { get; set; }

        public BaseModel()
        {
            Labels = new List<Label>();            
        }
    }
}
