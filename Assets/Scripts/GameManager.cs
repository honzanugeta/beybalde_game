using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Ahoj já jsem GameManager a dneska budu managovat hru :)

    [SerializeField] private GameObject playerPrefab;
    private Transform player;
    internal Transform Player => player;
    [SerializeField] private Transform spawnTransform;

    //PowerUps
    [SerializeField] private bool spawnPowerUps;
    [SerializeField] private List<GameObject> powerUpPrefab = new List<GameObject>();
    [SerializeField] private float powerUpSpawnMinDelay;
    [SerializeField] private float powerUpSpawnMaxDelay;
    private List<SpawnArea> spawnAreas;


    internal event Action OnPlayerSpawned;

    // Gamemanager
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (spawnPowerUps)
        {
            Debug.Log("Spawning powerUps");
            SetSpawnZones();
            StartCoroutine(SpawnRandomPowerUp()); 
        }
        Debug.Log("Spawning player");
        SpawnPlayer(spawnTransform);
    }

    private void SetSpawnZones()
    {
        // Find all spawn areas in the scene
        SpawnArea[] areas = FindObjectsOfType<SpawnArea>();
        spawnAreas = new List<SpawnArea>(areas);
    }

    private void SpawnPlayer(Transform spawnPosition)
    {
        player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity).transform;
        OnPlayerSpawned?.Invoke();
    }

    private IEnumerator SpawnRandomPowerUp()
    {
        while (true)
        {
            if (spawnAreas == null || spawnAreas.Count == 0)
            {
                Debug.LogWarning("No spawn areas found!");
                yield break; 
            }

            SpawnArea randomArea = spawnAreas[UnityEngine.Random.Range(0, spawnAreas.Count)];
            Vector3 spawnPoint = randomArea.GetRandomPointInBounds();

            GameObject randomPowerUp = powerUpPrefab[UnityEngine.Random.Range(0, powerUpPrefab.Count)];

            Instantiate(randomPowerUp, spawnPoint, Quaternion.identity);

            float delay = UnityEngine.Random.Range(powerUpSpawnMinDelay, powerUpSpawnMaxDelay);
            yield return new WaitForSeconds(delay); 
        }
    }
}
