using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitchControllerForAdmin : MonoBehaviour
{
    //Origin Panels
    [SerializeField]
    private GameObject BigPanel;
    [SerializeField]
    private GameObject LoginPanel;

    //Main Panels
    [SerializeField]
    private GameObject SearchPanel;
    [SerializeField]
    private GameObject MyOrdersPanel;
    [SerializeField]
    private GameObject CreateOrderPanel;
    [SerializeField]
    private GameObject MyPagePanel;

    //Sub Panels
    [SerializeField, Tooltip("SearchPanelの詳細Panelをアタッチ")]
    private GameObject DetailPanel;

    //Top Buttons
    [SerializeField]
    private GameObject SearchButton_NoLoad;
    [SerializeField]
    private GameObject SearchButton;
    [SerializeField]
    private GameObject MyOrderButton;
    [SerializeField]
    private GameObject CreateOrderButton;
    [SerializeField]
    private GameObject MyPageButton;

    #region BigPanel_TopButton_Process_Section
    private void Start()
    {
        SearchButton_NoLoad.SetActive(true); SearchButton.SetActive(false);
    }

    public void OnTopButtonPressed(Button button)
    {
        string type = button.gameObject.name;
        switch (type)
        {
            case "出品一覧 Button":
            case "出品一覧_NoLoad Button":
                OnPressedSearchPanelButton();
                break;
            case "マイ出品リスト Button":
                OnPressedMyOrdersPanelButton();
                break;
            case "注文作成 Button":
                OnPressedCreateOrderPanelButton();
                break;
            case "マイページ Button":
                OnPressedMypagePanelButton();
                break;
        }
    }

    [ContextMenu("SearchPanel")]
    private void OnPressedSearchPanelButton()//閉じるボタン
    {
        //メインパネル処理
        SearchPanel.SetActive(true);
        MyOrdersPanel.SetActive(false);
        CreateOrderPanel.SetActive(false);
        MyPagePanel.SetActive(false);

        //トップボタン処理
        SearchButton_NoLoad.SetActive(true); SearchButton.SetActive(false);
        SearchButton_NoLoad.GetComponent<Button>().interactable = false; SearchButton.GetComponent<Button>().interactable = true;
        MyOrderButton.GetComponent<Button>().interactable = true;
        CreateOrderButton.GetComponent<Button>().interactable = true;
        MyPageButton.GetComponent<Button>().interactable = true;
    }
    [ContextMenu("MyOrdersPanel")]
    private void OnPressedMyOrdersPanelButton()
    {
        //メインパネル処理
        SearchPanel.SetActive(false);
        MyOrdersPanel.SetActive(true);
        CreateOrderPanel.SetActive(false);
        MyPagePanel.SetActive(false);
        //サブパネル処理
        DetailPanel.SetActive(false);

        //トップボタン処理
        SearchButton_NoLoad.SetActive(false); SearchButton.SetActive(true); SearchButton.GetComponent<Button>().interactable = true;
        MyOrderButton.GetComponent<Button>().interactable = false;
        CreateOrderButton.GetComponent<Button>().interactable = true;
        MyPageButton.GetComponent<Button>().interactable = true;
    }
    [ContextMenu("CreateOrderPanel")]
    private void OnPressedCreateOrderPanelButton()//+ボタン
    {
        //メインパネル処理
        SearchPanel.SetActive(false);
        MyOrdersPanel.SetActive(false);
        CreateOrderPanel.SetActive(true);
        MyPagePanel.SetActive(false);
        //サブパネル処理
        DetailPanel.SetActive(false);

        //トップボタン処理
        SearchButton_NoLoad.GetComponent<Button>().interactable = true;
        MyOrderButton.GetComponent<Button>().interactable = true;
        CreateOrderButton.GetComponent<Button>().interactable = false;
        MyPageButton.GetComponent<Button>().interactable = true;
    }
    [ContextMenu("MyPagePanel")]
    private void OnPressedMypagePanelButton()//設定ボタン
    {
        //メインパネル処理
        SearchPanel.SetActive(false);
        MyOrdersPanel.SetActive(false);
        CreateOrderPanel.SetActive(false);
        MyPagePanel.SetActive(true);
        //サブパネル処理
        DetailPanel.SetActive(false);

        //トップボタン処理
        SearchButton_NoLoad.GetComponent<Button>().interactable = true;
        MyOrderButton.GetComponent<Button>().interactable = true;
        CreateOrderButton.GetComponent<Button>().interactable = true;
        MyPageButton.GetComponent<Button>().interactable = false;
    }
    #endregion


    #region OriginPanel_Process_Section
    [ContextMenu("Display_LoginSucceeded_Window")]
    public void OnLoginSucceeded()
    {
        BigPanel.SetActive(true);
        LoginPanel.SetActive(false);
    }
    [ContextMenu("Display_OnLogout_Window")]
    public void OnLogout()
    {
        BigPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }
    #endregion

}
