using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Extended;


public class ViewController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Color TargetColor;
    protected Color _sourceColor;
    protected Color _tempColor;

    [HideInInspector]
    public bool isActivated;
    protected bool _needChange;
    protected Image _image;

    [HideInInspector]
    public Extend.dEvent ActiveEvent;
    [HideInInspector]
    public Extend.dEvent DisableEvent;

    void Start()
    {
        init();
    }

    void Update()
    {
        if(_needChange)
        {
            _image.color = Color.Lerp(_image.color, _tempColor, 10f * Time.deltaTime);
            if(Mathf.Abs((_tempColor.r + _tempColor.g + _tempColor.b) - (_image.color.r + _image.color.g + _image.color.b)) < 0.005f)
            {
                _image.color = _tempColor;
                _needChange = false;
            }
        }
    }

    protected virtual void init() 
    {
        _image = GetComponent<Image>();
        TargetColor = _sourceColor = _image.color;
        _needChange = false;
        isActivated = false;
    }

    public void AddEvent(Extend.dEvent e)
    {
        ActiveEvent += e;
    }

    public virtual void OnPointerEnter(PointerEventData data)
    {
        _needChange = true;
        _tempColor = TargetColor;
    }

    public virtual void OnPointerExit(PointerEventData data)
    {
        _needChange = true;
        _tempColor = _sourceColor;
    }

    public virtual void OnPointerDown(PointerEventData data) { }

    public virtual void OnPointerUp(PointerEventData data)
    {
        isActivated = true;
    }

    public virtual void ViewEvent(RectTransform rect) { }

}
