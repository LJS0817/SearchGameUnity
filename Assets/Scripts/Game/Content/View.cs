using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    //private string _name;
    RectTransform _rect;
    ControllerManager _controller;
    App _app;
    //Animator _ani;

    //Vector3 CurSize;
    //Vector3 CurPosition;

    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        _controller = transform.GetChild(0).GetComponent<ControllerManager>();
    }
     
    private void Update()
    {
        _controller.CurrentEventUpdate(_rect);
    }

    public void Connect(App a)
    {
        _app = a;
    }
}
