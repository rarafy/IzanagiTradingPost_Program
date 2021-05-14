using UnityEngine;

public class OrderID : MonoBehaviour
{
    public string objectID = "";
    public int orderID = 0;

    [SerializeField]
    private string systemController = "System Controller Empty+Script";

    public void OnDetailButtonPressed_Tranfer()
    {
        GameObject.Find(systemController)
            .GetComponent<DataDisplayer>().OnDetailButtonPressed(orderID, objectID, 0);
    }
    public void OnDetailButton_In_MyList_Pressed_Tranfer()
    {
        GameObject.Find(systemController)
            .GetComponent<DataDisplayer>().OnDetailButtonPressed(orderID, objectID, 1);
    }

    public void OnLobiButtonPressed_Transfer()
    {
        GameObject.Find(systemController)
            .GetComponent<DataDisplayer>().OnLobiButtonPressed(orderID);
    }

    public void OnDeleteButtonPressed_Transfer()
    {
        GameObject.Find(systemController).GetComponent<DataEditer>().RemoveData(objectID);
    }
}
