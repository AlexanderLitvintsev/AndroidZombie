using UnityEngine;
using System.Collections;

// Game sound class
public class CGameSound : MonoBehaviour {

    protected SpriteRenderer spriteRenderer;
    
    // sound on sprite
    public Sprite onSound;

    // sound off sprite
    public Sprite offSound;

    // sound mute
    public static bool isMuteGameSound = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Game sound button release
    void OnMouseUpAsButton()
    {
        if (isMuteGameSound)
        {
            isMuteGameSound = false;
            spriteRenderer.sprite = onSound;
        }
        else
        {
            isMuteGameSound = true;
            spriteRenderer.sprite = offSound;
        }
    }

    // Game sound play
    public static void PlayGameSound(AudioClip audioClip, Vector3 play_position)
    {
        if (!isMuteGameSound)
        {
            AudioSource.PlayClipAtPoint(audioClip, play_position);
        }
    }
}
