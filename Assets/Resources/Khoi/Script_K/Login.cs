using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static UnityEngine.ParticleSystem;

public class Login : MonoBehaviour
{
    public TMP_InputField IpfAcc, IpfPass;
    public Button BtnLogin;
    public TMP_Text TxtError;
    public Selectable first;
    
    private EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        first.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            BtnLogin.onClick.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();
            if (next != null) next.Select();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnLeft();
            if (next != null) next.Select();
        }
    }
    public void CheckLogin()
    {
        var acc = IpfAcc.text;
        var pass = IpfPass.text;

        // gọi API
        if (acc.Equals("khoi") && pass.Equals("12345"))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            TxtError.text = "Login Failed";
        }
    }
}
