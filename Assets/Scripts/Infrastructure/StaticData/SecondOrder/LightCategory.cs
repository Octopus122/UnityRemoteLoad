using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.LightData
{
    public class LightCategory 
    {

        private AssetLabelReference _label = new AssetLabelReference();
        public string name
        {
            get { return _label.labelString;}
        }
        private Dictionary<string, LightInstallation> _installations  = new Dictionary<string, LightInstallation>();
        private bool _isLoaded = false;

        public LightCategory(string name)
        {
            _label.labelString = name;
        }

        public void AddInstallation(string guid, LightInstallation installation)
        {
            _installations.Add(guid, installation);
        }

        public void SetCategoryLoaded(bool isLoaded)
        {
            if(isLoaded) _isLoaded = true;
            else _isLoaded = false;
        }
    }
}
