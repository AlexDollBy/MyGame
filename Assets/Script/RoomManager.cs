using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{

    public int curRoom;
    public int r = 10;
    public bool nextRoom;
    public Rigidbody2D Player;
    public Transform[] platfotm1;
    public Transform[] platfotm2;
    public Transform[] platfotm3;
    public GameObject[] coin1;
    public GameObject[] coin2;
    public GameObject[] coin3;

    public Transform r1, r2, r3;

    void Start()
    {
        
        PlatformGeniration.generate = true;
        PlatformGeniration.GenerateStart(platfotm1,coin1);

        PlatformGeniration.GenerateStart(platfotm2,coin2);

        PlatformGeniration.GenerateStart(platfotm3,coin3);

        PlatformGeniration.generate = false;
        nextRoom = false;

        Player.position = new Vector2(platfotm1[0].position.x, platfotm1[0].position.y + 10);
    }
    void Update()
    {
        SelectNextRoom();

    }
    
   
    
    void SelectNextRoom()
    {
        if (nextRoom)
        {

            if (curRoom == 1)
            {

                r2.position = new Vector2(r1.position.x + r, r1.position.y);
                r3.position = new Vector2(r2.position.x + r, r2.position.y);
                PlatformGeniration.generate = true;
                PlatformGeniration.GenerateStart(platfotm2,coin2);
                PlatformGeniration.GenerateStart(platfotm3,coin3);
                PlatformGeniration.generate = false;
                nextRoom = false;


            }
            else if (curRoom == 2)
            {

                r3.position = new Vector2(r2.position.x + r, r2.position.y);

                r1.position = new Vector2(r3.position.x + r, r3.position.y);

                PlatformGeniration.generate = true;
                PlatformGeniration.GenerateStart(platfotm3,coin3);
                PlatformGeniration.GenerateStart(platfotm1,coin1);
                PlatformGeniration.generate = false;
                nextRoom = false;

            }
            else
            if (curRoom == 3)
            {
                r1.position = new Vector2(r3.position.x + r, r3.position.y);

                r2.position = new Vector2(r1.position.x + r, r1.position.y);

                PlatformGeniration.generate = true;
                PlatformGeniration.GenerateStart(platfotm1,coin1);
                PlatformGeniration.GenerateStart(platfotm2,coin2);
                PlatformGeniration.generate = false;
                nextRoom = false;
            }

        }


    }


}
