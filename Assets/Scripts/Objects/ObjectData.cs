// using AR;
// using Infrastructure.IHighLightService;
using Infrastructure.Services;
// using Infrastructure.StaticData;
using Infrastructure.LightData;
using UnityEngine;

namespace Objects
{
    // [RequireComponent(typeof(ObjectHighlighter))]
    public class ObjectData : MonoBehaviour
    {
        public LightPart data;
        // public ObjectHighlighter highlighter;
        // private IHighLightService _highLightService;

        // private void Awake()
        // {
        //     highlighter = GetComponent<ObjectHighlighter>();
        //     _highLightService = AllServices.Container.Single<IHighLightService>();
        //     Register();
        // }

        // public void Register()
        // {
        //     _highLightService.RegisterARParts(this);
        // }
    }
}