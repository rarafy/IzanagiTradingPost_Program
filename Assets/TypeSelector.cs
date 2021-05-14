using Create_Order;
using Order_Formatter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeSelector : MonoBehaviour
{

    [SerializeField]
    private string createOrder = "注文作成 Panel + Script";

    public void OnButtonTouched()
    {
        GameObject.Find(createOrder).GetComponent<CreateOrder>().SetTypeDropdown(this.gameObject);
    }
}
