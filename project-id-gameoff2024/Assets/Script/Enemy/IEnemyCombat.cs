using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public interface IEnemyCombat
{
    public Enemy Enemy { get; set; }
    public float RotateSpeed { get; set; }
    public float AttackDelay { get; set; }
    public bool IsAttacking { get; set; }

    public void Awake();
    public Ray GetEnemyDirection();
    public void EnemySummonAttack();
    public void HandleAttack();
    public IEnumerator InitAttack(float delay);
}
