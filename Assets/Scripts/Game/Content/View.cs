using Extended;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class View : MonoBehaviour
{
    private RectTransform _rect;
    private ControllerManager _controller;
    private App _app;
    private Animator _ani;

    private Vector2 _curPosition;
    private Vector2 _curSize;
    private Vector2 _iconPos;
    private bool _animateOpen;

    private bool _enable;

    private void Start()
    {
        _enable = false;

        _rect = GetComponent<RectTransform>();
        _ani = GetComponent<Animator>();

        _curPosition = Vector2.zero;
        _curSize = Extend.DEFAULT_SIZE;
        _animateOpen = false;
    }

    private void Update()
    {
        _controller.CurrentEventUpdate(_rect);
        OpenView();
    }

    private void OpenView()
    {
        if(_animateOpen)
        {
            _rect.position = Vector2.Lerp(_rect.position, _curPosition, 35f * Time.deltaTime);
            _rect.sizeDelta = Vector2.Lerp(_rect.sizeDelta, _curSize, 35f * Time.deltaTime);
            if (Mathf.Abs(_curPosition.magnitude - _rect.position.magnitude) +
                Mathf.Abs(_curSize.magnitude - _rect.sizeDelta.magnitude) < 1f)
            {
                _rect.position = _curPosition;
                _rect.sizeDelta = _curSize;
                _animateOpen = false;
            }
        }
    }

    private void SetCurrentState()
    {
        _curPosition = _rect.position;
        _curSize = _rect.sizeDelta;
    }

    public void Connect(App a, Vector2 pos)
    {
        _app = a;
        _iconPos = pos;
    }

    public void ChangeState(bool isIcon=false)
    {
        if (_animateOpen) return;
        _ani.SetTrigger("ChangeState");
        if (_enable)
        {
            if(isIcon) _controller.ActivateController(3);
            if (!isIcon)
            {
                if (!_animateOpen) SetCurrentState();
                _enable = false; 
            }
        } 
        else 
        {
            _rect.position = _iconPos;
            _animateOpen = true;
            _controller.ResetController();
            _enable = true;
        }
    }

    public void SetCloseEventListener(Extend.dEvent e)
    {
        _controller = transform.GetChild(0).GetComponent<ControllerManager>();
        _controller.SetEvent(() => { ChangeState(); }, e);
    }
}
