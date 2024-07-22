using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ControllerManager : MonoBehaviour
{
    ViewController[] _controllers;
    ViewController _eventControllers;

    // Start is called before the first frame update
    void Start()
    {
        _eventControllers = null;

        _controllers = new ViewController[4];
        for (int i = 0; i < 4; i++)
        {
            _controllers[i] = (i == 0) ? transform.GetChild(0).GetComponent<ViewController>() :
                transform.GetChild(1).GetChild(i - 1).GetComponent<ViewController>();
            _controllers[i].init(transform.parent.name);

            int idx = i;
            _controllers[i].AddEvent(() => {
                if (_eventControllers != null) _eventControllers.DisableEvent();
                _eventControllers = _controllers[idx];
            });
            if (i == 0) continue;
            _controllers[i].TargetColor = (i == 1) ? Extended.Extend.closeColor : Extended.Extend.hoverColor;
        }
    }

    private void Update()
    { 

    }

    public void CurrentEventUpdate(RectTransform rect)
    {
        if(_eventControllers != null)
        {
            _eventControllers.ViewEvent(rect);
        }
    }
}
