using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeniration : MonoBehaviour
{

    public Transform[] platforms;
    public GameObject[] coins;
    public static bool generate;


    void Start()
    {

    }

    public static void GenerateStart(Transform[] pl, GameObject[] co)
    {
        if (generate)
        {
            for (int i = 0; i < pl.Length; i++)
            {
                Vector2 px1, px2, p, c;
                px1 = new Vector2(pl[i].position.x, -10);
                px2 = new Vector2(pl[i].position.x, 10);
                p = new Vector2(pl[i].position.x, Random.Range(px1.y, px2.y));
                c = new Vector2(p.x, p.y + 3);
                pl[i].position = p;
                co[i].SetActive(true);
                co[i].transform.position = c;
            }
        }

    }

}
