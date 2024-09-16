using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

using Infrastructure.Services.DataService;
using Infrastructure.Services.DataService;
using Infrastructure.LightData;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IDataService _dataService;
        public GameFactory(IDataService dataService)
        {
            _dataService = dataService;
            // Debug.Log(_dataService.ContainsKey("74b23ccb-9bb7-4934-a780-2ca5ae218b95"));
            Debug.Log("====Factory is created====");
        }
    }
}