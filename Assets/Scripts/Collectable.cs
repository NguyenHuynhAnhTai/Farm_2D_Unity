using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float respawnTime = 60f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.numberOfCarrotSeeds++;
            
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
