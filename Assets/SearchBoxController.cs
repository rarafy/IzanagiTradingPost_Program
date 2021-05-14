using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBoxController : MonoBehaviour
{

    private void Start()
    {
        Initialization();
    }



    #region SearchBox_CrossButton_Section

    [SerializeField]
    InputField inputField;
    [SerializeField]
    Button crossButton;

    public void DisplayCrossButton()
    {
        if (inputField.text != "")//(１文字以上)
        {
            crossButton.gameObject.SetActive(true);
        }
        else if (inputField.text == "")//(０文字)
        {
            crossButton.gameObject.SetActive(false);
        }
    }

    public void OnCrossButtonPressed()
    {
        inputField.text = "";
    }

    #endregion


    #region LeftPanel_Section
    private Button previousButton;

    [SerializeField, Tooltip("最初にInteractive = falseにしておきたいオブジェクトを指定します。")]
    private GameObject initialLeftButtonName;

    public void OnLeftButtonSelected(Button button)
    {
        previousButton.interactable = true;
        button.interactable = false;
        previousButton = button;
    }

    private void Initialization()
    {
        previousButton = initialLeftButtonName.GetComponent<Button>();
        previousButton.interactable = false;
    }
    #endregion
}
