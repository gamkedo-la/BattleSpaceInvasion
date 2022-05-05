using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutGroup))]
[ExecuteInEditMode]
public class LivesUI : MonoBehaviour
{
    [Tooltip("Reference to the Player GameObject in the scene")]
    public GameObject playerGameObject;
    
    [Tooltip("Prefab of GameObject to represent lives")]
    public GameObject livesUIImagePrefab;
    
    [Range(0,100)]
    [Tooltip("Size to display Lives Image")]
    public float livesImageSize = 32f;
    
    [Range(0,20)]
    [Tooltip("Number of lives to show in editor as a preview.")]
    public int numberLivesPreview = 5;
    
    private LayoutGroup layoutGroup;
    
#if UNITY_EDITOR
    //flag to indicate if property was changed in inspector
    private bool hasPropertyChangedFlag = false;
#endif
    
    // Start is called before the first frame update
    void Start()
    {
        Player player = playerGameObject.GetComponent<Player>();
        PlayerLivesChanged(player.GetPlayerLives());
        player.playerLivesChanged += PlayerLivesChanged;
    }
    private void PlayerLivesChanged(int newLivesValue)
    {
        //don't handle negative lives values
        if (newLivesValue < 0)
        {
            return;
        }
        //while the number of child images isn't equal to number of lives
        while (transform.childCount != newLivesValue)
        {
            if (transform.childCount > newLivesValue) //remove a life image from children
            {
                //get the first life
                GameObject gameObjectToRemove = transform.GetChild(0).gameObject;
                //remove it's parent
                gameObjectToRemove.transform.SetParent(null);
                
                //destroy it
#if UNITY_EDITOR
                //if in editor and playing, use destroy
                if (Application.isPlaying)
                {
                    Destroy(gameObjectToRemove);
                }
                else//if not playing destroy immediately
                {
                    DestroyImmediate(gameObjectToRemove);
                }
#else           //if in a build, use destroy
                Destroy(gameObjectToRemove);
#endif
            }
            else //add a life image to children
            {
                GameObject newLivesImage = Instantiate(livesUIImagePrefab, transform, false);
                RectTransform rectTransform = newLivesImage.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(livesImageSize, livesImageSize);
            }
        }
    }

    private void Update()
    { 
        //CAUTION: This script executes in edit mode.
        //Anything you put in update will run during edit mode
        //Use if(Application.isPlaying) to avoid this
        
#if UNITY_EDITOR 
        //if in editor and not playing, update the preview
        if (!Application.isPlaying)
        {
            UpdatePreviewLivesImages();
        }
#endif
    }
    
#if UNITY_EDITOR
    private void UpdatePreviewLivesImages()
    {
        //if a property hasn't changed, no need to update
        if (!hasPropertyChangedFlag) return;
        
        //update the size of the images
        foreach (Transform child in transform)
        {
            RectTransform rectTransform = child.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(livesImageSize, livesImageSize);
        }
        
        //update the player lives with the preview amount
        PlayerLivesChanged(numberLivesPreview);
        
        //set property changed flag back to false
        hasPropertyChangedFlag = false;
    }
    
    private void OnValidate()
    {
        //if inspector was edited
        hasPropertyChangedFlag = true;
    }
#endif
    

}
