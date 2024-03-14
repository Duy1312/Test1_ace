using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeLine : MonoBehaviour
{
    [SerializeField] private PlayableDirector[] playableDirector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -10f));
            if (SkinController.Instance.isDefaultPurchased)
            {

                PlayerDirector(playableDirector[0]);
            }
            else if ( SkinController.Instance.isBeautyPurchased)
            {

                PlayerDirector(playableDirector[1]);

            }
            else if ( SkinController.Instance.isGodPurchased)
            {
              
                PlayerDirector(playableDirector[2]);

            }
            else
            {

                PlayerDirector(playableDirector[0]);
            }
        }
         
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 1f;

        }
    }
    private void PlayerDirector(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
