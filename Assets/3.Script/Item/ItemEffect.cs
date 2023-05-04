using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    private ItemData itemData;
    public event System.Action OnItem;
    [SerializeField] private GameObject player;
    [SerializeField] private Renderer playerRender;
    WaitForSeconds colorTime = new WaitForSeconds(0.01f);
    private float endStarTime = 0f;

    public void OnStar()
    {

    }

    public void OnMushroom()
    {
        StartCoroutine(Mushroom_co());
    }

    public void OnCoin()
    {
        //½ºÄÚ¾î +100
    }

    private IEnumerator Mushroom_co()
    {
        player.transform.localScale = itemData.scale;

        yield return new WaitForSeconds(itemData.itemTime);

        player.transform.localScale = new Vector3(1, 1, 1);
    }

    private IEnumerator Star_co()
    {

        while (endStarTime <= 5f)
        {
            endStarTime = Time.deltaTime;
            playerRender.material.color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);
            yield return colorTime;
        }


    }
}
