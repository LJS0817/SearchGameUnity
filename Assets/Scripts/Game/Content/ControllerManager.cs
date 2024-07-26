using Extended;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ControllerManager : MonoBehaviour
{
    private ViewController[] _controllers;
    private ViewController _eventController;

    private Extend.dEvent _minEvent;
    private Extend.dEvent _closeEvent;


    // Start is called before the first frame update
    void Start()
    {
        _eventController = null;

        _controllers = new ViewController[4];
        for (int i = 0; i < 4; i++)
        {
            _controllers[i] = (i == 0) ? transform.GetChild(0).GetComponent<ViewController>() :
                transform.GetChild(1).GetChild(i - 1).GetComponent<ViewController>();
            _controllers[i].init(transform.parent.name);

            int idx = i;
            _controllers[i].AddEvent(() => {
                _eventController = _controllers[idx];
                if (idx == 1) _closeEvent();
                else if (idx == 3) _minEvent();
            });
            if (i == 0) continue;
            _controllers[i].TargetColor = (i == 1) ? Extend.closeColor : Extend.hoverColor;
        }
    }

    private void Update()
    { 

    }

    public void CurrentEventUpdate(RectTransform rect)
    {
        if(_eventController != null && _eventController.isActivated)
        {
            _eventController.ViewEvent(rect);
        }
    }

    /// <summary>
    /// 0 : Move
    /// <para>1, 3 : Close</para>
    /// <para>2 : Max</para>
    /// </summary>
    /// <param name="n"></param>
    public void ActivateController(int n)
    {
        _controllers[n].Activate();
    }

    public void ResetController()
    {
        _eventController = null;
    }

    public void SetEvent(Extend.dEvent m, Extend.dEvent c)
    {
        _minEvent = m;
        _closeEvent = c;
    }
}
