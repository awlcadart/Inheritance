using System.Collections;
using UnityEngine;

public class PowerHealth : PowerUp
{

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "Player")
        {
            base.IncreaseHealth();
            audioLibrary.Play();
            StartCoroutine(DisableDelay());
            
        }

    }

    IEnumerator DisableDelay()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        base.PickUp();
    }
   
}
