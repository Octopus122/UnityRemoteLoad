using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.IO;

using Infrastructure.Services.DataService;
using Infrastructure.Services.FlutterMessageService;
using Infrastructure.LightData;

namespace Infrastructure.Services.DownloadService
{
    public class DownloadService : IDownloadService
    {
        private IDataService _dataservice;
        private IFlutterMessageService _fluttermessageservice;
        public DownloadService()
        {
            return;
        }
        public DownloadService(IDataService dataservice, IFlutterMessageService fluttermessageservice)
        {
            _dataservice = dataservice;
            _fluttermessageservice = fluttermessageservice;
            _fluttermessageservice.RegisterDownloadService(this);
        }
        public IEnumerator DownloadCategory(string category)
        {
            Debug.Log("Началась загрузка раздела...");
            _fluttermessageservice.FinishLoading();
            AsyncOperationHandle<IList<GameObject>> handle = Addressables.LoadAssetsAsync<GameObject>(category, (obj) =>{
                Debug.Log( obj.name);
            }
            );
 
            while (!handle.IsDone)
            {
                // Debug.Log("Процент загрузки = "+handle.PercentComplete);
                _fluttermessageservice.SendMessage("progressbar"+handle.PercentComplete);
                yield return null;
            }
 
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Загрузка успешно завершилась");
                _fluttermessageservice.SendMessage("printresult"+"Загрузка раздела завершилась успешно");
                _fluttermessageservice.SendMessage("progressbar"+handle.PercentComplete);
                Debug.Log(handle.Result);
                // _fluttermessageservice.SpawnResult(handle.Result);
                Addressables.Release(handle);
            }
        }
        public IEnumerator DownloadInstallation(string guid)
        {   
            LightInstallation install = _dataservice.GetInstallation(guid);
            string name = install.GetUniqueName();

            Debug.Log("Началась загрузка установки...");
            _fluttermessageservice.FinishLoading();
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(name);
 
            while (!handle.IsDone)
            {
                // Debug.Log("Процент загрузки = "+handle.PercentComplete);
                _fluttermessageservice.SendMessage("progressbar"+handle.PercentComplete);
                yield return null;
            }
 
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Загрузка успешно завершилась");
                _fluttermessageservice.SendMessage("printresult"+"Загрузка установки завершилась успешно");
                _fluttermessageservice.SendMessage("progressbar"+handle.PercentComplete);
                Debug.Log(handle.Result);
                _fluttermessageservice.SpawnResult(handle.Result);
                Addressables.Release(handle);
            }
            
        }
        public IEnumerator CheckInstallation(string guid)
        {
            LightInstallation install = _dataservice.GetInstallation(guid);
            string name = install.GetUniqueName();
            var handle = Addressables.GetDownloadSizeAsync(name);
            _fluttermessageservice.FinishLoading();
 
            while (!handle.IsDone)
            {
                // Debug.Log("Процент загрузки = "+handle.PercentComplete);
                // _fluttermessageservice.SendMessage("progressbar"+handle.PercentComplete);
                yield return null;
            }
 
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                // Debug.Log("Загрузка успешно завершилась");
                if(handle.Result == 0)
                {
                    Debug.Log("Модель установки загружена.");
                    _fluttermessageservice.SendMessage("printresult"+"Модель установки загружена");
                }
                else 
                {
                    Debug.Log("Модель установки не загружена.");
                    _fluttermessageservice.SendMessage("printresult"+"Модель установки не загружена");
                }
                // _fluttermessageservice.SpawnResult(handle.Result);
                Addressables.Release(handle);
            }
        }
        public IEnumerator CheckCategory(string category)
        {
            var handle = Addressables.GetDownloadSizeAsync(category);
            _fluttermessageservice.FinishLoading();
 
            while (!handle.IsDone)
            {
                // Debug.Log("Процент загрузки = "+handle.PercentComplete);
                // _fluttermessageservice.SendMessage("progressbar"+handle.PercentComplete);
                yield return null;
            }
 
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                // Debug.Log("Загрузка успешно завершилась");
                if(handle.Result == 0)
                {
                    Debug.Log("Модели установок из раздела загружены.");
                    _fluttermessageservice.SendMessage("printresult"+"Модели установок из раздела загружены");
                }
                else 
                {
                    Debug.Log("Модели установок из раздела не загружены.");
                    _fluttermessageservice.SendMessage("printresult"+"Модели установок из раздела не загружены");
                }
                // _fluttermessageservice.SpawnResult(handle.Result);
                Addressables.Release(handle);
            }
        }

        public void ClearCashe()
        {
            Debug.Log("Начинается очистка кэша");
            bool success = Caching.ClearCache();
            if (success)
            {
                Debug.Log("Кэш очищен");
                _fluttermessageservice.SendMessage("printresult"+"Данные о загруженных моделях удалены");
            }
            else
            {
                Debug.Log("Кэш не очищен");
                _fluttermessageservice.SendMessage("printresult"+"Данные о загруженных моделях не удалены");
            }
            
        }
        // public void Send(GameObject obj)
        // {
        //     _fluttermessageservice.SendMessage("printresult"+"Загружена модель:"+obj);
        // }
            
    }

}
