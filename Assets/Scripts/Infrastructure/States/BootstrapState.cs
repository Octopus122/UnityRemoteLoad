using Infrastructure.Services;
// using Objects;
using UnityEditor;
using UnityEngine;

using Infrastructure.Services.DataService;
using Infrastructure.Factory;
using Infrastructure.Services.DownloadService;
using Infrastructure.Services.FlutterMessageService;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter() => _sceneLoader.Load(Initial, EnterLoadLevel);

        public void Exit()
        {
            
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("MainScene");
        } 

        private void RegisterServices()
        {
            
            _services.Register<IDataService>(new DataService());
            _services.Register<IFlutterMessageService>(new FlutterMessageService());
            _services.Register<IDownloadService>(new DownloadService(_services.Single<IDataService>(), _services.Single<IFlutterMessageService>()));
            _services.Register<IGameFactory>(new GameFactory(_services.Single<IDataService>()));

            Debug.Log("==== Service registration is fineshed ====");
        }

        
    }
}