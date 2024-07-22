using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class App : MonoBehaviour
{
    AppIcon _icon;
    View _content;

    public void ConnectData(Transform v, Transform i)
    {
        _icon = i.GetComponent<AppIcon>();
        _icon.Connect(this);

        _content = v.GetComponent<View>();
        _content.Connect(this);
    }
}
