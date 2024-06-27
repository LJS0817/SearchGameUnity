using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


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

    public virtual ViewController TriggerEvent()
    {
        isActivated = true;
        return this;
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
