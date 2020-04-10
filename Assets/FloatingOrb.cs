using UnityEngine;
public class FloatingOrb : MonoBehaviour
{
    public Transform player;
    public float speed;
    public WhiteOrb whiteOrb;
    private Collider collide;
    public bool collected = false;
    public AudioSource collect;
    private float x;
    private float y;
    void Start()
    {
        collide = GetComponent<SphereCollider>();
        collect.Stop();
    }
    void Update()
    {
        if(collected)
        {
            if(whiteOrb.collected)
            {
                collected = false;
            }
            x = transform.position.x - player.position.x;
            y = transform.position.y - player.position.y;
            transform.position = new Vector3(transform.position.x - x/speed, transform.position.y - y/speed, 0);
        } else
        {
            collide.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            collide.enabled = false;
            collected = true;
            whiteOrb.collected = false;
            collect.Play();
        }
    }
}