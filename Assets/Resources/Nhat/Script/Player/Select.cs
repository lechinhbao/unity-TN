using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public static Select instance;

    public GameObject[] characters; // Mảng chứa tất cả các nhân vật
    private int currentCharacterIndex = 0;

    void Awake()
    {
        // Singleton pattern để đảm bảo chỉ có một đối tượng quản lý
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadSelectedCharacter();
    }

    void Update()
    {
        // Kiểm tra nút hoặc sự kiện để chuyển nhân vật
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeCharacter(-1); // Chuyển sang nhân vật trước đó
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeCharacter(1); // Chuyển sang nhân vật tiếp theo
        }
    }

    void ChangeCharacter(int offset)
    {
        // Vô hiệu hóa nhân vật hiện tại
        characters[currentCharacterIndex].SetActive(false);

        // Tăng hoặc giảm chỉ số nhân vật hiện tại
        currentCharacterIndex = (currentCharacterIndex + offset + characters.Length) % characters.Length;

        // Kích hoạt nhân vật mới
        characters[currentCharacterIndex].SetActive(true);

        // Lưu trạng thái nhân vật được chọn
        SaveSelectedCharacter();
    }

    void SaveSelectedCharacter()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
    }

    void LoadSelectedCharacter()
    {
        // Kiểm tra xem đã lưu trạng thái nhân vật nào được chọn trước đó chưa
        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter");
            characters[currentCharacterIndex].SetActive(true);
        }
        else
        {
            // Nếu chưa có lưu trạng thái, mặc định chọn nhân vật đầu tiên
            characters[currentCharacterIndex].SetActive(true);
        }
    }

    public void LoadNextScene()
    {
        // Lưu trạng thái nhân vật trước khi chuyển màn
        SaveSelectedCharacter();

        // Chuyển màn
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
