
using UnityEngine;
using UnityEngine.Events;

public class ManaScript : MonoBehaviour
{
    [SerializeField] int maxMana;
    int currentMana;

    public Mana manaBar;

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
<<<<<<< HEAD:Assets/Resources/Nhat/Script/ManaScript.cs
            Debug.Log("oke nha");
            currentMana = 0;
            //animator.ResetTrigger("Attack");
=======
            currentMana = 0;
            animator.ResetTrigger("Attack");
>>>>>>> Vien:Assets/Resources/Image/vien/cript/ManaScript.cs
            animator.ResetTrigger("PlayerAttackExtra");
        }
        manaBar.UpdateMana(currentMana, maxMana);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            TakeMana(5);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeMana(5);
        }
        }
}
