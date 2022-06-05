using UnityEngine;

public class WinAreaManager : MonoBehaviour
{
    public DeathManager dm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            dm.StartWin();
    }
}
