using System;
using System.Collections.Generic;
// using AR;
// using Infrastructure.IHighLightService;
// using Infrastructure.Services;
using UnityEngine;

namespace Objects
{
    // [RequireComponent(typeof(ObjectPicker))]
    public class Setup : MonoBehaviour
    {
        public List<ObjectData> parts = new List<ObjectData>();
        // private IHighLightService _highLightService;

        private void Awake()
        {
            // _highLightService = AllServices.Container.Single<IHighLightService>();
        }

    //     private void OnDestroy()
    //     {
    //         Unregister();
    //     }
        
    //     private void Unregister()
    //     {
    //         _highLightService.Unselect();
    //         _highLightService.UnregisterARParts();
    //     }
    }
}
