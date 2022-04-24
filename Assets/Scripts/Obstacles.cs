using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<GameObject> obstacle;
    public Transform InstansiatePosition;
    public float ObstacleInstatiateTime = 3.0f;
    public static float obstacleDestroyTime = 8.0f;
    int i = 0;
    float x = 6;
    float y = 0.5f;

    private void Start() {
        StartCoroutine(nameof(CreateObstacles));
        Obstacles.obstacleDestroyTime = 8f;
    }

    IEnumerator CreateObstacles()
    {
        while (!PlayerManager.isDead)
        {
            yield return new WaitForSeconds(ObstacleInstatiateTime);
            int num = Random.Range(0, 3);
            for (int j=0; j<2; j++)
            {
                switch(i%2){
                        case 0: {
                            x = 6;
                            num++;
                            if (num>2)
                                num = 0;
                            switch(num){
                                case 0: {
                                    y = 0.5f;
                                    break;
                                }
                                case 1: {
                                    y = 1.25f;
                                    break;
                                }
                                case 2: {
                                    y = 3f;
                                    break;
                                }
                            }
                            break;
                        } 
                        case 1: {
                            x = 1;
                            num++;
                            if (num>2)
                                num = 0;
                            switch(num){
                                case 0: {
                                    y = 0.5f;
                                    break;
                                }
                                case 1: {
                                    y = 1.25f;
                                    break;
                                }
                                case 2: {
                                    y = 3f;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                // Test
                Debug.Assert(num < 3);

                Vector3 Rposition = new Vector3(x, y, InstansiatePosition.position.z);
                Instantiate(obstacle[num], Rposition , Quaternion.identity);
                i++;
                // Test
                Debug.Assert(y >= 0.5f && y<= 3f);
                Debug.Assert(x <= 8.0f && x>=-0.8f);
            }

        }
    }
}
