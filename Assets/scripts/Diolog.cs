

using UnityEngine;

public class Diolog : MonoBehaviour
{
    public GameObject EnterDiolog;
 /// <summary>
 /// OnTriggerEnter is called when the Collider other enters the trigger.
 /// </summary>
 /// <param name="other">The other Collider involved in this collision.</param>
 void OnTriggerEnter2D(Collider2D other)
 {
     if(other.tag == "Player"){
         EnterDiolog.SetActive(true);
     }
 }
 /// <summary>
 /// Sent when another object leaves a trigger collider attached to
 /// this object (2D physics only).
 /// </summary>
 /// <param name="other">The other Collider2D involved in this collision.</param>
 void OnTriggerExit2D(Collider2D other)
 {
     if(other.tag == "Player"){
         EnterDiolog.SetActive(false);
     }
 }
}
