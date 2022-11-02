using UnityEngine;

public class CollectableGenerator : MonoBehaviour
{
    [Range(1, 10)]
    public int widht, height;
    Vector3 origin = Vector3.zero;
    public GameObject[] collectables;
    void Start()
    {
        Application.targetFrameRate = 60;
        GenerateCollectables();
    }
    private void GenerateCollectables()
    {
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < widht; x++)
            {
                int randomValue = Random.Range(0, collectables.Length);
                origin = new Vector3(x - Center(widht), 0, z - Center(height));
                Instantiate(collectables[randomValue], origin, transform.rotation, transform);
            }
        }
    }

    private float Center(float value)
    {
        return (value - 1f) / 2f;
    }
}