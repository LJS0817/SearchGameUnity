using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly Vector2 MIN_SIZE = new Vector2(200, 200);
    public static readonly Vector2 DEFAULT_SIZE = new Vector2(400, 400);
    public static readonly Color closeColor = new Color(0.867f, 0.357f, 0.357f);
    public static readonly Color hoverColor = new Color(0.741f, 0.749f, 0.886f);
    public static readonly Vector3 DISABLED_POSITION = new Vector3(-100000, -100000, 0);

    public static readonly string[] ViewList = new string[1] { "Test" };


    private void Start()
    {
        Transform viewParent = GameObject.Find("/Canvas").transform;
        Transform iconParent = GameObject.Find("/Canvas/AppList").transform;
        for (int i = 0; i < ViewList.Length; i++)
        {
            viewParent.GetChild(i).name = iconParent.GetChild(i).name = ViewList[i];
            iconParent.GetChild(i).GetComponent<WindowIcon>().ConnectView(viewParent.GetChild(i).GetComponent<View>());
        }
    }
}
