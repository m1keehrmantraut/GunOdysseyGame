using System;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 5f; // Скорость снаряда
    public float rotationSpeed = 200f; // Скорость поворота снаряда
    public float searchRadius = 5f; // Радиус поиска врагов
    public LayerMask enemyLayer; // Слой врагов
    public float sectorAngle = 360f; // Угол сектора для поиска врагов

    private Transform target; // Цель снаряда

    private void Update()
    {
        FindTarget();

        // Если есть цель, летим к ней
        if (target != null)
        {
            Debug.Log("Qrr");
            Vector2 direction = (target.position - transform.position).normalized;
            transform.up = Vector2.Lerp(transform.up, direction, rotationSpeed * Time.deltaTime);
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyHealth>().DieEnemy();
            Destroy(gameObject);
        }
    }

    // Ищем ближайшего врага в заданном секторе окружности
    private void FindTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, searchRadius, enemyLayer);
        target = null;

        foreach (Collider2D enemy in enemies)
        {
            Vector2 directionToEnemy = (enemy.transform.position - transform.position).normalized;
            float angle = Vector2.Angle(transform.up, directionToEnemy);

            // Если враг в заданном секторе
            if (angle <= sectorAngle / 2)
            {
                if (target == null)
                {
                    target = enemy.transform;
                }
                else
                {
                    float distanceToTarget = Vector2.Distance(transform.position, target.position);
                    float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

                    // Если этот враг ближе к снаряду, обновляем цель
                    if (distanceToEnemy < distanceToTarget)
                    {
                        target = enemy.transform;
                    }
                }
            }
        }
    }
}