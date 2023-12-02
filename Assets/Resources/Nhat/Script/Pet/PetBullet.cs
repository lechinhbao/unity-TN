using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBullet : MonoBehaviour
{
    private bool isRight = true;
    public float damageAmount = 5.0f; // Adjust the damage amount as needed

    void Start()
    {
        // Call the Shoot method every 3 seconds, starting after 0 seconds
        InvokeRepeating("Shoot", 0.0f, 3.0f);
    }

    void Shoot()
    {
        // Find all game objects with the "Enemy" or "Boss" tag in the vicinity
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        // Combine the arrays
        GameObject[] allEnemies = new GameObject[enemies.Length + bosses.Length];
        enemies.CopyTo(allEnemies, 0);
        bosses.CopyTo(allEnemies, enemies.Length);

        // Iterate through each enemy and check distance
        foreach (GameObject enemy in allEnemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Adjust the distance threshold based on when you want the AI to start shooting
            float shootingRange = 5.0f; // Adjust this value as needed

            if (distance < shootingRange)
            {
                // Apply damage to the enemy
                // enemy.GetComponent<HealthScript>().TakeDamage(damageAmount);

                // Your shooting logic remains the same
                var x = transform.position.x + (isRight ? 0.5f : -0.5f);
                var y = transform.position.y;
                var z = transform.position.z;

                Vector3 enemyPosition = enemy.transform.position;
                Vector3 direction = (enemyPosition - new Vector3(x, y, z)).normalized;

                GameObject bullet = (GameObject)Instantiate(
                    Resources.Load("Nhat/PrefabsMagic/Blade"),
                    new Vector3(x, y, z),
                    Quaternion.identity
                );

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                bullet.GetComponent<Fire>().setIsRight(isRight);
            }
        }
    }
}
