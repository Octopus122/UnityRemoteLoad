using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.LightData
{
    public class LightInstallation 
    {
       private string _guid;
       private string _number;
       private AssetLabelReference _label = new AssetLabelReference();
       private bool _isLoaded;

       private List<LightPart> _parts = new List<LightPart>();

       public LightInstallation(string guid, string number, string label)
       {
            _guid = guid;
            _number = number;
            _label.labelString = label;
       }

       public void SetInstallationLoaded()
       {
            _isLoaded = true;
       }

       public void CheckInstallation()
       {

       }

       public void AddPart(LightPart part)
       {
            _parts.Add(part);
       }

       public string GetUniqueName()
       {
          return string.Format("{0}_{1}", _label.labelString, _number);
       }
    }
}
