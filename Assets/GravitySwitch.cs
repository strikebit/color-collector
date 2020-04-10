using UnityEngine;
public class GravitySwitch : MonoBehaviour
{
    public Controller control;
    public AudioSource sound;
    public float change;
    private float rotation;
    public bool started;
    void Start()
    {
        sound.Stop();
    }
    void Update()
    {
        if(control.collided)
        {
            if(started)
            {
                rotation = 0;
                started = false;
                sound.Play();
            }
            if(rotation<control.rotateTo)
            {
                rotation += change;
            } else if(rotation>control.rotateTo)
            {
                rotation -= change;
            } else
            {
                control.collided = false;
            }
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
}
