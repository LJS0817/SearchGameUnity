using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ControllerManager : MonoBehaviour
{
    ViewController[] controllers;
    ViewController[] eventControllers;


    // Start is called before the first frame update
    void Start()
    {
        eventControllers = new ViewController[4];
        for(int i = 0; i < eventControllers.Length; i++)
        {
            eventControllers[i] = null;
        }

        controllers = new ViewController[4];
        controllers[0] = transform.GetChild(0).GetComponent<ViewController>();
        for(int i = 0; i < controllers.Length - 1; i++)
        {
            controllers[1 + i] = transform.GetChild(1).GetChild(i).GetComponent<ViewController>();
            controllers[1 + i].targetColor = ((i > 0) ? GameManager.hoverColor : GameManager.closeColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentEvent();
    }

    void currentEvent()
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            if (controllers[i].isActivated && eventControllers[i] == null)
            {
                eventControllers[i] = controllers[i];
            } else if (eventControllers[i] != null) {
                eventControllers[i] = null; 
            }
        }
    }

    /// <summary>
    /// <para>0 == 이동</para>
    /// <para>1 == 닫기</para>
    /// <para>2 == 최대화</para>
    /// 3 == 최소화
    /// </summary>
    /// <param name="type"></param>
    public void setEvent(int type)
    {
        eventControllers[type] = controllers[type].TriggerEvent();
    }

    public bool isActivatedEvent(int type)
    {
        return eventControllers[type] != null;
    }

    public void getCurrentEvent(RectTransform rect)
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            if (eventControllers[i] != null) eventControllers[i].ViewEvent(rect);
        }
    }
}
