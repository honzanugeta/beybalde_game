using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArenaCreation : MonoBehaviour
{
    [SerializeField]
    List<GameObject> arenaPrefabs;

    [SerializeField]
    List<GameObject> beybladePrefabs;

    GameObject currArena;
    List<GameObject> spawnpoints;   


    private void Awake()
    {
        currArena = arenaPrefabs[Random.Range(0, arenaPrefabs.Count)];
        Instantiate(currArena, Vector3.zero, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint").ToList();
        

        //spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoints").ToList();
        foreach (GameObject spawnpoint in spawnpoints)
        {
            Instantiate(beybladePrefabs[Random.Range(0, beybladePrefabs.Count)], spawnpoint.transform);
        }
    }
}
