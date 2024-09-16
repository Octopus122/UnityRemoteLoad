using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.ResourceManagement.AsyncOperations;

using Infrastructure.Services.DownloadService;

namespace Infrastructure.Services.FlutterMessageService
{
    public class FlutterMessageService : IFlutterMessageService
    {
        private Dictionary<string, IFlutterService> _services = new Dictionary<string, IFlutterService>();
        private IDownloadService _downloadService;
        private FlutterManager _manager;
        // private GameObject _inputGameObject;
        private ReadInputScript _inputManager;
        public void SendMessage(string message)
        {
            _inputManager.RecieveMessage(message);
        }
        public void RecieveMessage(string message)
        {
            if (message.StartsWith("downloadbyguid"))
            {
                // Debug.Log("1");
                string guid = message.Replace("downloadbyguid", "");
                _manager.DownloadByGuid(guid);
            }
            if (message.StartsWith("downloadbycategory"))
            {
                // Debug.Log("1");
                string label = message.Replace("downloadbycategory", "");
                _manager.DownloadByCategory(label);
            }

            if (message.StartsWith("checkbyguid"))
            {
                // Debug.Log("1");
                string guid = message.Replace("checkbyguid", "");
                _manager.CheckByGUID(guid);
            }
            if (message.StartsWith("checkbycategory"))
            {
                // Debug.Log("1");
                string label = message.Replace("checkbycategory", "");
                _manager.CheckByCategory(label);
            }
            if(message.StartsWith("clearcashe"))
            {
                _downloadService.ClearCashe();
            }
            return;
        }

        public void Register(IFlutterService service)
        {
            _services.Add(service.GetType().Name, service);
        }
        public void RegisterDownloadService(IDownloadService service)
        {
            _downloadService = service;
            // _manager.SetDownloadService(service);
        }
        public void FinishLoading()
        {
            _manager.FinishLoading();
        }
        public void SpawnResult(GameObject obj)
        {
            _manager.SpawnResult(obj);
        }
        public void EnterGameLoop()
        {
            GameObject inputGameObject =  GameObject.FindGameObjectsWithTag("InputManagerTag")[0];
            _inputManager = inputGameObject.GetComponent<ReadInputScript>();
            _manager = inputGameObject.GetComponent<FlutterManager>();
            _manager.SetDownloadService(_downloadService);
            _inputManager.Register(this);

        }
    }
}
