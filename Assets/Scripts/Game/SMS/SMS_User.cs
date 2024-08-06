using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SMS_User : MonoBehaviour
{
    private int _id;
    private DateTime _lastContect;
    private int _lastWordsIndex;

    public TMP_Text _nameWidget;
    public TMP_Text _detailWidget;
    public TMP_Text _timeWidget;

    private void Start()
    {
        transform.position = Vector3.zero;
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        
    }

    public void Connect(int id, string str)
    {
        _id = id;
        name = str;
        _lastContect = new DateTime();
        _lastWordsIndex = 0;

        _nameWidget.SetText(name);
    }
}
