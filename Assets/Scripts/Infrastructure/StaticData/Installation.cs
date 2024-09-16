using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.StaticData
{
    public class Installation
    {
        public string id;
        public string name;
        // public string name_eng;
        public bool enabled;
        public string labName;
        // public string labName_eng;
        // public bool isLoaded = false;
        public string room;
        // public string room_eng;
        public string purpose;
        // public string purpose_eng;
        public string url;
        // public string lab_in_semester;
        public List<InstallationPart> modules = new List<InstallationPart>();
    }
}
