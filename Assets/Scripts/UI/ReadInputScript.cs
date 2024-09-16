using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Infrastructure.Services.FlutterMessageService;

public class ReadInputScript : MonoBehaviour
{
    [SerializeField]
    private string _guid;
    [SerializeField]
    private string _category;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI _progressPercent;
    [SerializeField]
    private TextMeshProUGUI _resultText;
    
    
    private IFlutterMessageService _flutter;
    // Start is called before the first frame update
    void Start()
    {
        _category = "mechanics";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReadGUIDInput(string guid)
    {
        _guid = guid;
        Debug.Log(_guid);
    }

    public void ReadCategoryInput(int category)
    {
        if (category==0)
        {
            _category = "mechanics";
        }
        if (category==1)
        {
            _category = "molecular";

        }
        if (category==2)
        {
            _category = "electrisity";

        }
        if (category==3)
        {
            _category = "optics";

        }
         if (category==4)
        {
            _category = "atomic";

        }
    }

    public void Register(IFlutterMessageService flutterMessageService)
    {
        _flutter = flutterMessageService;
    }
    public void LaunchDownloadByGUID()
    {
        // Debug.Log("0");
        _flutter.RecieveMessage(string.Format("downloadbyguid{0}",_guid));
    }
    public void LaunchDownloadByCategory()
    {
        // Debug.Log("0");
        _flutter.RecieveMessage(string.Format("downloadbycategory{0}",_category));
    }
    public void CheckInstallation()
    {
        _flutter.RecieveMessage(string.Format("checkbyguid{0}",_guid));
    }
    public void CheckCategory()
    {
        // Debug.Log("0");
        _flutter.RecieveMessage(string.Format("checkbycategory{0}",_category));
    }
    public void RecieveMessage(string message)
    {
        if (message.StartsWith("progressbar"))
            {
                // Debug.Log("1");
                // string progress = ;
                float progress = float.Parse(message.Replace("progressbar", ""));
                UpdateSlider(progress);
                _progressPercent.text = string.Format("Прогресс {0}%", progress*100);
                Debug.Log("Прогресс загрузки = "+progress*100+"%");
            }
        if (message.StartsWith("printresult"))
            {
                _resultText.text = message.Replace("printresult", "");
            }
    }
    void UpdateSlider(float value) 
    {
		slider.value = value;
	}
    public void ClearCashe()
    {
        _flutter.RecieveMessage("clearcashe");
    }
}
