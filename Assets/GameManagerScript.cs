using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 enemyPos1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefab, enemyPos1, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
