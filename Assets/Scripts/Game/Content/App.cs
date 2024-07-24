using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Extended;

public class App : MonoBehaviour
{
    AppIcon _icon;
    View _content;
    bool _enabled;
    Extend.dEvent _iconListener;
    Extend.dEvent _contentListener;

    public void ConnectData(Transform v, Transform i)
    {
        _icon = i.GetComponent<AppIcon>();
        _icon.Connect(this);
        _iconListener = _icon.EventListener;

        _content = v.GetComponent<View>();
        _content.Connect(this);
        _contentListener = _content.EventListener;

        _enabled = false;
    }

    public bool GetEnable() { return _enabled; }
    public void SetEnable(bool b) { if (_enabled != b) _enabled = b; }

    public void SetReceiveEvent(Extend.dEvent e)
    {
        _ReviceEvenets = e;
    }

    public void SendEvent(bool isFromIcon, string data)
    {
        if(isFromIcon)
        {

        } 
        else
        {

        }
    }

    public void RecieveData(bool isFromIcon)
    {
        if(isFromIcon)
        {

        } 
        else
        {

        }
    }
}
