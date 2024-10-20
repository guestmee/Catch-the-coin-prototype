using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsystem : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "plane") { return; }
        EVENTSYSTEM EVENTSYSTEM = GameObject.Find("EVENTSYSTEM").GetComponent<EVENTSYSTEM>();
        EVENTSYSTEM.EndGame(collision.transform.name, collision.gameObject);
    }
}
