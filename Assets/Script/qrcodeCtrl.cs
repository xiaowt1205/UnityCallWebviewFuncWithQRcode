using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
using Jing.ULiteWebView;

public class qrcodeCtrl : MonoBehaviour
{

    public QRCodeDecodeController e_qrController;

    private Camera mainCam;

    public Camera qrCam;

    public GameObject scanLineObj;

    public GameObject openBtn;

    public GameObject closeBtn;

    public bool camActive;

    void Awake()
    {
        mainCam = Camera.main;

#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
#endif
    }

    void Start()
    {
        qrCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        openBtn.SetActive(true);
        closeBtn.SetActive(false);

        if (this.e_qrController != null)
        {
            this.e_qrController.onQRScanFinished += new QRCodeDecodeController.QRScanFinished(this.qrScanFinished);
        }
    }

    void qrScanFinished(string dataText)
    {
        this.gameObject.GetComponent<webview>().CallJS("openModal", dataText);
        e_qrController.StopWork();
        scanLineObj.SetActive(false);

        qrCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
    }

    public void OpenQRCodeScanner()
    {
        qrCam.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        openBtn.SetActive(false);
        closeBtn.SetActive(true);

        if (this.e_qrController != null)
        {
            this.e_qrController.StartWork();
        }
        
        ULiteWebView.Ins.Close();
    }

    public void CloseQRCodeScanner()
    {
        qrCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        openBtn.SetActive(true);
        closeBtn.SetActive(false);
        e_qrController.StopWork();
        scanLineObj.SetActive(false);

        
    }
}
