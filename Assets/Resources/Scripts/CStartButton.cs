using UnityEngine;
using System.Collections;

// Game start button calss
public class CStartButton : MonoBehaviour {

    // Game level manager reference
    protected CGameLevelManager gameLevelManager;

    protected SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite overSprite;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	void Start () 
    {
        gameLevelManager = GameObject.Find("GameModules").GetComponent<CGameLevelManager>();
	}

    // Departing from the start button area
    void OnMouseExit()
    {
        spriteRenderer.sprite = normalSprite;
    }

    // Start button is press
    void OnMouseDown()
    {
        spriteRenderer.sprite = overSprite;
    }

    // Start button is release
    void OnMouseUpAsButton()
    {
        StartCoroutine("ButtonClickDelayCroutine");
    }

    // Game start
    IEnumerator ButtonClickDelayCroutine()
    {
        yield return new WaitForSeconds(0.5f);

        spriteRenderer.sprite = normalSprite;

        yield return new WaitForSeconds(0.3f);

        Destroy(transform.parent.gameObject);

        gameLevelManager.GameStart();
    }
}
