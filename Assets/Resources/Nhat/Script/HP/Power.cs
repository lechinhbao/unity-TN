
using UnityEngine;
using UnityEngine.Events;

public class Power: MonoBehaviour
{
    [SerializeField] int currentMana;

    public Mana manaBar;

    private Animator animator;
    public int maxMana = 100;

    public float manaIncreaseInterval = 5f; // Thời gian để tăng thêm mana (10 giây trong trường hợp này)
    public void Start()
    {
        currentMana = maxMana;
        currentMana = 0; // Khởi tạo thanh mana từ 0
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

        // Kiểm tra xem mana có lớn hơn 0 không trước khi thực hiện hành động khi nhấn LeftShift
        if (currentMana > 10 && Input.GetKeyDown(KeyCode.Z))
        {
            TakeMana(10);
            Debug.Log("Sức mạnh phải lớn hơn 0");
        }

    }
}
