using UnityEngine;

public class SpawnOnCircle : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float radius = 15f;
    [SerializeField] private float spawnDelay = 10f;
    public bool spawn;

    private WavesSystem wave;
    

    private void Start()
    {
        wave = GameObject.FindWithTag("Wave").GetComponent<WavesSystem>();
        InvokeRepeating("SpawnObject", 0f, spawnDelay);
    }

    private void SpawnObject()
    {
        if (spawn)
        {
            float angle = Random.Range(0f, Mathf.PI * 2);

            Vector3 spawnPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            Vector3 lookDirection = Vector3.zero - spawnedObject.transform.position;
            spawnedObject.transform.up = lookDirection.normalized;    
        }
    }
    
    public void ChangeMode(bool bolik)
    {
        spawn = bolik;
    }

    public void DecreaseTime(float amount)
    {
        if (spawnDelay > 3f && wave.currentWave % 2 != 0)
        {
            spawnDelay -= amount;    
        }
    }
    
}
