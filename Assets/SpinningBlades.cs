using UnityEngine;
public class SpinningBlades : MonoBehaviour
{
    public float speed;
    private float rot;
    private float x;
    private float y;
    void Start()
    {
        rot = 0;
    }
    void Update()
    {
        x = transform.parent.GetComponent<FlyingEnemy>().x;
        y = transform.parent.GetComponent<FlyingEnemy>().y;
        speed = Mathf.Abs(Mathf.Sqrt(x*x+y*y)*2);
        rot += speed;
        transform.rotation = Quaternion.Euler(0, rot, 0);
    }
}
