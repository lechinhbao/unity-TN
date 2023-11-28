using UnityEngine;

public class BossScript1 : StateMachineBehaviour
{
    Transform target;
    Transform borderCheck;
    bool hasHitPlayer = false; // Biến kiểm tra xem Boss đã chạm vào Player chưa

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        borderCheck = animator.GetComponent<Boss>().borderCheck;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
            return;

        if (!hasHitPlayer)
        {
            float distance = Vector2.Distance(target.position, animator.transform.position);
            if (distance < 4)
            {
                animator.SetBool("IsWalk", true);
            }

            // Kiểm tra xem enemy có chạm vào player không
            Collider[] hitColliders = Physics.OverlapSphere(animator.transform.position, 1.0f);
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // Dừng game khi Boss chạm vào Player
                    Time.timeScale = 0f;
                    hasHitPlayer = true; // Đánh dấu là Boss đã chạm vào Player
                    animator.SetBool("Hurt", true);
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Time.timeScale = 1f; // Khôi phục tốc độ thời gian khi ra khỏi trạng thái
    }
}
