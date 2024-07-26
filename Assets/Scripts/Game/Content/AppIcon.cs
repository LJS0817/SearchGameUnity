using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Extended;

public class AppIcon : MonoBehaviour, IPointerClickHandler
{
    //Image stateIcon;
    //Image imageIcon;

    private Animator _ani;
    private App _app;
    private Extend.dEvent _event;

    public void Connect(App a)
    {
        _app = a;
    }

    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData data)
    {
        if(!_app.GetEnable()) _ani.SetTrigger("Change");
        _event();
    }

    public void SetOnClickListener(Extend.dEvent e)
    {
        _event = e;
    }

    public void Disable()
    {
        _ani.SetTrigger("Change");
        _app.SetEnable(false);
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
