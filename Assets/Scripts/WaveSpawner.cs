using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING,FINISHED };
    public GameObject shop;

    
    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemy;

        public int count;
        public float rate;
        

    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] SpawnPoints; 
    public Transform spawnPoint;

    public Text timer;
    public float timeBetweenWaves = 5f;
    private float waveCountDown;
    public SpawnState state = SpawnState.COUNTING;

    private float searchCountdown = 1f;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;

    }
    public void FixedUpdate()
    {
        if (state == SpawnState.COUNTING)
        {
            openShop();
        }
        else
        {
            closeShop();
        }
    }

    public void Update()
    {
        int timer2 = (int) waveCountDown;
        timer.text = timer2.ToString();

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Spawnıng
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            if (state != SpawnState.FINISHED)
            {
                waveCountDown -= Time.deltaTime;
            }
        }
        
    }

    public void startnexround()
    {
        waveCountDown = 1;
    }
    public void WaveCompleted()
    {
        Debug.Log("WaveCompleted");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            state = SpawnState.FINISHED;
            Debug.Log("ALL WAVES Completed!!");

        }
        else
        {
            nextWave++;
        }
    }

    public bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("Zombi Kalmadı");
                return false;
            }
        }
        return true;
    }

    public IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        Debug.Log("Wave Starting" + _wave.name);

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    public void SpawnEnemy(GameObject _enemy)
    {
        //Spawn Enemy
        Debug.Log("Spawning Enemy");
        Transform _sp = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    public void openShop()
    {
        shop.SetActive(true);
    }
    
    public void closeShop()
    {
        shop.SetActive(false);
    }
}

