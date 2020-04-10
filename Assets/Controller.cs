using UnityEngine;
public class Controller : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource win;
    public AudioSource hurt;
    public AudioSource nextLevel;
    public float speed;
    public float jumpForce;
    public float rotateTo;
    public float min;
    public float max;
    public float heightSpeed;
    public int currentLevel = 1;
    public bool collided;
    public bool active = true;
    public Transform quad;
    public LevelBuilder level;
    public RainbowMat rainbow;
    public ColorShift shift;
    public UnityEngine.UI.Text text;
    private float sizeSpeed = 0.2f;
    private float size;
    private bool down;
    private int jumps = 1;
    private bool jumpable;
    private Rigidbody rb;
    private float height = 1;
    private bool up;
    private bool finished;
    private bool started;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpSound.Stop();
        win.Stop();
        hurt.Stop();
        nextLevel.Stop();
    }
    void FixedUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
        if(up)
        {
            if(height<max)
            {
                height += heightSpeed;
            } else
            {
                up = false;
            }
        } else
        {
            if(height>min)
            {
                height -= heightSpeed;
            } else
            {
                up = true;
            }
        }
        if (active)
        {
            if(transform.position.y<-30||transform.position.y>60)
            {
                active = false;
                down = false;
                hurt.Play();
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("space"))
            {
                if (jumps > 0 && jumpable)
                {
                    rb.AddForce(0, jumpForce * Time.deltaTime, 0);
                    jumpable = false;
                    jumps--;
                    jumpSound.Play();
                }
            }
            else
            {
                jumpable = true;
            }
        }
        else
        {
            if (size < 20 && !down)
            {
                size += sizeSpeed;
            } else if(size>0)
            {
                down = true;
                size -= sizeSpeed;
                if(finished)
                {
                    currentLevel++;
                    finished = false;
                }
                if(started)
                {
                    started = false;
                    nextLevel.Play();
                }
                level.BuildLevel(currentLevel);
            } else
            {
                active = true;
                size = 0;
            }
            quad.localScale = new Vector3(size, size, 0);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Floor"&&transform.position.y>collision.collider.transform.position.y)
        {
            jumps = 1;
        }
        if(collision.collider.tag == "Switch")
        {
            rotateTo = collision.collider.GetComponentInParent<RotationManagement>().rotation;
            collided = true;
            collision.collider.GetComponent<MeshRenderer>().enabled = false;
            collision.collider.GetComponent<Collider>().enabled = false;
            collision.collider.transform.parent.GetComponentInParent<GravitySwitch>().started = true;
        }
        if(collision.collider.tag == "Enemy"&&active)
        {
            active = false;
            down = false;
            hurt.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Finish")
        {
            if (currentLevel == 10)
            {
                shift.enabled = false;
                rainbow.enabled = true;
                text.text = "You have won your colors!";
                win.Play();
            }
            else
            {
                started = true;
                finished = true;
                active = false;
                down = false;
                nextLevel.Play();
            }
        }
    }
}