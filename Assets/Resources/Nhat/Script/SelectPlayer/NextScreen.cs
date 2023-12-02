using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{
    // Hàm này sẽ được gọi khi nút được nhấn
    public void OnButtonPress()
    {
        Debug.Log("Đã bật");
        // Thay "NextScene" bằng tên của Scene bạn muốn chuyển đến
        SceneManager.LoadScene(4);
    }
}
