using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Range(1, 10)]
    public int widht, height;
    Vector3 origin = Vector3.zero;

    public GameObject[] collectables;
    void Start()
    {
        Application.targetFrameRate = 60;
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < widht; x++)
            {
                int randomValue = Random.Range(0, 3);
                GameObject obj = Instantiate(collectables[0], origin, transform.rotation, transform);
                origin = new Vector3((x + 1)*1.5f, 0f, z);
            }
            origin = new Vector3(0f, 0f, z + 1);

        }
    }

    private float Center(float value)
    {
        return (value - 1f) / 2f;
    }
}