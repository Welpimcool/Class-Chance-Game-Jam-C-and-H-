using UnityEngine;

public class Billboarding : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x,0f,0f);
    }
}
