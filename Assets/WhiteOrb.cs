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
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collected && collider.name == "Glass")
        {
            foreach(Transform child in collider.transform)
            {
                if (child.name != "Streaks")
                {
                    child.gameObject.SetActive(true);
                    child.GetComponent<SeparatingOrb>().Separate(transform);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
