using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopButton : MonoBehaviour
{
    [SerializeField]
    private PanelSwitchController panelSwitchController;

    public void OnTopButtonClicked_Transfer()
    {
        panelSwitchController.OnTopButtonPressed(transform.GetComponent<Button>());
    }
}
