using UnityEngine;

namespace Extended
{
    public class Extend
    {
        public static readonly Vector2 ZERO = Vector2.zero;
        public static readonly Vector2 MIN_SIZE = new Vector2(200, 200);
        public static readonly Vector2 DEFAULT_SIZE = new Vector2(600, 400);
        public static readonly Color closeColor = new Color(0.867f, 0.357f, 0.357f);
        public static readonly Color hoverColor = new Color(0.741f, 0.749f, 0.886f);
        public static readonly Vector3 DISABLED_POSITION = new Vector3(-100000, -100000, 0);
        public static readonly Vector2 DEFAULT_PIVOT = new Vector2(0.5f, 0.5f);


        public delegate void dEvent();
    }
}