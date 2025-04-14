using UnityEngine;

public class SpeedBuff : PowerUp
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            base.ProjectileSpeed();
            base.PickUp();
        }

    }

}
