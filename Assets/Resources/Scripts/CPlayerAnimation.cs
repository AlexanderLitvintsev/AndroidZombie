using UnityEngine;
using System.Collections;

// Player animation event class
public class CPlayerAnimation : MonoBehaviour {

    // Player shoot animation event
    public void ShootAnimation()
    {
        // Player fire
        transform.parent.SendMessage("ShootAnimationEvent");
    }

}
