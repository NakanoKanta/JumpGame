using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner2D : MonoBehaviour
{
    public GameObject prefab;           // �X�|�[��������v���n�u
    public int spawnCount = 10;         // �X�|�[�����鐔
    public float spawnRadius = 10f;     // �X�|�[���͈͂̔��a
    public float objectRadius = 0.5f;   // �I�u�W�F�N�g�̔��a�i�d�Ȃ�h�~�j
    public int maxAttemptsPerObject = 100; // �e�I�u�W�F�N�g�̍ő厎�s��

    private List<GameObject> grounds = new();

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            bool spawned = false;

            for (int attempt = 0; attempt < maxAttemptsPerObject; attempt++)
            {
                Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

                // �d�Ȃ�`�F�b�N
                Collider2D hit = Physics2D.OverlapCircle(randomPos, objectRadius);
                if (hit == null)
                {
                    var go =Instantiate(prefab, randomPos, Quaternion.identity);
                    spawned = true;
                    grounds.Add(go);
                    break; // ���������̂Ŏ���
                }
            }

            if (!spawned)
            {
                Debug.LogWarning($"�I�u�W�F�N�g {i + 1} �̃X�|�[���Ɏ��s���܂����i�ő厎�s�񐔂ɒB���܂����j");
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
