using UnityEngine;
using System.Collections;

// Monster animation event class
public class CMonsterAnimationEvent : MonoBehaviour {

    // Monster attack animation start complete
    public void MonsterAttackAnimationStartComplete()
    {
        transform.parent.SendMessage("AttackAnimationStartComplete");
    }

    // Monster attack animation complete
    public void MonsterAttackAnimationComplete()
    {
        transform.parent.SendMessage("AttackAnimationComplete");
    }

    // Monster hit animation complete
    public void MonsterHitAnimationComplete()
    {
        transform.parent.SendMessage("HitAnimationComplete");
    }
}
