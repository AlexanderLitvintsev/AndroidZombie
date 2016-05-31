using UnityEngine;
using System.Collections;

// End game button class
public class CEndButton : MonoBehaviour {

    protected SpriteRenderer spriteRenderer;
    
    // Default sprite
    public Sprite normalSprite;

    // Click sprite
    public Sprite clickedSprite;

    // click enable flag
    protected bool isClickEnable = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Clickable
    public void OnClickEnable()
    {
        isClickEnable = true;
    }

    // Departing from the end button area
    void OnMouseExit()
    {
        if (!isClickEnable) return;

        spriteRenderer.sprite = normalSprite;
    }

    // End button is press
    void OnMouseDown()
    {
        spriteRenderer.sprite = clickedSprite;
    }

    // End button is release
    void OnMouseUpAsButton()
    {
        if (!isClickEnable) return;

        StartCoroutine("ButtonClickDelayCroutine");
    }

    // Game Restart
    IEnumerator ButtonClickDelayCroutine()
    {
        yield return new WaitForSeconds(0.5f);

        spriteRenderer.sprite = normalSprite;

        yield return new WaitForSeconds(0.3f);

        Application.LoadLevel(0);
    }

}
