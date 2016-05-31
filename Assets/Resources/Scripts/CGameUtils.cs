using UnityEngine;
using System.Collections;

// Game util class
public class CGameUtils : MonoBehaviour {

    // Touch position to World position
    public static Vector3 InputTouchPositionToWorldPosition()
    {
        Vector2 screen_touch_pos = Input.mousePosition;

        Vector3 world_touch_pos = Camera.main.ScreenToWorldPoint(
            new Vector3(screen_touch_pos.x, screen_touch_pos.y, 0));

        return world_touch_pos;
    }
}
