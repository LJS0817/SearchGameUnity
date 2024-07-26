using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Extended;

public class App : MonoBehaviour
{
    View _content;
    AppIcon _icon;
    
    bool _enabled;

    public void ConnectData(Transform v, Transform i)
    {
        _icon = i.GetComponent<AppIcon>();
        _icon.Connect(this);
     
        _content = v.GetComponent<View>();
        _content.Connect(this, _icon.transform.position);

        _content.SetCloseEventListener(() => {
            SetEnable(false);
            _icon.Disable();
            _content.ChangeState();
        });

        _icon.SetOnClickListener(() => {
            SetEnable(true);
            _content.ChangeState(true);
        });

        _enabled = false;
    }

    public bool GetEnable() { return _enabled; }
    public void SetEnable(bool b) { if (_enabled != b) _enabled = b; }
}
