using Extended;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class View : MonoBehaviour
{
    protected RectTransform _rect;
    public ControllerManager _controller;
    protected App _app;
    protected Animator _ani;
   
    private Vector2 _curPosition;
    private Vector2 _curSize;
    private Vector2 _iconPos;
    private bool _animateOpen;

    protected bool _enable;

    protected virtual void init() {
        _enable = false;

        _rect = GetComponent<RectTransform>();
        _ani = GetComponent<Animator>();

        _curPosition = Vector2.zero;
        _curSize = Extend.DEFAULT_SIZE;
        _animateOpen = false;
        _controller = transform.GetChild(1).GetComponent<ControllerManager>();
    }
    protected virtual void update() { }

    private void Start()
    {

    }

    private void Update()
    {
        _controller.CurrentEventUpdate(_rect);
        openView();
        update();
    }

    private void openView()
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

    private void setCurrentState()
    {
        _curPosition = _rect.position;
        _curSize = _rect.sizeDelta;
    }

    public void Connect(App a, Vector2 pos)
    {
        init();
        _app = a;
        _iconPos = pos;
        transform.position = pos;
        _rect.sizeDelta = Vector2.zero;
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
                if (!_animateOpen) setCurrentState();
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
        if(_controller == null) _controller = transform.GetChild(1).GetComponent<ControllerManager>();
        _controller.SetEvent(() => { ChangeState(); }, e);
    }
}
