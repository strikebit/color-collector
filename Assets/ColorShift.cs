using UnityEngine;
public class ColorShift : MonoBehaviour
{
    private float shade;
    private MeshRenderer render;
    private bool up;
    private float change = 0.02f;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        change = Random.Range(0.01f, 0.03f);
    }
    void Update()
    {
        render.material.color = new Color(shade, shade, shade);
        if(up)
        {
            if(shade < 1)
            {
                shade += change;
            } else
            {
                up = false;
            }
        } else
        {
            if(shade > 0)
            {
                shade -= change;
            } else
            {
                up = true;
            }
        }
    }
}
