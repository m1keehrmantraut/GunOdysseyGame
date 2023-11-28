using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WavesSystem : MonoBehaviour
{
    public UnityEvent Wave;
    public UnityEvent Free;
    
    [SerializeField] private SpawnOnCircle enemySpawner;
    [SerializeField] private SpawnOnCircle meteorSpawner;

    [SerializeField] private TMP_Text waveText;

    private Animator _animator;

    [SerializeField] private float waveTime = 120f;
    [SerializeField] private float freeTime = 60f;
    [SerializeField] private float firstTime = 20f;

    public int currentWave;
    
    void Start()
    {
        _animator = waveText.GetComponent<Animator>();
        meteorSpawner.ChangeMode(true);
        enemySpawner.ChangeMode(false);
        waveText.text = "WAVE: " + currentWave;
        StartCoroutine(StartFirstRoutine());
    }

    IEnumerator StartFirstRoutine()
    {_animator.Play("WaveAnim");
        yield return new WaitForSeconds(firstTime);
        currentWave++;
        StartCoroutine(StartFreeRoutine());
    }
    
    IEnumerator StartWaveRoutine()
    {
        StartSpawn();
        yield return new WaitForSeconds(waveTime);
        EndSpawn();
        StartCoroutine(StartFreeRoutine());
    }

    private void StartSpawn()
    {
        waveText.text = "WAVE: " + currentWave;
        meteorSpawner.ChangeMode(true);
        enemySpawner.ChangeMode(true);
        Wave.Invoke();
    }

    private void EndSpawn()
    {
        meteorSpawner.ChangeMode(false);
        enemySpawner.ChangeMode(false);
        Free.Invoke();
    }
    
    IEnumerator StartFreeRoutine()
    {
        EndSpawn();
        yield return new WaitForSeconds(freeTime);
        currentWave++;
        StartCoroutine(StartWaveRoutine());
    }
}
