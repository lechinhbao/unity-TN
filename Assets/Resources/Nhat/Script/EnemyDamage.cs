using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyDamage : MonoBehaviour
{
    public float left, right;
    public GameObject monster;

    void Update()
    {
        var monsterX = monster.transform.position.x;
        var monsterY = monster.transform.position.y;

        var cameraX = transform.position.x;
        var cameraY = transform.position.y;

        if (monsterX > left && monsterX < right)
        {
            cameraX = monsterX;
        }
        else
        {
            if (cameraX < left) cameraX = left;
            if (cameraX > right) cameraX = right;
        }
        if (monsterY > 0)
        {
            cameraY = monsterY;
        }
        else
        {
            cameraY = 0;
        }


        transform.position = new Vector3(cameraX, cameraY, -8);
    }
}
