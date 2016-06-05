using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Monster prefab repository
public class CMonsterRepository : MonoBehaviour
{
    // Monster prefab dictionary
    protected Dictionary<string, Object> monsterPrefabMap;

    void Awake()
    {
        LoadMonsterPrefabs();
    }

    // Monster prefab load
    public void LoadMonsterPrefabs()
    {
        monsterPrefabMap = new Dictionary<string, Object>();
        
        monsterPrefabMap.Add("Warrior", Resources.Load("Prefabs/Monsters/Warrior"));
        monsterPrefabMap.Add("urban_zombie_mobile1", Resources.Load("Prefabs/Monsters/urban_zombie_mobile1"));
    }

    // Get monster prefab
    public Object GetMonsterPrefab(string monster_name)
    {
        if (!monsterPrefabMap.ContainsKey(monster_name)) return null;

        return monsterPrefabMap[monster_name];
    }
}
