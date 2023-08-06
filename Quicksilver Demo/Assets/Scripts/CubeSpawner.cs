using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
