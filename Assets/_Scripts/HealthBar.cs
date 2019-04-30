using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [Header("Health")]

    [SerializeField] private Player player;

    [Header("Clone Objects")]

    [SerializeField] private GameObject healthPoint;
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 offset;

    [Header("Textures")]

    [SerializeField] private Sprite heartStart;
    [SerializeField] private Sprite heartMiddle;
    [SerializeField] private Sprite heartEnd;

    [SerializeField] private Sprite heartDeadStart;
    [SerializeField] private Sprite heartDeadMiddle;
    [SerializeField] private Sprite heartDeadEnd;



    private List<Image> healthPoints;
    private List<bool> healthPointsActive;
    private int currentHealth = 0;
    private Sprite pointSprite;
    private bool activated;


    private void Start()
    {
        Vector3 pos = initialPos;
        healthPoints = new List<Image>();
        healthPointsActive = new List<bool>();
        for (int i = 0; i < player.maxHealth; i++)
        {
            healthPoints.Add(Instantiate(healthPoint, pos, Quaternion.identity, transform).GetComponent<Image>());
            healthPointsActive.Add(true);
            pos += offset;
        }
        healthPoints[0].sprite = heartStart;
        healthPoints[healthPoints.Count - 1].sprite = heartEnd;
    }

    public void UpdateHealth() {
        // count from every dead healthpoint 
        for (int i = 0; i < player.maxHealth; i++)
        {
            activated = i < player.health;
            if (healthPointsActive[i] != activated)
            {
                if (i == 0 && activated)
                    pointSprite = heartStart;
                else if (i == 0 && !activated)
                    pointSprite = heartDeadStart;

                else if (i == healthPointsActive.Count - 1 && activated)
                    pointSprite = heartEnd;
                else if (i == healthPointsActive.Count - 1 && !activated)
                    pointSprite = heartDeadEnd;

                else if (activated)
                    pointSprite = heartMiddle;
                else
                    pointSprite = heartDeadMiddle;

                healthPointsActive[i] = activated;
                healthPoints[i].sprite = pointSprite;
            }

        }
    }

}
