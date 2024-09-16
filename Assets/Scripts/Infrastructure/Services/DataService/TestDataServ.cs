using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.AddressableAssets;
using Infrastructure.StaticData;

public class TestDataServ : MonoBehaviour
{
    private string json;

    void Start()
    {
        json = File.ReadAllText("Assets/Resources/DataBase/DataBase.json");
        var categories = JsonConvert.DeserializeObject<List<Category>>(json);
        // Debug.Log(categories[1].installations[0].name);

    }

}
