using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Reflection;

using Infrastructure.Services.DownloadService;
// using static System.Type;

public class TestDownloadService : MonoBehaviour
{
    public bool isLoaded = true;
    public bool isRunning = false;
    public bool isChecked = false;
    int i = 0;
    private Coroutine cor;
    // private IDownloadService down = new DownloadService();

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoaded)
        {
            Debug.Log("Start");
            StartCoroutine(test());
        }
        i+=1;

    }
    private IEnumerator CheckDownload()
    {
        // long size = 0;
        var downloadSizeHandle = Addressables.GetDownloadSizeAsync("mechanics_1.16");
        yield return downloadSizeHandle;

        Debug.Log(downloadSizeHandle.Result);
        Debug.Log("check is finished");
        
        }
    

    private IEnumerator downloadByLabel(string label)
    {
        AsyncOperationHandle<GameObject> opHandle = Addressables.LoadAssetAsync<GameObject>(label);
        if (!opHandle.IsDone)
        {
            Debug.Log("Download progress = "+opHandle.PercentComplete*100+"%");
            yield return opHandle;
        }
        else
        {
            isLoaded = true;
            Addressables.Release(opHandle);
            Debug.Log("download is finished");
        }
    }

    public AsyncOperationHandle<GameObject> NewDownload()
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>("mechanics_1.2");
        return handle;
    }
    private IEnumerator IEDownloadProgress(AsyncOperationHandle<GameObject> _handle)
    {
        var isDone = false;
        _handle.Completed += (operation) =>
        {
            isDone = true;
            isLoaded = true;
            Debug.Log("Finished");
            // percent = downloadPercentSlider.maxValue;
        };

        while (!isDone)
        {
            // percent = _handle.PercentComplete;
            Debug.Log(_handle.PercentComplete);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitUntil(() => isDone);
    }
    private IEnumerator test()
    {
        isLoaded = false;
        Debug.Log("first");
        Debug.Log(i);
        yield return new WaitUntil(() => i>10);
        Debug.Log("second");
        // int y = 10;
        // while (y>0)
        // {
        //     y-=1;
        //     Debug.Log("third");
        //     // yield return null;
        // }
        
    }
}
