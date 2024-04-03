using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Ensure this is included for working with UI elements like Image

public class DefendSystem : MonoBehaviour
{
    [SerializeField] public GameObject[] rows; // Holds the rows player can move to
    [SerializeField] public GameObject[] spawns;
    [SerializeField] public Image avatar; // Reference to the UI Image component of the avatar

    [SerializeField] public float macroSpawnInterval = 2f;
    public float microSpawnInterval = 2f;
    public int numberPerMicroInterval;
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public ProjectileMovement projectileMovement;

    public Vector3[] rowPositions;
    public Vector3[] spawnPositions;

    public float macroSpawnTimer = 0;
    public float microSpawnTimer = 0;
    public int numberMicroThrown;

    public int currentRowIndex = 1; // Start from the middle row
    public float switchCooldown = 0.1f; // Time player must wait before switching rows again
    public float switchTimer; // Tracks time since last row switch
    public int numberOfAttacks;
    public int numberThrown;
    public float speed;
    public int attackPattern;
    public Attack attack;

    public void Start() {
        rowPositions = new Vector3[3];
        spawnPositions = new Vector3[3];
        rowPositions[0] = rows[0].GetComponent<RectTransform>().anchoredPosition;
        rowPositions[1] = rows[1].GetComponent<RectTransform>().anchoredPosition;
        rowPositions[2] = rows[2].GetComponent<RectTransform>().anchoredPosition;
        spawnPositions[0] = spawns[0].transform.position;
        spawnPositions[1] = spawns[1].transform.position;
        spawnPositions[2] = spawns[2].transform.position;
        Console.WriteLine("initialized");
    }

    public void MoveToRow(int rowIndex)
    {
        currentRowIndex = rowIndex;
        Console.Write(rowPositions.Length);
        Vector3 newPosition = rowPositions[currentRowIndex];
        
        newPosition.x = -300;
        avatar.rectTransform.anchoredPosition = newPosition; // Set the new position
        switchTimer = 0; // Reset cooldown timer
    }

    public void SpawnSingleProjectile()
    {
        numberThrown++;
        // Choose a random row for spawning
        int rowIndex = UnityEngine.Random.Range(0, rows.Length);
        Vector3 spawnPosition = spawnPositions[rowIndex]; // Adjust Y value as needed
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Destroy(newProjectile, 5f);
    }

    public void SpawnDoubleProjectile()
    {
        numberThrown++;
        // Choose a random row for spawning
        int rowIndex1 = UnityEngine.Random.Range(0, rows.Length);
        int rowIndex2 = rowIndex1;
        while (rowIndex2 == rowIndex1) {
            rowIndex2 = UnityEngine.Random.Range(0, rows.Length);
        }
        Vector3 spawnPosition1 = spawnPositions[rowIndex1]; // Adjust Y value as needed
        Vector3 spawnPosition2 = spawnPositions[rowIndex2]; // Adjust Y value as needed
        GameObject newProjectile1 = Instantiate(projectilePrefab, spawnPosition1, Quaternion.identity);
        GameObject newProjectile2 = Instantiate(projectilePrefab, spawnPosition2, Quaternion.identity);
        Destroy(newProjectile1, 5f);
        Destroy(newProjectile2, 5f);
    }

    public IEnumerator SpawnBurstProjectile()
    {
        numberThrown++;
        // Choose a random row for spawning
        int rowIndex1 = UnityEngine.Random.Range(0, rows.Length);
        int rowIndex2 = rowIndex1;
        while (rowIndex2 == rowIndex1) {
            rowIndex2 = UnityEngine.Random.Range(0, rows.Length);
        }
        int rowIndex3 = rowIndex2;
        while (rowIndex3 == rowIndex2 || rowIndex3 == rowIndex1) {
            rowIndex3 = UnityEngine.Random.Range(0, rows.Length);
        }

        Vector3 spawnPosition1 = spawnPositions[rowIndex1]; // Adjust Y value as needed
        Vector3 spawnPosition2 = spawnPositions[rowIndex2]; // Adjust Y value as needed
        Vector3 spawnPosition3 = spawnPositions[rowIndex3]; // Adjust Y value as needed
        GameObject newProjectile1 = Instantiate(projectilePrefab, spawnPosition1, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject newProjectile2 = Instantiate(projectilePrefab, spawnPosition2, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject newProjectile3 = Instantiate(projectilePrefab, spawnPosition3, Quaternion.identity);
        Destroy(newProjectile1, 5f);
        Destroy(newProjectile2, 5f);
        Destroy(newProjectile3, 5f);
    }

    public void SetDifficulty(int numberOfAttacks, float speed, (float,float,int) frequency, EnemyAttack attack) {
        this.numberOfAttacks = numberOfAttacks;
        projectileMovement.speed = speed;
        this.attack = attack;
        this.numberThrown = 0;
        this.numberMicroThrown = 0;
        this.macroSpawnInterval = frequency.Item1;
        this.microSpawnInterval = frequency.Item2;
        this.numberPerMicroInterval = frequency.Item3;
        this.attackPattern = attack.AttackPattern;
    }
}
