using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeviceSignIn : MonoBehaviour
{
    public void SignInWithDevice()
    {
        UserAccountManager.Instance.SignInWithDevice();
    }
}
