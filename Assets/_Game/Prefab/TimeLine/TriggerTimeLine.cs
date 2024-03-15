using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeLine : MonoBehaviour
{
    [SerializeField] PointEnd[] pointGameobject;
    [SerializeField] private PlayableDirector[] playableDirector;
    bool shouldDisableColliders = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var p in pointGameobject)
        {
            if (p.isCollect)
            {
                shouldDisableColliders = true;
                break;
            }
        }

        if (shouldDisableColliders)
        {
            foreach (var p in pointGameobject)
            {
                p.GetComponent<Collider2D>().enabled = false;
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
   


            if (SkinController.Instance.isDefaultPurchased)
            {
                StartCoroutine(PlayerDirector(playableDirector[0]));
            }
            else if (SkinController.Instance.isBeautyPurchased)
            {
                StartCoroutine(PlayerDirector(playableDirector[1]));

            }
            else if (SkinController.Instance.isGodPurchased)
            {

                StartCoroutine(PlayerDirector(playableDirector[2]));

            }
            else
            {

                StartCoroutine(PlayerDirector(playableDirector[0]));
            }
        }
    }
    
    IEnumerator  PlayerDirector(PlayableDirector playableDirector)
    {
        yield return new WaitForSeconds(1f);
        playableDirector.Play();
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
