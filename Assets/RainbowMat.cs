using UnityEngine;
public class RainbowMat : MonoBehaviour
{
    public float change;
    private bool up;
    private bool redChange;
    private bool greenChange;
    private bool blueChange;
    private float red;
    private float green;
    private float blue;
    private MeshRenderer render;
    void Start()
    {
        red = 1;
        greenChange = true;
        up = true;
        render = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        render.material.color = new Color(red, green, blue);
        if(redChange)
        {
            if(red < 1 && up || red > 0 && !up)
            {
                if(up)
                {
                    red += change;
                } else
                {
                    red -= change;
                }
            } else
            {
                blueChange = true;
                redChange = false;
                if(up)
                {
                    up = false;
                } else
                {
                    up = true;
                }
            }
        }
        if (greenChange)
        {
            if (green < 1 && up || green > 0 && !up)
            {
                if (up)
                {
                    green += change;
                }
                else
                {
                    green -= change;
                }
            }
            else
            {
                redChange = true;
                greenChange = false;
                if (up)
                {
                    up = false;
                }
                else
                {
                    up = true;
                }
            }
        }
        if (blueChange)
        {
            if (blue < 1 && up || blue > 0 && !up)
            {
                if (up)
                {
                    blue += change;
                }
                else
                {
                    blue -= change;
                }
            }
            else
            {
                greenChange = true;
                blueChange = false;
                if (up)
                {
                    up = false;
                }
                else
                {
                    up = true;
                }
            }
        }
    }
}