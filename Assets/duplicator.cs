using UnityEngine;
public class duplicator : MonoBehaviour
{
    public GameObject ball;
    void Start()
    {
        for(var i = 0; i < 20; i++)
        {
            GameObject clone = Instantiate(ball);
            clone.transform.parent = transform;
        }
    }
}
