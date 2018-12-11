/* BonusManager.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Provide a manager handling bonus spawning in networked games.
/// </summary>
public class BonusManager : NetworkBehaviour
{
    // SPAWN POSITION //
    public float halfSize_X;
    public float halfSize_Y;
    public float radius;
    public float minZ;

    // SPAWN RATE //
    public float spawnInterval;

    // AVALAIBLE BONUSES
    public GameObject[] bonusList;


    /// <summary>
    /// Initializes a new instance of the <see cref="BonusManager"/> class.
    /// </summary>
    /// <remarks>It only calls <see cref="SpawnAllBonus"/> method as a Coroutine.</remarks>
    /// <seealso cref="Coroutine"/>
    void Start()
    {
        StartCoroutine(SpawnAllBonus());
	}

    /*
    void Update()
    {
        StartCoroutine(SpawnAllBonus());
    }
    */

    /// <summary>
    /// Handle the bonuses spawn in a randow way.
    /// </summary>
    /// <returns>A temporary suspension of the StartCoroutine method.</returns>
    /// <seealso cref="YieldInstruction"/>
    /// <seealso cref="Coroutine"/>
    IEnumerator SpawnAllBonus()
    {
        while (true)
        {
            // SPAWN POSITION //
            Vector2 spawnPosition = new Vector2(Random.Range(-halfSize_X, halfSize_X), Random.Range(-halfSize_Y, halfSize_Y));
            Collider2D other = Physics2D.OverlapCircle(spawnPosition, radius, Physics2D.AllLayers, minZ);
            if (other != null) continue;

            // BONUS CHOICE //
            int i = Random.Range(0, bonusList.Length);
            Instantiate(bonusList[i], spawnPosition, Quaternion.identity);
            //Network.spawn(bonusList[i]);

            // WAIT FOR NEXT BONUS //
            yield return new WaitForSeconds(spawnInterval);
            
        }
    }
}
