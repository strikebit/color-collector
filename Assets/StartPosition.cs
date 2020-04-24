using UnityEngine;
public class StartPosition : MonoBehaviour
{
    public Vector3 position;
    void Start()
    {
        position = transform.position;
    }
    public void StartPos()
    {
        transform.position = position;
        if(GetComponent<WhiteOrb>() != null)
        {
            GetComponent<WhiteOrb>().collected = false;
        }
        if (GetComponent<FloatingOrb>() != null)
        {
            GetComponent<FloatingOrb>().collected = false;
        }
        foreach(Transform child in transform)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                child.GetComponent<MeshRenderer>().enabled = true;
                child.GetComponent<Collider>().enabled = true;
            }
        }
    }
}
