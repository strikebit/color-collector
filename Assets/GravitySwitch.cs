using UnityEngine;
public class GravitySwitch : MonoBehaviour
{
    public Controller control;
    public AudioSource sound;
    public float change;
    public bool started;
    //private float rot;
    void Start()
    {
        sound.Stop();
    }
    void Update()
    {
        if (control.collided)
        {
            if (started)
            {
                started = false;
                sound.Play();
            }
            if (control.rotateTo > transform.eulerAngles.z)
            {
                //rot += change;
                transform.RotateAround(control.transform.position, Vector3.forward, change);
            }
            else
            {
                control.collided = false;
            }
            if (transform.eulerAngles.z > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - 360);
            }
            //transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }
}