using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float distance = 20;
    public float moveSpeed = 2;
    public float timeToSpawn = 2;
    [SerializeField] GameObject cubeToMove;

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            var spawnedCube = Instantiate(cubeToMove);
            spawnedCube.GetComponent<MovingCube>().CubeSpawned(distance, moveSpeed);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
