using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extended;

public class GameManager : MonoBehaviour
{
    public GameObject ViewPool;

    private void Awake()
    {
        Transform viewParent = GameObject.Find("/Canvas").transform;
        Transform iconParent = GameObject.Find("/Canvas/AppList").transform;
        for (int i = 0; i < Extend.ViewList.Length; i++)
        {
            viewParent.GetChild(i).name = iconParent.GetChild(i).name = Extend.ViewList[i];

            GameObject viewScript = new GameObject(Extend.ViewList[i]);
            viewScript.AddComponent<App>().ConnectData(viewParent.GetChild(i), iconParent.GetChild(i));
            viewScript.transform.SetParent(ViewPool.transform);
        }
    }
}
