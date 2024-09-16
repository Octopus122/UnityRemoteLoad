using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

using Infrastructure.StaticData;
using Infrastructure.LightData;

namespace Infrastructure.Services.DataService
{
    public interface IDataService : IService
    {
        public LightCategory GetCategory(string categoryName);
        public LightInstallation GetInstallation(string guid);
        // public void CheckInstallation(string guid);

    }
}    
