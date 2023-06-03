using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject door;
        [SerializeField] private GameObject endGameTrigger;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Player"))
        {
            Debug.Log("Touched by Player");
            SoundManager.instance.PlaySound(Sound.key);
            SoundManager.instance.PlaySound(Sound.door);
            door.SetActive(false);
            endGameTrigger.SetActive(true);
            gameObject.SetActive(false);
         
          //  SoundManager.instance.PlaySound(Sound.door);
        }
    }
}
