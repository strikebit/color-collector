using UnityEngine;
public class BackGroundChange : MonoBehaviour
{
    public Camera view;
    public float speed;
    public float range;
    private float color;
    private float realSpeed;
    private bool up;
    void Start()
    {
        realSpeed = Random.Range(speed - range / 2, speed + range / 2);
    }
    void Update()
    {
        view.backgroundColor = new Color(color, color, color);
        if (up)
        {
            if (color < 1)
            {
                color += realSpeed;
            } else
            {
                up = false;
            }
        } else
        {
            if (color > 0)
            {
                color -= realSpeed;
            } else
            {
                up = true;
            }
        }
    }
}
