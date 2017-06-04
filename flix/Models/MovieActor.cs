using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.IdGenerators;

namespace flix.Models
{
    public class MovieActor
    {
        public long Id { get; set; }
        public long Movie_Id { get; set; }
        public string CharacterName { get; set; }
        public string CharacterDescription { get; set; }
        public bool Protagonist { get; set; }
        public bool VoiceOnly { get; set; }
        public long Actor_Id { get; set; }
    }
}