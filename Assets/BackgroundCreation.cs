using UnityEngine;
public class BackgroundCreation : MonoBehaviour
{
    public GameObject block;
    public int duplications;
    public float min;
    public float max;
    public float range;
    private float importance;
    private float x;
    private float y;
    void Start()
    {
        for(var i = 0; i < duplications; i++)
        {
            importance = Random.Range(block.transform.position.z - range, block.transform.position.z + range);
            x = Random.Range(min, max);
            y = Random.Range(min, max);
            GameObject clone = Instantiate(block, new Vector3(x, y, importance), Quaternion.Euler(0, 0, 0));
        }
    }
}
