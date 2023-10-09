using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerB : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isRight;
    [SerializeField] private GameObject Hieffect;

    void Start()
    {
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((isRight ? Vector3.right : Vector3.left) * Time.deltaTime *5f);

    }

    public void setIsRoght(bool isRight)
    {
        this.isRight = isRight;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject eff = Instantiate(Hieffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(eff,0.5f);
    }


}
