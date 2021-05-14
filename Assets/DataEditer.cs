using NCMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEditer : MonoBehaviour
{
    public void RemoveData(string objectID)
    {
        Debug.Log("deleted");
        NCMBObject objDelete = new NCMBObject("Orders");
        objDelete.ObjectId = objectID;
        objDelete.DeleteAsync((NCMBException e) =>
        {
            this.gameObject.GetComponent<DataDisplayer>().OnMyListButtonPressed();
        });
    }
}
