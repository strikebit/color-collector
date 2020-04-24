using UnityEngine;
public class Controller : MonoBehaviour
{
    public float change;
    public AudioSource fall;
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
    private bool down;
    private int jumps = 1;
    private bool jumpable;
    private Rigidbody rb;
    private float height = 1;
    private bool up;
    private bool started;
    private float visiblilty;
    void Start()
    {
        quad.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
        rb = GetComponent<Rigidbody>();
        jumpSound.Stop();
        win.Stop();
        hurt.Stop();
        nextLevel.Stop();
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > 10)
        {
            rb.velocity = rb.velocity.normalized * 10;
        }
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
            if(transform.position.y<-30)
            {
                active = false;
                down = false;
                fall.Play();
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("r"))
            {
                text.text = "";
                active = false;
                down = false;
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
            if (visiblilty < 1.5 && !down)
            {
                visiblilty += change;
            } else if(visiblilty>0)
            {
                visiblilty -= change;
                down = true;
                if(started)
                {
                    started = false;
                    nextLevel.Play();
                    currentLevel++;
                }
                level.BuildLevel(currentLevel);
            } else
            {
                active = true;
            }
            quad.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, visiblilty);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Floor"&&transform.position.y>collision.collider.transform.position.y)
        {
            jumps = 1;
        }
        if(collision.collider.tag == "Switch" && !collided)
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
            if (currentLevel >= 15)
            {
                shift.enabled = false;
                rainbow.enabled = true;
                text.text = "You have won your colors! " +
                    "Press r to start again!";
                currentLevel = 1;
                win.Play();
            }
            else
            {
                started = true;
                active = false;
                down = false;
                nextLevel.Play();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Orb")
        {
            if (other.GetComponent<FloatingOrb>() != null)
            {
                other.GetComponent<FloatingOrb>().collected = true;
            } else if (other.GetComponent<WhiteOrb>() != null)
            {
                other.GetComponent<WhiteOrb>().collected = true;
            } else
            {
                other.GetComponent<BlackOrb>().collected = true;
                other.GetComponent<BlackOrb>().started = true;
            }
        }
    }
}