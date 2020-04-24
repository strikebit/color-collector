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
    private bool first;
    void Start()
    {
        collide = GetComponent<SphereCollider>();
        collect.Stop();
    }
    void Update()
    {
        if(collected)
        {
            if(first)
            {
                first = false;
                collect.Play();
                whiteOrb.collected = false;
            }
            if(whiteOrb.collected)
            {
                collected = false;
            }
            x = transform.position.x - player.position.x;
            y = transform.position.y - player.position.y;
            transform.position = new Vector3(transform.position.x - x/speed, transform.position.y - y/speed, 0);
        } else
        {
            first = true;
        }
    }
}