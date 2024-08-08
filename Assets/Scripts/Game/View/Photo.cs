using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : View
{
    Animator _detailAni;

    public Button InfoCloseBtn;
    public Button InfoBtn;
    public Button CloseBtn;

    public Transform CardParent;

    public List<Sprite> Sprites;
    public List<string> Descriptions;
    public List<string> Owners;
    public List<string> Locations;
    public List<string> Capacities;
    //public List<DateTime> Times;

    protected override void init()
    {
        _detailAni = GameObject.Find("/Canvas/" + name + "/Content/Detail").GetComponent<Animator>();

        InfoCloseBtn.onClick.AddListener(() => { _detailAni.SetTrigger("ChangeState"); });
        InfoBtn.onClick.AddListener(() => { _detailAni.SetTrigger("ChangeState"); });
        CloseBtn.onClick.AddListener(() => { _detailAni.SetBool("Show", false); });

        for (int i = 0; i < CardParent.childCount; i++)
        {
            CardParent.GetChild(i).GetComponent<Button>().onClick.AddListener(() => {
                _detailAni.SetBool("Show", true); 
            });
            CardParent.GetChild(i).GetComponent<Picture>().SetData(Sprites[i], Descriptions[i], Owners[i], Locations[i], Capacities[i], 
                DateTime.Now, _detailAni.transform.GetChild(0).GetChild(0).GetComponent<Image>());
        }
        base.init();
    }
}
