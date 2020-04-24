using UnityEngine;
public class LevelBuilder : MonoBehaviour
{
    public StartPosition player;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    public GameObject level8;
    public GameObject level9;
    public GameObject level10;
    public GameObject level11;
    public GameObject level12;
    public GameObject level13;
    public GameObject level14;
    public GameObject level15;
    void Start()
    {
        level1.SetActive(true);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        level7.SetActive(false);
        level8.SetActive(false);
        level9.SetActive(false);
        level10.SetActive(false);
        level11.SetActive(false);
        level12.SetActive(false);
        level13.SetActive(false);
        level14.SetActive(false);
        level15.SetActive(false);
    }
    public void BuildLevel(int level)
    {
        GameObject.Find("BackGround").GetComponent<ColorShift>().white = true;
        player.StartPos();
        if (level == 1)
        {
            level15.SetActive(false);
            level1.SetActive(true);
            foreach (Transform child in level1.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 2)
        {
            level1.SetActive(false);
            level2.SetActive(true);
            foreach (Transform child in level2.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 3)
        {
            level2.SetActive(false);
            level3.SetActive(true);
            foreach (Transform child in level3.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 4)
        {
            level3.SetActive(false);
            level4.SetActive(true);
            foreach (Transform child in level4.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 5)
        {
            level4.SetActive(false);
            level5.SetActive(true);
            foreach (Transform child in level5.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 6)
        {
            level5.SetActive(false);
            level6.SetActive(true);
            level6.transform.rotation = Quaternion.Euler(0, 0, 0);
            foreach (Transform child in level6.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 7)
        {
            level6.SetActive(false);
            level7.SetActive(true);
            level6.transform.rotation = Quaternion.Euler(0, 0, 0);
            foreach (Transform child in level7.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 8)
        {
            level7.SetActive(false);
            level8.SetActive(true);
            foreach (Transform child in level8.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 9)
        {
            level8.SetActive(false);
            level9.SetActive(true);
            foreach (Transform child in level9.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 10)
        {
            level9.SetActive(false);
            level10.SetActive(true);
            foreach (Transform child in level10.transform)
            {
                if (child.name == "blackOrb")
                {
                    child.GetComponent<BlackOrb>().collected = false;
                }
                child.GetComponent<StartPosition>().StartPos();
            }
        }
        if (level == 11)
        {
            level10.SetActive(false);
            level11.SetActive(true);
            foreach (Transform child in level11.transform)
            {
                if (child.name == "blackOrb")
                {
                    child.GetComponent<BlackOrb>().collected = false;
                }
                child.GetComponent<StartPosition>().StartPos();
                if (child.name == "Glass")
                {
                    foreach(Transform grandChild in child)
                    {
                        if (grandChild.name != "Streaks")
                        {
                            grandChild.GetComponent<FloatingOrb>().collected = false;
                            grandChild.gameObject.SetActive(false);
                        }
                    }
                }
                if (child.name == "WhiteOrb")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
        if (level == 12)
        {
            level11.SetActive(false);
            level12.SetActive(true);
            foreach (Transform child in level12.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
                if (child.name == "Glass")
                {
                    foreach (Transform grandChild in child)
                    {
                        if (grandChild.name != "Streaks")
                        {
                            grandChild.GetComponent<FloatingOrb>().collected = false;
                            grandChild.gameObject.SetActive(false);
                        }
                    }
                }
                if (child.name == "WhiteOrb")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
        if (level == 13)
        {
            level12.SetActive(false);
            level13.SetActive(true);
            foreach (Transform child in level13.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
                if (child.name == "Glass")
                {
                    foreach (Transform grandChild in child)
                    {
                        if (grandChild.name != "Streaks")
                        {
                            grandChild.GetComponent<FloatingOrb>().collected = false;
                            grandChild.gameObject.SetActive(false);
                        }
                    }
                }
                if (child.name == "WhiteOrb")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
        if (level == 14)
        {
            level13.SetActive(false);
            level14.SetActive(true);
            level14.transform.rotation = Quaternion.Euler(0, 0, 0);
            foreach (Transform child in level14.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
                if(child.name == "blackOrb")
                {
                    child.GetComponent<BlackOrb>().collected = false;
                }
                if (child.name == "Glass")
                {
                    foreach (Transform grandChild in child)
                    {
                        if (grandChild.name != "Streaks")
                        {
                            grandChild.GetComponent<FloatingOrb>().collected = false;
                            grandChild.gameObject.SetActive(false);
                        }
                    }
                }
                if (child.name == "WhiteOrb")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
        if (level == 15)
        {
            level14.SetActive(false);
            level15.SetActive(true);
            foreach (Transform child in level15.transform)
            {
                child.GetComponent<StartPosition>().StartPos();
                if (child.tag == "Orb")
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                    child.GetComponent<Collider>().enabled = true;
                    foreach (Transform grandChild in child)
                    {
                        if (grandChild.name == "Particle System")
                        {
                            grandChild.GetComponent<ParticleSystem>().Play();
                        }
                        else
                        {
                            grandChild.GetComponent<Light>().intensity = 3;
                        }
                    }
                }
                if (child.name == "Glass")
                {
                    foreach (Transform grandChild in child)
                    {
                        if (grandChild.name != "Streaks")
                        {
                            grandChild.GetComponent<FloatingOrb>().collected = false;
                            grandChild.gameObject.SetActive(false);
                        }
                    }
                }
                if (child.name == "WhiteOrb")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}