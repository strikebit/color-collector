using UnityEngine;
public class WhiteOrb : MonoBehaviour
{
    public Transform player;
    public float speed;
    public bool collected;
    private Collider collide;
    private float x;
    private float y;
    void Start()
    {
        collide = GetComponent<Collider>();
    }
    void Update()
    {
        if (collected)
        {
            x = transform.position.x - player.position.x;
            y = transform.position.y - player.position.y;
            transform.position = new Vector3(transform.position.x - x / speed, transform.position.y - y / speed, 0);
        }
        else
        {
            collide.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            collected = true;
            collide.enabled = false;
        }
    }
}
