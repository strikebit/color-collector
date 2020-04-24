using UnityEngine;
public class BlackHole : MonoBehaviour
{
    public float pullRadius;
    public float pullForce;
    public AudioSource sound;
    private void Start()
    {
        sound.Stop();
    }
    public void LateUpdate()
    {
        if(!sound.isPlaying)
        {
            sound.Play();
        }
        foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius))
        {
            if (collider.tag == "Player")
            {
                Vector3 forceDirection = transform.position - collider.transform.position;
                collider.transform.parent.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
            }
            if(collider.tag == "Orb")
            {
                Vector3 forceDirection = transform.position - collider.transform.position;
                collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Orb"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<Collider>().enabled = false;
            foreach(Transform child in other.transform)
            {
                if(child.name == "Particle System")
                {
                    child.GetComponent<ParticleSystem>().Stop();
                } else
                {
                    child.GetComponent<Light>().intensity = 0;
                }
            }
            if (other.GetComponent<FloatingOrb>() != null)
            {
                other.GetComponent<FloatingOrb>().collected = false;
            }
            else if (other.GetComponent<WhiteOrb>() != null)
            {
                other.GetComponent<WhiteOrb>().collected = false;
            }
            else
            {
                other.GetComponent<BlackOrb>().collected = false;
            }
        }
    }
}