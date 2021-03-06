using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class Login : MonoBehaviour
{
    [SerializeField]
    TMP_InputField UserIDInput;
    public void OnLoginPressed()
    {
        if(string.IsNullOrEmpty(UserIDInput.text) == false)
        {
            UserProfile.UserID = UserIDInput.text;
        }       
        StartCoroutine(WaitAndLoad());

    }

    public GameObject HomePage;
    IEnumerator WaitAndLoad()
    {
        Loading.ShowLoading("Logging In");
        yield return new WaitForSeconds(Random.Range(0.5f,4.5f));
        Loading.CloseLoading();
        HomePage.SetActive(true);
        gameObject.SetActive(false);

        UnityEngine.Debug.Log("Login Success, UserID: " + UserProfile.UserID);
    }

    public void Kill_IE()
    {

        System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("IEXPLORE");

        foreach (Process p in ps)
        {
            if (!p.HasExited)
                {
                    p.Kill();
                }
            
        }
    }

    public void OnSigninWithGoogleClicked()
    {
        //var newWindow = "window.open('https://wefoodiestest2.auth.us-west-2.amazoncognito.com/login?client_id=1dhvrvbcd6kfp3dp54h9j3kppi&response_type=code&scope=aws.cognito.signin.user.admin+email+openid+phone+profile&redirect_uri=https://www.google.com', 'Google')";
        Application.OpenURL("https://wefoodiestest2.auth.us-west-2.amazoncognito.com/login?client_id=1dhvrvbcd6kfp3dp54h9j3kppi&response_type=code&scope=aws.cognito.signin.user.admin+email+openid+phone+profile&redirect_uri=https://www.google.com");
        //Application.ExternalEval(newWindow); //newWindow.close();
       // StartCoroutine(Kill_IE());
        StartCoroutine(WaitAndLoad());
    }
}
