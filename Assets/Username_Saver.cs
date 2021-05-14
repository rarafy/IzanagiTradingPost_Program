using UnityEngine;
using UnityEngine.UI;

public class Username_Saver : MonoBehaviour
{
    #region Common_Section
    private void Start()
    {
        UserNameAsync();
        UserURLAsync();
        PasswordAsync();
    }
    #endregion

    //以下３つは、内容がほぼ同じ
    #region Username_Saver_Section
    [SerializeField, Tooltip("出品者(ユーザ名)/ID of ログインページ")]
    private InputField usernameInputField_L;
    [SerializeField, Tooltip("出品者(ユーザ名)/ID of マイページ")]
    private InputField usernameInputField_M;

    private const string userNamePrefKey = "UserName";

    public void SetUserName(string value)
    {
        PlayerPrefs.SetString(userNamePrefKey, value);
        UserNameAsync();
    }

    private void UserNameAsync()
    {
        if (PlayerPrefs.HasKey(userNamePrefKey))
        {
            usernameInputField_L.text = PlayerPrefs.GetString(userNamePrefKey);
            usernameInputField_M.text = PlayerPrefs.GetString(userNamePrefKey);
        }
    }

    public void ResetUserName()
    {
        PlayerPrefs.SetString(userNamePrefKey, "");
        UserNameAsync();
    }

    #endregion


    #region UserURL_Saver_Section
    [SerializeField, Tooltip("出品者/URL of ログインページ")]
    private InputField userURLInputField_L;
    [SerializeField, Tooltip("出品者/URL of マイページ")]
    private InputField userURLInputField_M;

    private const string userURLPrefKey = "UserURL";

    public void SetUserURL(string value)
    {
        PlayerPrefs.SetString(userURLPrefKey, value);
        UserURLAsync();
    }

    private void UserURLAsync()
    {
        if (PlayerPrefs.HasKey(userURLPrefKey))
        {
            userURLInputField_M.text = PlayerPrefs.GetString(userURLPrefKey);
            userURLInputField_L.text = PlayerPrefs.GetString(userURLPrefKey);
        }
    }

    public void ResetUserURL()
    {
        PlayerPrefs.SetString(userURLPrefKey, "");
        UserURLAsync();
    }
    #endregion


    #region Password_Saver_Section
    [SerializeField, Tooltip("Password of ログインページ")]
    private InputField password_L;

    private const string passwordPrefKey = "Password";

    public void SetPassword(string value)
    {
        PlayerPrefs.SetString(passwordPrefKey, value);
        PasswordAsync();
    }

    private void PasswordAsync()
    {
        password_L.text = PlayerPrefs.GetString(passwordPrefKey);
    }

    public void ResetPassword()
    {
        PlayerPrefs.SetString(passwordPrefKey, "");
        PasswordAsync();
    }
    #endregion
}
