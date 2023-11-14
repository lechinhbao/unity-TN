using UnityEngine;
using UnityEngine.UI;

public class SelfDestruct : MonoBehaviour
{
    public float destructTime;
    private float timer;

    private void Start()
    {
        timer = destructTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
