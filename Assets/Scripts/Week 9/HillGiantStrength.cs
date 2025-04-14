using UnityEngine;

public class HillGiantStrength : PowerUp
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            base.AttackBuff();
            base.PickUp();
        }

    }
}
