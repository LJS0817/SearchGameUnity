using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Extended;


public class ViewController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Color targetColor;
    protected Color sourceColor;
    protected Color tempColor;

    [HideInInspector]
    public bool isActivated;
    protected bool needChange;
    protected Image image;

    [HideInInspector]
    public Extend.dEvent ActiveEvent;
    [HideInInspector]
    public Extend.dEvent DisableEvent;

    void Start()
    {
        image = GetComponent<Image>();
        targetColor = sourceColor = image.color;
        needChange = false;
        isActivated = false;
    }

    void Update()
    {
        if(needChange)
        {
            image.color = Color.Lerp(image.color, tempColor, 10f * Time.deltaTime);
            if(Mathf.Abs((tempColor.r + tempColor.g + tempColor.b) - (image.color.r + image.color.g + image.color.b)) < 0.005f)
            {
                image.color = tempColor;
                needChange = false;
            }
        }
    }

    public bool isClicked()
    {
        return tempColor == targetColor && isActivated;
    }

    public void AddEvent(Extend.dEvent e)
    {
        ActiveEvent += e;
    }

    public virtual void OnPointerEnter(PointerEventData data)
    {
        needChange = true;
        tempColor = targetColor;
    }

    public virtual void OnPointerExit(PointerEventData data)
    {
        needChange = true;
        isActivated = false;
        tempColor = sourceColor;
    }

    public virtual void OnPointerDown(PointerEventData data)
    {
        isActivated = true;
    }

    public virtual void OnPointerUp(PointerEventData data)
    {
        isActivated = false;
    }

    public virtual void ViewEvent(RectTransform rect) { }

}
