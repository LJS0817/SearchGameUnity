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
        for(int i = 0; i < 4; i++)
        {
            _controllers[i] = (i == 0) ? transform.GetChild(0).GetComponent<ViewController>() :
                transform.GetChild(1).GetChild(i - 1).GetComponent<ViewController>();
            _controllers[i].AddEvent(() => {
                if (_eventControllers != null) _eventControllers.DisableEvent();
                _eventControllers = _controllers[i];
            });
            if (i == 0) continue;
            _controllers[i].TargetColor = (i == 1) ? Extended.Extend.closeColor : Extended.Extend.hoverColor;
        }
    }

    private void Update()
    {
        if(_eventControllers == null || !_eventControllers.isActivated)
        {
            for(int i = 0; i < 4; i++)
            {
                if (_controllers[i].isActivated) _eventControllers = _controllers[i];
            }
        }
    }

    public void CurrentEventUpdate(RectTransform rect)
    {
        if(_eventControllers != null)
        {
            _eventControllers.ViewEvent(rect);
        }
    }

    ///// <summary>
    ///// <para>0 == 이동</para>
    ///// <para>1 == 닫기</para>
    ///// <para>2 == 최대화</para>
    ///// 3 == 최소화
    ///// </summary>
    ///// <param name="type"></param>
    //public void setEvent(int type)
    //{
    //    eventControllers[type] = controllers[type].TriggerEvent();
    //}

    //public bool isActivatedEvent(int type)
    //{
    //    return eventControllers[type] != null;
    //}

    //public void getCurrentEvent(RectTransform rect)
    //{
    //    for (int i = 0; i < controllers.Length; i++)
    //    {
    //        if (eventControllers[i] != null) eventControllers[i].ViewEvent(rect);
    //    }
    //}
}
