using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitPlayMode : MonoBehaviour
{
    public void StopPlayMode()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;  // Sulkee Play Mode -tilan
#else
    Application.Quit();
#endif
    }
}
