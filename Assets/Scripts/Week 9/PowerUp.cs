using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
public enum PowerColor
{
    Blue,
    Red,
    Yellow
}
public class PowerUp : MonoBehaviour

{
    protected PlayerRPG player;
    public PowerColor powercolor;
    public AudioSource audioLibrary;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerRPG>();
        if (powercolor == PowerColor.Blue)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (powercolor == PowerColor.Red)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (powercolor == PowerColor.Yellow)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    
    // Update is called once per frame
    
    protected void IncreaseHealth()
    {
        player.health += 10;
        player.healthbar.text = "health" + player.health;
    }
     protected void ProjectileSpeed()
    {
        player.projectileForce += 100;

    }
    
    protected void AttackBuff()
    {
        player.attackDamage += 20;
    }
    public virtual void PickUp()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.SetActive(false);
    }

}


