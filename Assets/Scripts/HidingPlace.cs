using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public void OnInteract()
    {
        PlayerManager.Instance.Hidden = !PlayerManager.Instance.Hidden;
        PlayerManager.Instance.transform.position = this.transform.GetChild(0).transform.position;
        Debug.Log("Hidden");
    }
}