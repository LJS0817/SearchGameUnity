using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppIcon : MonoBehaviour, IPointerClickHandler
{
    //Image stateIcon;
    //Image imageIcon;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData data)
    {

    }

    //public void OnPointerClick(PointerEventData data)
    //{
    //    view.SetEnable();
    //    if (!getEnable())
    //    {
    //        SetActive(true);
    //        Minimum min = GameObject.Find("/Canvas/" + name + "/TopBar/Controller/Min").GetComponent<Minimum>();
    //        min.SetIconPosition(transform.position, view.SaveState, view.SetDisable);
    //        Close close = GameObject.Find("/Canvas/" + name + "/TopBar/Controller/Close").GetComponent<Close>();
    //        close.SetCloseEvent(view.SaveState, () => { SetActive(false); });
    //        Top top = GameObject.Find("/Canvas/" + name + "/topbar/move").GetComponent<Top>();
    //        top.setEvent(MoveIfWasFullEvent);
    //    }
    //}
}
