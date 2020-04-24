using UnityEngine;
public class BlockAppearance : MonoBehaviour
{
    public FloatingOrb orb;
    public FloatingOrb secondOrb;
    public FloatingOrb thirdOrb;
    public bool secondary;
    public bool white;
    private MeshRenderer render;
    private Collider collide;
    void Start()
    {
        if(white)
        {
            secondary = false;
        }
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
        if (white)
        {
            if (orb.collected && secondOrb.collected && thirdOrb.collected)
            {
                render.enabled = true;
                collide.enabled = true;
            }
            else
            {
                render.enabled = false;
                collide.enabled = false;
            }
        } else if (secondary)
        {
            if (orb.collected && secondOrb.collected)
            {
                render.enabled = true;
                collide.enabled = true;
            }
            else
            {
                render.enabled = false;
                collide.enabled = false;
            }
        }
        else
        {
            if (orb.collected)
            {
                render.enabled = true;
                collide.enabled = true;
            }
            else
            {
                render.enabled = false;
                collide.enabled = false;
            }
        }
    }
}