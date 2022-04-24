using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public List<GameObject> Coin;
    public Transform InstansiatePosition;
    public float CoinsInstatiateTime = 3.0f;
    public float CoinsBetweenInstatiateTime = 0.1f;
    public TextMeshProUGUI Score1UI;
    public TextMeshProUGUI Score2UI;
    public TextMeshProUGUI Score3UI;
    private void Start() {
        StartCoroutine(nameof(CreateCoins));
    }
    private void Update()
    {
        SetScore((CoinsManager.yellowScore).ToString(), (CoinsManager.blueScore).ToString(), (CoinsManager.redScore).ToString());
    }
    IEnumerator CreateCoins()
    {
        while (!PlayerManager.isDead)
        {
            // Lowest Ranges (x=8, y=0.5, z=instaniate position)
            float x = Random.Range(-0.8f, 8.0f);
            float y = Random.Range(0.5f, 2.5f);
            if (x<4f){
                x = 1f;
            } else {
                x = 6f;
            }
            if (y<1.5f){
                y = 0.5f;
            } else {
                y = 2.2f;
            }
            int n = 1;
            int num = Random.Range(0, 3);
            if (num == 0)
                n = Random.Range(6, 10);
            else if (num == 1)
                n = Random.Range(4, 6);
            else {
                n = Random.Range(1, 4);
            }

            // Test
            Debug.Assert(num < 3);
            Debug.Assert(n > 0);
            Debug.Assert(y >= 0.5f && y<= 2.5f);
            Debug.Assert(x <= 8.0f && x>=-0.8f);

            for (int i=0; i<n; i++){
                Vector3 Rposition = new Vector3(x, y, InstansiatePosition.position.z);
                Instantiate(Coin[num], Rposition , Quaternion.identity);
                yield return new WaitForSeconds(CoinsBetweenInstatiateTime);
            }
            yield return new WaitForSeconds(CoinsInstatiateTime);
        }
    }

    public void SetScore(string score1, string score2, string score3)
    {
        Score1UI.text = score1;
        Score2UI.text = score2;
        Score3UI.text = score3;
    }
}
