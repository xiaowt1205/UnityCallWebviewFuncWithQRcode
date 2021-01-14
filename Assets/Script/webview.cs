using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jing.ULiteWebView;

public class webview : MonoBehaviour
{
    public string TargetURL;
    void Start()
    {   
        openWeb();
    }

    void Update()
    {

    }

    public void openWeb(){
        string localUrl = TargetURL;
        // ULiteWebView.Ins.RegistJsInterfaceAction("ShowMsg", ShowMsg);
        ULiteWebView.Ins.Show(80, 10, 10, 10);
        ULiteWebView.Ins.LoadLocal(localUrl);
    }

    public void CallJS(string _FuncName,string _Content)
    {
        ULiteWebView.Ins.CallJS(_FuncName, _Content);
    }
}
