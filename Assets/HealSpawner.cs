using UnityEngine;

public class HealSpawner: MonoBehaviour
{
    public float radiusX = 5f; // радиус эллипса по X
    public float radiusY = 3f; // радиус эллипса по Y
    public GameObject objectToSpawn; // объект для создания
    public float minSpawnDelay = 1f; // минимальная задержка перед созданием объекта
    public float maxSpawnDelay = 2f; // максимальная задержка перед созданием объекта

    private void Start()
    {
        float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
        Invoke("SpawnObject", delay);
    }

    private void SpawnObject()
    {
        // Получаем рандомные значения в диапазоне от 0 до 2Пи
        float angle = Random.Range(0f, 2f * Mathf.PI);
        
        // Вычисляем позицию объекта на эллипсе
        float spawnX = transform.position.x + Mathf.Sin(angle) * radiusX;
        float spawnY = transform.position.y + Mathf.Cos(angle) * radiusY;

        // Создаем объект на рассчитанных координатах
        Instantiate(objectToSpawn, new Vector3(spawnX, spawnY, 0f), Quaternion.identity);

        // Генерируем новую задержку и вызываем метод SpawnObject в следующем рандомном времени
        float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
        Invoke("SpawnObject", delay);
    }
}