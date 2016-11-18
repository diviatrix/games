using UnityEngine;
using System.Collections;

public class mobObject : MonoBehaviour {
    public string name;
    public int health,power;
    public Sprite headSprite,bodySprite,lhandSprite,rhandSprite,llegSprite,rlegSprite,weaponSprite;

    public mobObject(
        string name,
        int power,
        Sprite headSprite,
        Sprite bodySprite,
        Sprite lhandSprite,
        Sprite rhandSprite,
        Sprite llegSprite,
        Sprite rlegSprite,
        Sprite weaponSprite)
    {
        this.name = name;
        this.health = power;
        this.headSprite = headSprite;
        this.bodySprite = bodySprite;
        this.lhandSprite = lhandSprite;
        this.rhandSprite = rhandSprite;
        this.llegSprite = llegSprite;
        this.rlegSprite = rlegSprite;
        this.weaponSprite = weaponSprite;
    }

    void Start()
    {
        CreateMobParts();
    }

    void CreateMobParts()
    {
        CreateBodyPart(bodySprite,"_body");
        CreateBodyPart(headSprite, "_head");
        CreateBodyPart(lhandSprite, "_left_hand"); ;
        CreateBodyPart(rhandSprite, "_righ_hand");
        CreateBodyPart(llegSprite, "_left_leg");
        CreateBodyPart(rlegSprite, "_right_leg");
        CreateBodyPart(weaponSprite, "_weapon");
    }

    

    void CreateBodyPart(Sprite spr, string str)
    {
        GameObject go = new GameObject();
        go.transform.localScale += new Vector3(20, 20, 0);
        go.transform.SetParent(this.transform);
        SpriteRenderer goRenderer = go.AddComponent<SpriteRenderer>();
        goRenderer.sprite = spr;
        go.name = transform.name + str;
    }    
}
