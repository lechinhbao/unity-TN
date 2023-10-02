using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    PlayerScript playerScript;
    public int minDamage;
    public int maxDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript = collision.GetComponent<PlayerScript>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript = null;
            CancelInvoke();
        }
    }
    void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
       
    }
};