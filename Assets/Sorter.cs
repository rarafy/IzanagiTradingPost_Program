using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorter : MonoBehaviour
{
    [SerializeField]
    private DataDisplayer dataDisplayer;

    public void OnLeftButtonClicked_Transfer()
    {
        dataDisplayer.OnLeftButtonClicked(this.transform.GetChild(0).GetComponent<Text>().text);
    }

}
