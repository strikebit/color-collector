using UnityEngine;
public class FlyingEnemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float x;
    public float y;
    void FixedUpdate()
    {
        x = player.position.x - transform.position.x;
        y = player.position.y - transform.position.y;
        transform.position = new Vector3(transform.position.x + x / speed, transform.position.y + y / speed, 0);
    }
}
