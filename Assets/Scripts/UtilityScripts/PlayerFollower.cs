using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] Transform player;    
    [SerializeField] float followDistance = 1f;

    float TargetY;
    
    private void Update()
    {
        TargetY = player.position.y + followDistance;
        this.transform.position = new Vector2(0, TargetY);
    }
}
