using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 100f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}
