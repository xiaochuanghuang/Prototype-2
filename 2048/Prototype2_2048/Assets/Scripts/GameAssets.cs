using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameAssets : MonoBehaviour
{
    private Image newImage;
    private void Awake()
    {
        newImage = this.GetComponent<Image>();
    }

    public void setNewImage(int number)
    {

    }
}
