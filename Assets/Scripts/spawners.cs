using UnityEngine;
public class spawners : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public spawnkar[] enemy;
    private float distance;
    private float distanceUsed;

    private void Update()
    {    
        if (distance < transform.position.x+30)
        {
            distance = transform.position.x+30 ;
        }
        float distToGo = Mathf.Floor(distance - distanceUsed);
        if (distanceUsed < distance && distToGo > 1)
        {
            distanceUsed = distance;
            spawnobject();
        }
    }
    private void spawnobject()
    {
        int i = Random.Range(0, 100);
        for(int j = 0; j < enemy.Length; j++)
        {
            if (i >= enemy[j].minProbabilityRange && i <= enemy[j].maxProbabilityRange)
            {
                
                float yPos = Mathf.Floor(Mathf.Abs(Random.Range(0f, 1f) - Random.Range(0f, 1f)) * (1 + 100 - (-2)) + (-2));
                Vector2 posToSpawnEnemy = new Vector2(distance, yPos);
                Instantiate(enemy[j].spawnobject, posToSpawnEnemy, Quaternion.identity);
                break;
            }
        }
    }
    [System.Serializable]
    public class spawnkar
    {
        public GameObject spawnobject;
        public int minProbabilityRange = 0;
        public int maxProbabilityRange = 0;
    }
}
