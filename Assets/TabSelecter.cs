using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabSelecter : MonoBehaviour
{

    //　自身のボタンやトグル
    private Selectable mySelectable;

    void Start()
    {
        mySelectable = GetComponent<Selectable>();
    }

    public void SetSelectable()
    {
        //　左のシフトキー、右のシフトキーを押しながらTabキーを押した時は反対向きにフォーカスを移動する
        if (Input.GetKeyDown(KeyCode.Tab) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            EventSystem.current.SetSelectedGameObject(mySelectable.navigation.selectOnLeft.gameObject);
            //　タブキーを押されたらSelectOnRightに選択された物をフォーカスする
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            EventSystem.current.SetSelectedGameObject(mySelectable.navigation.selectOnRight.gameObject);
        }
    }
}