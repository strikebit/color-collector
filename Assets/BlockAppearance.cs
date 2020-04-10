using UnityEngine;
public class BlockAppearance : MonoBehaviour
{
    public FloatingOrb orb;
    private MeshRenderer render;
    private Collider collide;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        if(GetComponent<SphereCollider>() != null)
        {
            collide = GetComponent<SphereCollider>();
        } else
        {
            collide = GetComponent<Collider>();
        }
    }
    void Update()
    {
        if(orb.collected)
        {
            render.enabled = true;
            collide.enabled = true;
        } else
        {
            render.enabled = false;
            collide.enabled = false;
        }
    }
}
