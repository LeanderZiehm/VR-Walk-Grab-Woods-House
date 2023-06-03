using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

        [SerializeField] private TimeDisplay timeDisplay;
         [SerializeField] private GameObject playerObject,endCanvas;
         //[SerializeField] private TimeDisplay timeDisplay;

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Player"))
        {
            playerObject.SetActive(false);
            endCanvas.SetActive(true);
            SoundManager.instance.PlaySound(Sound.door);
               timeDisplay.DisplayTime();
        }
    }
}
