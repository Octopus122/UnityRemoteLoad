using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.LightData
{
    public class LightPart 
    {
       private string _guid;
       private string _name;

       public LightPart(string guid, string name)   
       {
            _guid = guid;
            _name = name;
       }
    }
}
