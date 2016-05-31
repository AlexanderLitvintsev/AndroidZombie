using UnityEngine;
using System.Collections;

// Game Info Class
public class CGameInfo : MonoBehaviour {

    // Game start state
    public static bool IS_GAME_START = false;
    // Game score
    public static int GAME_SCORE = 0;

    // Screen width
    public int scrWidth = 800;
    // Screen height
    public int scrHeight = 480;
    
    // GUI Scale
    protected Vector3 guiScale = new Vector3(0, 0, 0);

    // Game score output state
    protected bool isPrintGameScore = false;

    // Print game score
    public void PrintGameScore()
    {
        isPrintGameScore = true;
        GameObject.Find("RestartButton").SendMessage("OnClickEnable");
    }

    void OnGUI()
    {
        guiScale.x = (float)Screen.width / scrWidth;
        guiScale.y = (float)Screen.height / scrHeight;
        guiScale.z = 1;
        Matrix4x4 oldMatrix = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, guiScale);

        // Print score
        string score = "Kill : " + GAME_SCORE.ToString();

        if (isPrintGameScore)
        {
            GUI.skin.label.fontSize = 40;
            GUI.Label(new Rect(440, 188, 300, 50), GAME_SCORE.ToString());
        }

        if (CGameInfo.IS_GAME_START)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(660, 430, 300, 50), score);
        }

        GUI.matrix = oldMatrix;
    }

}
