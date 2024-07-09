using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    public string collectableName;
    [SerializeField]
    public float respawnTime;

    public CollectibleType type;
    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
            RespawnManager.Instance.StartRespawnCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        gameObject.SetActive(true);
    }

    public enum CollectibleType
    {
        NONE,
        PUMPKIN,
        BEAN
    }
}