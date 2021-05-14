using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButton : MonoBehaviour
{
    private SearchBoxController searchBoxController;
    [SerializeField]
    private string systemControllerName = "System Controller Empty+Script";

    private void Start()
    {
        searchBoxController = GameObject.Find(systemControllerName).GetComponent<SearchBoxController>();
    }

    public void OnLeftButtonSelected_Transfer()
    {
        searchBoxController.OnLeftButtonSelected(this.GetComponent<Button>());
    }
}
