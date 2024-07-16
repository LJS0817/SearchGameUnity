using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Extended;


public class Maximum : ViewController
{
    private Vector2 _fulLScreen;
    private Vector2 _currentSize;
    private Vector2 _targetSize;
    private Vector2 _currentPos;

    bool _isFull;

    protected override void init()
    {
        base.init();
        _isFull = false;
        _currentSize = _currentPos = Vector2.zero;
        _fulLScreen = new Vector2(Screen.width, Screen.height);
        _targetSize = Extend.DEFAULT_SIZE;
    }

    public override void ViewEvent(RectTransform rect)
    {
        if (_isFull && _currentSize == Vector2.zero)
        {
            _currentSize = rect.sizeDelta;
            _currentPos = rect.position;
            rect.position = Vector3.zero;
        } 
        if(!_isFull && _currentPos != Vector2.zero)
        {
            rect.position = _currentPos;
            _currentPos = Vector2.zero;
        }
        rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, _targetSize, 9f * Time.deltaTime);
        if(Mathf.Abs(rect.sizeDelta.magnitude - _targetSize.magnitude) < 10f)
        {
            isActivated = false;
            rect.sizeDelta = _targetSize;
        }
    }

    public override void OnPointerUp(PointerEventData data)
    {
        base.OnPointerUp(data);
        _isFull = !_isFull;
        if (_isFull) _currentSize = Vector2.zero;
        _targetSize = _isFull ? _fulLScreen : _currentSize;
    }
}