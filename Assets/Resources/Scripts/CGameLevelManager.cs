using UnityEngine;
using System.Collections;

// Game Level Manager Class
public class CGameLevelManager : MonoBehaviour {

    // Monster kill count
    protected int monsterKillCount = 0;

    // Max monster generate time
    public float maxGenerateTime;

    // Game level
    public float gameLevel = 1;

    // Monster generate point transform
    public Transform monsterGeneratePoint;

    // Monster repository
    protected CMonsterRepository monsterRepository;

    // Game start popup prefab
    public Object gameStartPrefab;

    // Game end popup prefab
    public Object gameEndPrefab;

    void Awake()
    {
        monsterRepository = GetComponent<CMonsterRepository>();
    }

	// Game start initialization
	void Start () {
        Instantiate(gameStartPrefab);
	}
	
    // Game Start
    public void GameStart()
    {
        CGameInfo.IS_GAME_START = true;

        StartCoroutine("MonsterCreateCoroutine");


    }

    // Game End
    public void GameEnd()
    {
        Instantiate(gameEndPrefab, new Vector3(0f, 10f, 0), Quaternion.identity);
    }

    // Create monster
    IEnumerator MonsterCreateCoroutine()
    {
        int delay_range = Random.Range(-1, 2);
        
        float generate_time = (maxGenerateTime - gameLevel) + (float)delay_range;

        int generate_point_index = Random.Range(1, 6);

        Vector3 generate_position = monsterGeneratePoint.FindChild("GeneratePoint" + generate_point_index.ToString()).position;

        Object monster_prefab = monsterRepository.GetMonsterPrefab("Warrior");
        Instantiate(monster_prefab, generate_position, Quaternion.identity);

        yield return new WaitForSeconds(generate_time);

        if (!CGameInfo.IS_GAME_START)
        {
            StopCoroutine("MonsterCreateCoroutine");
            yield break;
        }

        StartCoroutine("MonsterCreateCoroutine");
    }
}
