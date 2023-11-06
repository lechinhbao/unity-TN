using UnityEngine;
using UnityEngine.UI;

public class Self: MonoBehaviour
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
