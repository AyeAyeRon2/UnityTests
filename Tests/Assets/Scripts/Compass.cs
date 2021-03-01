﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject iconPrefab;
    List<QuestMarker> questMarkers = new List<QuestMarker>();

    public RawImage compassImage;
    public Transform player;

   // public float maxDistance = 200f;

    float compassUnit;

    public QuestMarker one;
    public QuestMarker two;
    public QuestMarker three;


    private void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;

        AddQuestMarker(one);
        AddQuestMarker(two);
        AddQuestMarker(three);
    }

    void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach (QuestMarker marker in questMarkers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);

           // float dst = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), marker.position);
            //float scale = 0f;

           // if (dst < maxDistance)
            
                //scale = 1f - (dst / maxDistance);

            //marker.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    public void AddQuestMarker (QuestMarker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        questMarkers.Add(marker);
    }

    public void RemoveQuestMarker(QuestMarker marker)
    {
        questMarkers.Remove(marker);
    }

    Vector2 GetPosOnCompass (QuestMarker marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);

        return new Vector2(compassUnit * angle, 0f);
    }
}
