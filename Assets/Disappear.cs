using UnityEngine;
public class Disappear : MonoBehaviour
{
    public GameObject two;
    public GameObject one;
    void Start()
    {
        
    }
    void Update()
    {
        if(!one.GetComponent<MeshRenderer>().enabled||!two.GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
