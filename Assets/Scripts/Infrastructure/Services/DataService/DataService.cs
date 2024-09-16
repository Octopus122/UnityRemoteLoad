using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

using Infrastructure.StaticData;
using Infrastructure.LightData;

namespace Infrastructure.Services.DataService
{
    public class DataService : IDataService
    {
        
        private string _pathToJSON = "DataBase/DataBase";
    
        private Dictionary<string, LightCategory> _categories = new Dictionary<string, LightCategory>();
        private Dictionary<string, LightInstallation> _installations = new Dictionary<string, LightInstallation>();

    
        public DataService()
        {
            Dictionary<string, string> transformer = new Dictionary<string, string>();
            transformer.Add("Механика", "mechanics");
            transformer.Add("Молекулярная физика", "molecular");
            transformer.Add("Электричество и магнетизм", "electrisity");
            transformer.Add("Оптика", "optics");
            transformer.Add("Атомная физика", "atomic");


            // string json = File.ReadAllText(_pathToJSON);
            TextAsset jsonFile = Resources.Load<TextAsset>(_pathToJSON);
            // string json = jsonFile.text;
            // Debug.Log(jsonFile);
            var categories = JsonConvert.DeserializeObject<List<Category>>(jsonFile.text);

            foreach (var category in categories)
            {
                LightCategory _category = new LightCategory(transformer[category.name]);
                foreach (var installation in category.installations)
                {
                    string in_guid = installation.id;
                    LightInstallation _installation = new LightInstallation(in_guid, installation.name, transformer[category.name]);
                    foreach (var part in installation.modules)
                    {
                        LightPart _part = new LightPart(part.id, part.name);
                        _installation.AddPart(_part);
                    }
                    _category.AddInstallation(in_guid, _installation);
                    _installations.Add(in_guid,_installation);
                }
                _categories.Add(transformer[category.name], _category);
            }
            Debug.Log(_installations.ContainsKey("74b23ccb-9bb7-4934-a780-2ca5ae218b95"));
            Debug.Log("====Data Service is created====");
        }

        public LightCategory GetCategory(string categoryName)
        {
            return _categories[categoryName];
        }

        public LightInstallation GetInstallation(string guid)
        {
            return _installations[guid];
        }
    
    }
}
