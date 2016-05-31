using UnityEngine;
using System.Collections;

// Attack touch area class
public class CAttackTouchArea : MonoBehaviour {

    // Player
    public Transform player;

    // Bullet departing from the attack touch area
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
            collider.SendMessage("DoDestroy", 0f);
    }

    // Click attack touch area
    void OnMouseUpAsButton()
    {
        if (!CGameInfo.IS_GAME_START) return;

        Vector3 world_touch_pos = CGameUtils.InputTouchPositionToWorldPosition();
        player.SendMessage("NotiAttackTouchEvent", world_touch_pos);
    }

}
