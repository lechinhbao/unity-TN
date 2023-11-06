
using UnityEngine;
using UnityEngine.Events;

public class ManaScript : MonoBehaviour
{
    [SerializeField] int maxMana;
    [SerializeField] int currentMana;

    [SerializeField] public Mana manaBar;

    private Animator animator;
    public void Start()
    {
        currentMana = maxMana;
        manaBar.UpdateMana(currentMana, maxMana);
        animator = GetComponent<Animator>();

    }
    public void TakeMana(int mana)
    {
        currentMana -= mana;

        if (currentMana < 0)
        {
            Debug.Log("oke nha");
            currentMana = 0;
            //animator.ResetTrigger("Attack");
            animator.ResetTrigger("IsAttackExtra");
            animator.ResetTrigger("IsWalkAttack");
            animator.ResetTrigger("IsRunAttack");
        }
        manaBar.UpdateMana(currentMana, maxMana);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeMana(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeMana(5);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeMana(5);
        }
    }
}
