using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner2D : MonoBehaviour
{
    public GameObject prefab;           // スポーンさせるプレハブ
    public int spawnCount = 10;         // スポーンする数
    public float spawnRadius = 10f;     // スポーン範囲の半径
    public float objectRadius = 0.5f;   // オブジェクトの半径（重なり防止）
    public int maxAttemptsPerObject = 100; // 各オブジェクトの最大試行回数

    private List<GameObject> grounds = new();

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            bool spawned = false;

            for (int attempt = 0; attempt < maxAttemptsPerObject; attempt++)
            {
                Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

                // 重なりチェック
                Collider2D hit = Physics2D.OverlapCircle(randomPos, objectRadius);
                if (hit == null)
                {
                    var go =Instantiate(prefab, randomPos, Quaternion.identity);
                    spawned = true;
                    grounds.Add(go);
                    break; // 成功したので次へ
                }
            }

            if (!spawned)
            {
                Debug.LogWarning($"オブジェクト {i + 1} のスポーンに失敗しました（最大試行回数に達しました）");
            }
        }
    }

/*#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (grounds.Count > 0)
        {
            foreach (var go in grounds)
            {
                var pos = go.transform.position;
                Gizmos.DrawWireSphere(pos, spawnRadius);
            }
        }
    }
#endif*/
}
