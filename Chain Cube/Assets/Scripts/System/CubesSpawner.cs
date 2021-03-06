using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    public static CubesSpawner Instance;
    private void Awake() => Instance = this;

    private int mergeIndex;
    private int lastIndex;

    [SerializeField] private GameObject[] cubePrefab;
    [SerializeField] private int maxIndex;

    public Transform spawnPoint;

    Vector3 newPos = Vector3.zero;

    private void Start()
    {
        mergeIndex = 0;
    }

    public void SpawnCube()
    {
        GameObject cube = Instantiate(cubePrefab[Random.Range(0, maxIndex)], spawnPoint);
        cube.GetComponent<CubeController>().isCreated = true;
    }

    public void LoadState(List<ItemStoredInfo> items)
    {
        foreach(ItemStoredInfo n in items)
        {
            Vector3 pos = new Vector3(n.x, n.y, n.z);
            Quaternion rot = new Quaternion(n.rotX, n.rotY, n.rotZ, n.rotW);

            GameObject cube = Instantiate(cubePrefab[n.id], pos, rot);
            cube.GetComponent<CubeController>().isCreated = true;
        }
    }

    public void MergeCubes(int score, int index, Transform pos)
    {
        mergeIndex++;

        newPos += pos.position;
        if(mergeIndex == 2)
        {
            lastIndex = index;
            newPos /= 2f;

            GameObject cube = new GameObject();
            if(lastIndex < cubePrefab.Length-1)
                cube = Instantiate(cubePrefab[lastIndex+1], newPos, Quaternion.identity);

            cube.GetComponent<CubeController>().isCreated = false;
            Gameplay.Instance.AddScore(score*2);

            newPos = Vector3.zero;
            mergeIndex = 0;
            lastIndex = 0;
        }
    }
}
