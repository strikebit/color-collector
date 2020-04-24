using UnityEngine;
public class ColorShift : MonoBehaviour
{
    public bool white = true;
    private float shade = 1;
    private MeshRenderer render;
    private bool up;
    private float change = 0.02f;
    private float max;
    private float min;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        change = Random.Range(0.0025f, 0.01f);
    }
    void Update()
    {
        if(white)
        {
            max = 1;
            min = 0.5f;
        } else
        {
            max = 0.5f;
            min = 0;
        }
        render.material.color = new Color(shade, shade, shade);
        if(up)
        {
            if(shade < max)
            {
                shade += change;
            } else
            {
                up = false;
            }
        } else
        {
            if(shade > min)
            {
                shade -= change;
            } else
            {
                up = true;
            }
        }
    }
}
