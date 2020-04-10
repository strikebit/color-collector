using UnityEngine;
public class DirectFollow : MonoBehaviour
{
    public Transform following;
    public Vector3 offset;
    void Update()
    {
        transform.position = following.position + offset;
    }
}
