using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Searcher : MonoBehaviour
{
    [SerializeField]
    private DataDisplayer dataDisplayer;
    [SerializeField]
    private Text keywordBox_Text;


    public void OnSearchFunctionButton_Transfer()
    {
        dataDisplayer.OnSearchFunctionButtonClicked(keywordBox_Text.text);
    }
}
