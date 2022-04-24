using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    private bool invoked = false;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player"){
            PlayerManager.isDead = true;
        }
    }
    private void Update() {
        if (!PlayerManager.isDead && !invoked){
            Invoke("destroyObstacle", Obstacles.obstacleDestroyTime);
            invoked = true;
        } else if (PlayerManager.isDead) {
            destroyObstacle();
        }
    }

    private void destroyObstacle(){
        Destroy(gameObject);
    }
}
