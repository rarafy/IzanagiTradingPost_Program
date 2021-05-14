using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FloatButtonController : MonoBehaviour
{
    public void OnPressedExitButton()
    {
        Quit();
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Escape)) Quit();
    }

    private void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.runInBackground = false;
        Application.Quit();
#else
        Application.Quit();
#endif

    }
}
