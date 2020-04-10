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
    }
    public void BuildLevel(int level)
    {
        player.StartPos();
        if (level == 1)
        {
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
                child.GetComponent<StartPosition>().StartPos();
            }
        }
    }
}
