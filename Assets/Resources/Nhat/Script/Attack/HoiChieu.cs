using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HoiChieu : MonoBehaviour
{
    private bool isRight = true;
    public Button iconChieu;            // Biểu tượng đánh chiêu
    public float thoiGianHoiChieu = 5f; // Thời gian giữa các lần hồi chiêu
    public int mucDoHoiChieu = 1;       // Số lượng chiêu được hồi mỗi lần

    private int soLuongChieuHienTai;    // Số lượng chiêu hiện tại
    private bool coTheHoiChieu = true;  // Cờ cho biết có thể hồi chiêu hay không

    void Start()
    {
        soLuongChieuHienTai = 0;

        // Gán hàm xử lý sự kiện khi nhấn vào biểu tượng
        iconChieu.onClick.AddListener(NhanVaoIconChieu);
    }

    void NhanVaoIconChieu()
    {
        if (coTheHoiChieu)
        {
                var x = transform.position.x + (isRight ? 0.5f : -0.5f);
                var y = transform.position.y;
                var z = transform.position.z;

                GameObject gameObject = (GameObject)Instantiate(
                Resources.Load("Nhat/PrefabsBullet/Phitieu"),
                new Vector3(x, y, z),
                Quaternion.identity
                );
                gameObject.GetComponent<Fire>().setIsRight(isRight);
            
            // Gọi coroutine để hồi chiêu
            StartCoroutine(HoiChieuTuDong());
        }
        else
        {
            Debug.Log("Chưa thể hồi chiêu. Đợi thêm một chút!");
        }
    }

    IEnumerator HoiChieuTuDong()
    {
        // Đặt cờ không thể hồi chiêu
        coTheHoiChieu = false;

        // Chờ đợi thời gian giữa các lần hồi chiêu
        yield return new WaitForSeconds(thoiGianHoiChieu);

        // Hồi chiêu với số lượng được đặt trong mucDoHoiChieu
        soLuongChieuHienTai += mucDoHoiChieu;

        // In thông báo hoặc thực hiện các hành động khác tại đây
        Debug.Log("Đã hồi " + mucDoHoiChieu + " chiêu. Số lượng chiêu hiện tại: " + soLuongChieuHienTai);

        // Đặt cờ có thể hồi chiêu trở lại
        coTheHoiChieu = true;
    }

}
