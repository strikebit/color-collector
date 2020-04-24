using UnityEngine;
public class BlackOrb : MonoBehaviour
{
    public WhiteOrb white;
    public Transform player;
    public float speed;
    public bool collected;
    public bool started;
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
            if(started)
            {
                foreach (Transform sibling in transform.parent)
                {
                    if (sibling.name == "BlackObject")
                    {
                        //sibling.GetComponent<MeshRenderer>().enabled = true;
                        //sibling.GetComponent<Collider>().enabled = true;
                        sibling.gameObject.SetActive(true);
                    }
                    if (sibling.name == "Wall" || sibling.name == "Ground")
                    {
                        sibling.gameObject.SetActive(false);
                    }
                    white.collected = false;
                }
                started = false;
            }
            GameObject.Find("BackGround").GetComponent<ColorShift>().white = false;
            if(white.collected)
            {
                collected = false;
            }
            collide.enabled = false;
            x = transform.position.x - player.position.x;
            y = transform.position.y - player.position.y;
            transform.position = new Vector3(transform.position.x - x / speed, transform.position.y - y / speed, 0);
        }
        else
        {
            GameObject.Find("BackGround").GetComponent<ColorShift>().white = true;
            collide.enabled = true;
            foreach (Transform sibling in transform.parent)
            {
                if (sibling.name == "BlackObject")
                {
                    sibling.gameObject.SetActive(false);
                }
                if (sibling.name == "Wall" || sibling.name == "Ground")
                {
                    sibling.gameObject.SetActive(true);
                }
            }
        }
    }
}