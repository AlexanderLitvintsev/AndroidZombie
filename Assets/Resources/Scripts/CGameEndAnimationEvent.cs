using UnityEngine;
using System.Collections;

// End Button Popup animation event class
public class CGameEndAnimationEvent : MonoBehaviour {

    protected GameObject gameInfo;

	void Start () {
        gameInfo = GameObject.Find("GameInfo");
	}

    // Game end popup output complete
    public void GameEndPopupAnimationComplete()
    {
        // Game score print
        gameInfo.SendMessage("PrintGameScore");
    }
}
