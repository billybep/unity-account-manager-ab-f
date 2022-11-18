using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AccelByte SDK
using AccelByte.Api;
using AccelByte.Models;
using AccelByte.Core;

public class UserAccountManager : MonoBehaviour
{
    public static UserAccountManager Instance;

    [System.Obsolete]
    void Start()
    {
        //SignIn("user@example.net", "SuperPassword");
        SignInWithDevice();
    }

    void Awake()
    {
        Instance = this;
    }

    private static void OnRegister(Result<UserData> result)
    {
        if (result.IsError)
        {
            Debug.Log("Register failed:");
        }
        else
        {
            Debug.Log("Register successful.");
        }
    }

    public void CreateAccount(string username, string password, string emailAddress)
    {
        Debug.Log("Create Account");
        Debug.Log(username);
        Debug.Log(password);
        Debug.Log(emailAddress);
    }

    [System.Obsolete]
    public void SignIn(string username, string password)
    {
        //Debug.Log("Siggn ini");
        //Debug.Log(username);
        //Debug.Log(password);

        // Grab a current User reference, even if it has not logged in yet.
        //User user = AccelBytePlugin.GetUser();

        User user = AccelBytePlugin.GetUser();

        //var aaa = JsonUtility.ToJson(user, true);

        //Debug.Log("----------");
        //Debug.Log(aaa, this);
        //Debug.Log("----------");

        // Call the Login Function and supplying a asynchronous callback to act based upon success or failure
        /*
        user.LoginWithUsername(
            username,
            password,
            result =>
            {
                if (result.IsError)
                {
                    // Print the Error Code and Message if error happened
                    Debug.Log($"Login failed : {result.Error.Code}: {result.Error.Message}");

                    var test = JsonUtility.ToJson(result, true);
                    Debug.Log(test);
                }
                else
                {
                    Debug.Log("Login successful");
                }
            });

        Debug.Log("adsfasdfasdfads!!!");
        */
    }

    void GetDeviceID(out string ios_id, out string android_id, out string custom_id)
    {
        ios_id = string.Empty;
        android_id = string.Empty;
        custom_id = string.Empty;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            ios_id = UnityEngine.iOS.Device.vendorIdentifier;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Android");
        }
        else
        {
            custom_id = SystemInfo.deviceUniqueIdentifier;
            Debug.Log("Login With Custom Device Id");
            Debug.Log(custom_id);
        }
    }

    void SignInWithDevice()
    {
        GetDeviceID(out string ios_id, out string android_id, out string custom_id);

        if (!string.IsNullOrEmpty(ios_id))
        {
            // OnProgress
        }
        else if (!string.IsNullOrEmpty(android_id))
        {
            // OnProgress
        }
        else if (!string.IsNullOrEmpty(custom_id))
        {
            User user = AccelBytePlugin.GetUser();

            user.LoginWithDeviceId((Result<TokenData, OAuthError> result) => {
                Debug.Log("Sign With Device Custom!!!");
            });
        }
    }
}
