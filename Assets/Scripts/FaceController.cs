using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceController : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] List<Sprite> Sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        int multiplier = 3;
        if(ScoreManager.Instance.Score < 50 * multiplier)
        {
            SetFace (0);
        }
        else if ((ScoreManager.Instance.Score < 100 * multiplier))
            SetFace(1);
        else if ((ScoreManager.Instance.Score < 200 * multiplier))
            SetFace(2);
        else if ((ScoreManager.Instance.Score < 300 * multiplier))
            SetFace(3);
        else if ((ScoreManager.Instance.Score < 400 * multiplier))
            SetFace(4);
        else if ((ScoreManager.Instance.Score < 500 * multiplier))
            SetFace(5);
        else if ((ScoreManager.Instance.Score < 600 * multiplier))
            SetFace(6);
        else if ((ScoreManager.Instance.Score < 700 * multiplier))
            SetFace(7);
        else if ((ScoreManager.Instance.Score < 800 * multiplier))
            SetFace(8);
        else if ((ScoreManager.Instance.Score < 900 * multiplier))
            SetFace(9);
        else if ((ScoreManager.Instance.Score < 1000 * multiplier))
            SetFace(10);
        else if ((ScoreManager.Instance.Score < 1100 * multiplier))
            SetFace(11);
        else    
            SetFace(12);

    }
    private void SetFace(int i)
    {
        image.sprite = Sprites[i];
    }
}
