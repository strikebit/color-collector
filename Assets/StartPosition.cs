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
    }
}
