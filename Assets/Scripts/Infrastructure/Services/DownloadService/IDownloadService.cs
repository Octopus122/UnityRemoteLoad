using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

using Infrastructure.Services.FlutterMessageService;

// using Infrastructure.Services

namespace Infrastructure.Services.DownloadService
{
    public interface IDownloadService : IService, IFlutterService
    {
        public IEnumerator DownloadCategory(string category);
        
        // public IEnumerator DownloadInstallation(string guid);
        public IEnumerator DownloadInstallation(string guid);
        // public IEnumerator CheckPercent(AsyncOperationHandle<GameObject> opHandle);
        public IEnumerator CheckCategory(string category);
        public IEnumerator CheckInstallation(string guid);
        public void ClearCashe();
        // public void Send(GameObject obj);
    }
}