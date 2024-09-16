using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

using Infrastructure.Services.DownloadService;

namespace Infrastructure.Services.FlutterMessageService
{
    public interface IFlutterMessageService : IService
    {
        public void SendMessage(string message);
        public void RecieveMessage(string message);
        public void Register(IFlutterService service);
        public void RegisterDownloadService(IDownloadService service);
        public void FinishLoading();
        public void SpawnResult(GameObject obj);
        public void EnterGameLoop();
    }
}