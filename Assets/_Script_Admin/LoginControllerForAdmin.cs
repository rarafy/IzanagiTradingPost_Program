using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LoginControllerForAdmin : MonoBehaviour
{
    private PanelSwitchControllerForAdmin panelSwitchControllerForAdmin;

    [SerializeField]
    private Text userID;

    [SerializeField]
    private Text userURL;

    [SerializeField]
    private Text password;

    [SerializeField, Tooltip("「パスワード認証 Empty」をアタッチ")]
    private GameObject PasswordAreaEmpty;

    [SerializeField, Tooltip("「Error Scroll View」をアタッチ")]
    private GameObject ErrorScrollView;

    //自動認証,0無効,1有効
    [SerializeField]
    private int autoAuthentication = 0;
    private const string autoAuthentication_Save = "AutoAuthentication";


    private void Start()
    {
        if (!panelSwitchControllerForAdmin)
        {
            panelSwitchControllerForAdmin = this.GetComponent<PanelSwitchControllerForAdmin>();
        }
        //自動認証するかどうかを取得,autoAuthenticationが１なら自動認証を行う。
        autoAuthentication = PlayerPrefs.GetInt(autoAuthentication_Save);
        if (autoAuthentication == 1) Authorization();
    }

    public void Authorization()
    {
        switch (Check())
        {
            case 0://認証成功(0)
                Login();
                break;
            case 2://パスワード必要(2)
                RequirePassword();
                break;
            default://認証失敗(1)
                Debug.Log("Failed");
                Error();
                break;
        }
    }

    private int Check()
    {
        if (userID.text == "rarafy" || userURL.text == "https://web.lobi.co/user/a876b38a3057f924d6aea2779f54c11b8f08c421")
        {//パスワードが必要なアカウント
            if (userID.text == "rarafy"
                && userURL.text == "https://web.lobi.co/user/a876b38a3057f924d6aea2779f54c11b8f08c421"
                && password.text == "6565") return 0; //認証成功
            else return 2; //パスワード必要
        }
        else if (userID.text != "" && userURL.text.StartsWith("https://web.lobi.co/user/") == true && userURL.text.Length == 65)
        {
            //パスワードが必要ないアカウント
            //１次条件クリア。ユーザー名が入力されていて、LobiのURLで、65文字。
            if (Regex.IsMatch(userURL.text.Substring(25, 1), @"^[0-9a-f]{1}$") == true)
            {
                return 0; //認証成功。26文字目が0-9,a-fに等しい
            }
            else return 1; //認証失敗。URLが不正
        }
        else return 1; //認証失敗
    }


    private void Login()
    {
        PlayerPrefs.SetInt(autoAuthentication_Save, 1);//次回から自動認証を有効化
        panelSwitchControllerForAdmin.OnLoginSucceeded();
    }

    private void Error()
    {
        ErrorScrollView.SetActive(true);
        userURL.transform.parent.GetComponent<InputField>().text = "";
        PasswordAreaEmpty.SetActive(false);
    }

    private void RequirePassword()
    {
        PasswordAreaEmpty.SetActive(true);
    }

    public void Logout()
    {
        PlayerPrefs.SetInt(autoAuthentication_Save, 0);//自動認証を無効化
        this.GetComponent<Username_Saver>().ResetPassword();//パスワードを初期化
        this.GetComponent<Username_Saver>().ResetUserName();//ユーザIDを初期化
        this.GetComponent<Username_Saver>().ResetUserURL();//ユーザURLを初期化
        panelSwitchControllerForAdmin.OnLogout();
    }
}
