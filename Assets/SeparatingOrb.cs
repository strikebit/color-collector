using UnityEngine;
public class SeparatingOrb : MonoBehaviour
{
    public int direction;
    public float speed;
    private Vector3 desiredPosition;
    private bool moving;
    void Update()
    {
        if(moving)
        {
            if(direction == 1)
            {
                if(transform.position.x < desiredPosition.x)
                {
                    transform.position = new Vector3(transform.position.x + speed, transform.position.y, 0);
                } else
                {
                    moving = false;
                }
            } else if(direction == 2)
            {
                if (transform.position.x > desiredPosition.x)
                {
                    transform.position = new Vector3(transform.position.x - speed, transform.position.y, 0);
                }
                else
                {
                    moving = false;
                }
            } else
            {
                if (transform.position.y < desiredPosition.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
                }
                else
                {
                    moving = false;
                }
            }
        }
    }
    public void Separate(Transform whiteOrb)
    {
        transform.position = whiteOrb.position;
        if(direction == 1)
        {
            desiredPosition = new Vector3(transform.position.x + 2, transform.position.y, 0);
        } else if(direction == 2)
        {
            desiredPosition = new Vector3(transform.position.x - 2, transform.position.y, 0);
        } else
        {
            desiredPosition = new Vector3(transform.position.x, transform.position.y + 2, 0);
        }
        moving = true;
    }
}
