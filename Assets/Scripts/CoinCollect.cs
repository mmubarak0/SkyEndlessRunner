using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        int[] coinScore = CoinsManager.coinsScore;
        if (other.gameObject.tag == "Player"){
            if (gameObject.tag == "redCoin"){
                CoinsManager.redScore += coinScore[0];
                CoinsManager.Score += coinScore[0];
            }
            else if (gameObject.tag == "blueCoin"){
                CoinsManager.blueScore += coinScore[2];
                CoinsManager.Score += coinScore[2];
            }
            else if (gameObject.tag == "yellowCoin"){
                CoinsManager.yellowScore += coinScore[1];
                CoinsManager.Score += coinScore[1];
            }
            Destroy(gameObject);
        }
        // Debug.Log(CoinsManager.GetComponent<Coins>().Score);
    }
    private void Update() {
        if (!PlayerManager.isDead){
            Invoke("destroyCoins", 6.0f);
        } else {
            destroyCoins();
        }
    }

    private void destroyCoins(){
        Destroy(gameObject);
    }

}
