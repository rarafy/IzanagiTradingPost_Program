using NCMB;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UpdateChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject UpdateWindow;

    [SerializeField]
    private int CurrentVersion;

    private void Start()
    {
        CurrentVersion = int.Parse(Application.version);
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("version");
        query.Limit = 1;
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (CurrentVersion <= System.Convert.ToInt32(objList[0]["LatestVersion"]) - 1)
            {
                UpdateWindow.SetActive(true);
            }
        });
    }

    public void OnOKButtonClicked()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        Application.OpenURL("https://github.com/rarafy/IzanagiTradingPost");
#elif UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.risQuartz.IzanagiTradingPost");
#endif

    }
}
