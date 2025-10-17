using System.Collections.Generic;
using _Source.Script;
using UnityEngine;

namespace _Source.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<Enemy> enemies = new List<Enemy>();
        [SerializeField] private AttackPerformer attackPerformer;
    
        private int _currentEnemyIndex = -1;

        private void Start()
        {
            Debug.Log("EnemyManager started");
            
            // Находим AttackPerformer если не назначен
            if (attackPerformer == null)
            {
                attackPerformer = FindObjectOfType<AttackPerformer>();
                Debug.Log($"Found AttackPerformer: {attackPerformer != null}");
            }
            
            // ПОДПИСЫВАЕМСЯ на событие смены стратегии
            if (attackPerformer != null)
            {
                attackPerformer.OnStrategyChanged += OnPlayerStrategyChanged;
                Debug.Log("Subscribed to OnStrategyChanged event");
            }
            else
            {
                Debug.LogError("AttackPerformer not found!");
            }

            // Деактивируем всех врагов
            DeactivateAllEnemies();
            
            // Активируем первого врага
            SwitchToEnemy(0);
        }

        private void OnDestroy()
        {
            // Отписываемся от событий
            if (attackPerformer != null)
            {
                attackPerformer.OnStrategyChanged -= OnPlayerStrategyChanged;
            }
        }

        // ЭТОТ МЕТОД ВЫЗЫВАЕТСЯ ПРИ СМЕНЕ СТРАТЕГИИ АТАКИ
        private void OnPlayerStrategyChanged()
        {
            Debug.Log("OnPlayerStrategyChanged called!");
            
            if (attackPerformer != null)
            {
                int attackIndex = attackPerformer.GetCurrentAttackIndex();
                Debug.Log($"Switching to enemy index: {attackIndex}");
                SwitchToEnemy(attackIndex);
            }
        }

        private void SwitchToEnemy(int enemyIndex)
        {
            if (enemyIndex < 0 || enemyIndex >= enemies.Count)
            {
                Debug.LogError($"Invalid enemy index: {enemyIndex}");
                return;
            }

            // Деактивируем текущего врага
            if (_currentEnemyIndex >= 0 && _currentEnemyIndex < enemies.Count)
            {
                if (enemies[_currentEnemyIndex] != null)
                {
                    enemies[_currentEnemyIndex].Deactivate();
                }
            }

            // Активируем нового врага
            _currentEnemyIndex = enemyIndex;
            if (enemies[_currentEnemyIndex] != null)
            {
                enemies[_currentEnemyIndex].Activate();
                Debug.Log($"Switched to enemy: {enemies[_currentEnemyIndex].gameObject.name}");
            }
        }

        private void DeactivateAllEnemies()
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.Deactivate();
                }
            }
        }
        
        // Для тестирования
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchToNextEnemy();
            }
        }

        public void SwitchToNextEnemy()
        {
            int nextIndex = (_currentEnemyIndex + 1) % enemies.Count;
            SwitchToEnemy(nextIndex);
        }
    }
}