
using UnityEngine;
using UnityEngine.Events;

public class ManaScript : MonoBehaviour
{
    [SerializeField] int currentMana;

    public Mana manaBar;

    private Animator animator;
    public int maxMana = 100;

    public float manaIncreaseInterval = 5f; // Thời gian để tăng thêm mana (10 giây trong trường hợp này)
    public void Start()
    {
        currentMana = maxMana;
        manaBar.UpdateMana(currentMana, maxMana);
        animator = GetComponent<Animator>();

        InvokeRepeating("IncreaseMana", 0f, manaIncreaseInterval);
    }
    //Hồi mana
    void IncreaseMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += 5; // Tăng thêm 10 mana sau mỗi khoảng thời gian
            manaBar.UpdateMana(currentMana, maxMana);
        }
    }
    public void TakeMana(int mana)
    {
        currentMana -= mana;

        if (currentMana < 0)
        {
            currentMana = 0;
            //animator.ResetTrigger("Attack");
            animator.ResetTrigger("IsAttackExtra");
            animator.ResetTrigger("IsWalkAttack");
            animator.ResetTrigger("IsRunAttack");
            animator.ResetTrigger("IsBullet");

        }
        manaBar.UpdateMana(currentMana, maxMana);
    }
    //Cộng Mana khi ăn xu
    public void IncreaseMana(int amount)
    {
        currentMana += amount;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        manaBar.UpdateMana(currentMana, maxMana);
    }
    private void Update()
    {
    /*    if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeMana(5);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeMana(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeMana(5);
        }*/
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeMana(5);
        }
       
        }
    }
