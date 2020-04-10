using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public Transform player;
    private Rigidbody rb;
    private bool jumpable = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(player.position.x>transform.position.x)
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        } else
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if(jumpable)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
            jumpable = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Floor")
        {
            jumpable = true;
        }
    }
}
