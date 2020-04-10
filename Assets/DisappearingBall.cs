using UnityEngine;
public class DisappearingBall : MonoBehaviour
{
    public float speed;
    public float limit;
    private float scale;
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(limit, -limit), Random.Range(limit, -limit), Random.Range(limit, -limit));
        scale = Random.Range(0.01f, 0.15f);
    }
    void Update()
    {
        if(scale>0)
        {
            scale -= speed;
            transform.localScale = new Vector3(scale, scale, scale);
        } else
        {
            transform.localPosition = new Vector3(Random.Range(limit, -limit), Random.Range(limit, -limit), Random.Range(limit, -limit));
            scale = Random.Range(0.01f, 0.15f);
        }
    }
}
