using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPickup : MonoBehaviour
{
    public GameObject stick, stickPickup,spaceInteract;
    //public GameObject stickPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(stickPickup);
            stick.SetActive(true);
            spaceInteract.SetActive(true);
            //StartCoroutine(SpaceActivate());
        }

    }

    /*private void FixedUpdate()
    {
        if (spaceInteract.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space");
                //spaceInteract.SetActive(false);
                Destroy(spaceInteract);
            }
        }
        
    }

    IEnumerator SpaceActivate()
    {
        spaceInteract.SetActive(true);
        yield return new WaitForSeconds(5f);
        spaceInteract.SetActive(false);
        //Destroy(spaceInteract);
    }*/
}
