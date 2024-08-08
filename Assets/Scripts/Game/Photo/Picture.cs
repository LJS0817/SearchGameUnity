using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{
    private DateTime _time;
    private string _description;
    private string _owner;
    private string _location;
    private string _capacity;

    private Image _img;
    private TMP_Text _timeTxt;
    private TMP_Text _descTxt;
    private TMP_Text _ownerTxt;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("2134");
    }

    public void SetData(Sprite _sp, string _d, string _o, string _l, string _c, DateTime _dt, Image _target)
    {
        _img = transform.GetChild(2).GetChild(0).GetComponent<Image>();
        _timeTxt = transform.GetChild(1).GetComponent<TMP_Text>();
        _descTxt = transform.GetChild(4).GetComponent<TMP_Text>();
        _ownerTxt = transform.GetChild(5).GetComponent<TMP_Text>();

        _img.sprite = _sp;
        _time = _dt;
        _description = _d;
        _owner = _o;
        _location = _l;
        _capacity = _c;

        GetComponent<Button>().onClick.AddListener(() => { _target.sprite = _sp; });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
