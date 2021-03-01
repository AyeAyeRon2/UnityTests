using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class StatisticsLoader : MonoBehaviour
{
    public CharacterStatistics characterStatistics;

    private Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        characterStatistics.RandomizeStats();

        GetComponent<Renderer>().material.color = characterStatistics.color;

        GenerateRandomPosition();
        DisplayStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Start();
        }

        if (transform.position.Equals(randomPosition))
        {
            GenerateRandomPosition();
        }

        transform.position = Vector3.MoveTowards(transform.position, randomPosition, characterStatistics.speed * Time.deltaTime);
    }


    void DisplayStats()
    {
        Debug.Log(characterStatistics.characterName);
        Debug.Log(characterStatistics.attack);
        Debug.Log(characterStatistics.defense);
        Debug.Log(characterStatistics.speed);
        Debug.Log(characterStatistics.maxHealth);
    }

    private void GenerateRandomPosition()
    {
        float x = Random.Range(-4.5f, 4.5f);
        float y = 1.0f;
        float z = Random.Range(-4.5f, 4.5f);

        randomPosition = new Vector3(x, y, z);
    }
}
