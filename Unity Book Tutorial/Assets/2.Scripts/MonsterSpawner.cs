using System.ComponentModel;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private const int COUNT_TO_SPAWN = 5;
    private readonly Vector3 SpawnOriginPosition = new Vector3(-2, 0, 0);
    private readonly Vector3 SpawnDistance = new Vector3(0, 1, 0);

    [Tooltip("몬스터 프리팹")]
    [SerializeField]
    private GameObject _monster;

   void Start()
    {
        for (int i = 0; i < COUNT_TO_SPAWN; i++)
        {
            var position = SpawnOriginPosition + SpawnDistance * i;
            var monsterObject = GameObject.Instantiate(_monster, position, Quaternion.identity);

            monsterObject.name = $"Monster {i}";
        }
        
    }

    void Update()
    {
        
    }
}
