using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour {

    public RoomManager p;

    public int nRoom;

    void Start()
    {

        p = p.GetComponent<RoomManager>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            p.curRoom = nRoom;
            p.nextRoom = true;

        }

    }
}
