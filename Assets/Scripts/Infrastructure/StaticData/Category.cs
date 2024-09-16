using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Infrastructure.StaticData
{
    public class Category 
    {
        public string name;
        public string semester;
        public bool enabled;
        public List<Installation> installations = new List<Installation>();
    }
}