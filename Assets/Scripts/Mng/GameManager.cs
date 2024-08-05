using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ViewPool;
    readonly string[] _viewList = new string[2] { "Web", "Map" };

    private void Awake()
    { 
        Transform viewParent = GameObject.Find("/Canvas").transform;
        Transform iconParent = GameObject.Find("/Canvas/AppList").transform;
        for (int i = 0; i < _viewList.Length; i++)
        {
            viewParent.GetChild(i).name = iconParent.GetChild(i).name = _viewList[i];

            GameObject viewScript = new GameObject(_viewList[i]);
            viewScript.AddComponent<App>().ConnectData(viewParent.GetChild(i), iconParent.GetChild(i));
            viewScript.transform.SetParent(ViewPool.transform);
        }
    }
}
