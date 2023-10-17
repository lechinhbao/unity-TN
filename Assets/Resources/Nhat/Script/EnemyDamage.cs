using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var name = collision.gameObject.tag;
        if (name.Equals("Monster"))
        {

            Destroy(collision.gameObject);

        }
    }
}
