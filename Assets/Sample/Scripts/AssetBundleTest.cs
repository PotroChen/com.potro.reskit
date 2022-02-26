using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFrameWork.ResKit;

public class AssetBundleTest : MonoBehaviour {

    ResLoader resLoader = new ResLoader();
    // Use this for initialization
    IEnumerator Start () {

        ResMgr.Init();
        SpriteRenderer redRenderer = GameObject.Find("Red").GetComponent<SpriteRenderer>();
        Texture2D redTexture = resLoader.LoadAsset<Texture2D>("Red");
        Sprite redSprite = Sprite.Create(redTexture, new Rect(0, 0, redTexture.width, redTexture.height),Vector2.one*0.5f);
        redRenderer.sprite = redSprite;

        yield return new WaitForSeconds(3f);
        Resources.UnloadAsset(redTexture);

        SpriteRenderer blueRenderer = GameObject.Find("Blue").GetComponent<SpriteRenderer>();
        Texture2D blueTexture = resLoader.LoadAsset<Texture2D>("Blue");
        Sprite blueSprite = Sprite.Create(blueTexture, new Rect(0, 0, blueTexture.width, blueTexture.height), Vector2.one * 0.5f);
        blueRenderer.sprite = blueSprite;

        yield return new WaitForSeconds(3f);
        Resources.UnloadAsset(blueTexture);

        SpriteRenderer greenRenderer = GameObject.Find("Green").GetComponent<SpriteRenderer>();
        Texture2D greenTexture = resLoader.LoadAsset<Texture2D>("Green");
        Sprite greenSprite = Sprite.Create(greenTexture, new Rect(0, 0, greenTexture.width, greenTexture.height), Vector2.one * 0.5f);
        greenRenderer.sprite = greenSprite;

        yield return new WaitForSeconds(3f);
        Resources.UnloadAsset(greenTexture);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
