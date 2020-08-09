using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;
    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            player.Damage();
        }
        CharacterController cc = other.GetComponent<CharacterController>();
        if(cc != null)
        {
            cc.enabled=false;
        }
        if(other.tag == "Player")
        {
            other.transform.position = _respawnPoint.transform.position;
            StartCoroutine(CCEnabledRoutine(cc));
        }    
    }
    IEnumerator CCEnabledRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
