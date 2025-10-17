using _Source.Enemy;
using _Source.Script;
using UnityEngine;

namespace _Source.GeneralManager
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Enemies")]
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform enemySpawnPoint;

        private void Awake()
        {
            InitializeEnemies();
        }

        private void InitializeEnemies()
        {
            foreach (var enemyPrefab in enemyPrefabs)
            {
                if (enemyPrefab != null && enemySpawnPoint != null)
                {
                    var enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
                    enemy.SetActive(false); 
                }
            }
        }
    }
}