﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Amnhac.Models
{
    public class SystemConfig
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("GRP_CRT")]
        public string CategoryToChart { get; set; }
    }
}
