using UnityEngine;
using System.Collections;

// Energy bar class
public class CEnergyBar : MonoBehaviour {

    // Energy decrease
    public void DecreaseEnergyBar(float value)
    {
        transform.localScale = new Vector3(value, 1f, 1f);
    }
}
