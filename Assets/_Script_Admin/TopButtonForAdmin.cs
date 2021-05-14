using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopButtonForAdmin : MonoBehaviour
{
    [SerializeField]
    private PanelSwitchControllerForAdmin panelSwitchControllerForAdmin;

    public void OnTopButtonClicked_Transfer()
    {
        panelSwitchControllerForAdmin.OnTopButtonPressed(transform.GetComponent<Button>());
    }
}
