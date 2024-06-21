using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    public string collectableName;
    [SerializeField]
    public float respawnTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (collectableName == "Pumpkins")
            {
                player.numberOfPumpkins++;
            }
            else if (collectableName == "Beans")
            {
                player.numberOfBeans++;
            }

            gameObject.SetActive(false);

            RespawnManager.Instance.StartRespawnCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        gameObject.SetActive(true);
    }
}