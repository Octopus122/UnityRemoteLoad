using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

using Infrastructure.Services.DownloadService;

    public class FlutterManager : MonoBehaviour
    {   
        private IDownloadService _downloadservice;

        private bool _loadByGuid = false; 
        private bool _loadByCategory = false;
        private bool _checkByGUID = false;
        private bool _checkByCategory = false;
        private bool _instantiate = false;
        // private bool _progressBar = false;
        // private AsyncOperationHandle<GameObject> _handle;
        
        private string _guid;
        private string _category;
        private GameObject _gameObjToSpawn;
        private GameObject _clone;
        void Update()
        {
            if (_loadByGuid) 
            {
                // handle = DownloadInstallation(_guid);
                // StartCoroutine(CheckPercent(handle));
                StartCoroutine(_downloadservice.DownloadInstallation(_guid));
            }
            if (_loadByCategory) 
            {
                // Debug.Log("3");
                StartCoroutine(_downloadservice.DownloadCategory(_category));
            }
            if (_checkByGUID) 
            {
                // Debug.Log("3");
                StartCoroutine(_downloadservice.CheckInstallation(_guid));
            }
            if (_checkByCategory) 
            {
                // Debug.Log(_category);
                StartCoroutine(_downloadservice.CheckCategory(_category));
            }
            if (_instantiate)
            {
                _instantiate = false;
                // Instantiate(_gameObjToSpawn, new Vector3(76,-13,91), Quaternion.identity);
                // _downloadservice.Send(_gameObjToSpawn);
                // Debug.Log(_clone);
            }
            
        }
        public void DownloadByGuid(string guid)
        {
            // Debug.Log("2");
            _guid = guid;
            _loadByGuid = true;
        }
        public void DownloadByCategory(string label)
        {
            // Debug.Log("2");
            _category = label;
            _loadByCategory = true;
        }

        public void CheckByGUID(string guid)
        {
            _guid = guid;
            _checkByGUID = true;
        } 

        public void CheckByCategory(string label)
        {
            _category = label;
            _checkByCategory = true;
        } 
        
        public void FinishLoading()
        {
            _loadByGuid = false;
            _loadByCategory = false;
            _checkByGUID = false;
            _checkByCategory = false;
        }
        public void SetDownloadService(IDownloadService downloadservice)
        {
            _downloadservice = downloadservice;
        }
        public void SpawnResult(GameObject obj)
        {
            _gameObjToSpawn = obj;
            _instantiate = true;
        }
        
}
