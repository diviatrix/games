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
        CreateBody();
        CreateHead();
        CreateLeftHand();
        CreateRightHand();
        CreateLeftLeg();
        CreateRightLeg();
        CreateWeapon();
    }

    void CreateHead()
    {

    }
    void CreateBody()
    {
        GameObject body = new GameObject();
        body.name = transform.name + "_body";
        body.transform.SetParent(this.transform);
        SpriteRenderer bodyRenderer = body.AddComponent<SpriteRenderer>();
        bodyRenderer.sprite = bodySprite;
        body.transform.localScale += new Vector3(20, 20, 0);
        Debug.Log(body);

    }
    void CreateLeftHand()
    {
        GameObject body = new GameObject();
        body.name = transform.name + "_left_hand";
        body.transform.SetParent(this.transform);
        SpriteRenderer bodyRenderer = body.AddComponent<SpriteRenderer>();
        bodyRenderer.sprite = bodySprite;
        body.transform.localScale += new Vector3(20, 20, 0);
        Debug.Log(body);
    }
    void CreateRightHand()
    {
        GameObject body = new GameObject();
        body.name = transform.name + "_body";
        body.transform.SetParent(this.transform);
        SpriteRenderer bodyRenderer = body.AddComponent<SpriteRenderer>();
        bodyRenderer.sprite = bodySprite;
        body.transform.localScale += new Vector3(20, 20, 0);
        Debug.Log(body);
    }
    void CreateLeftLeg()
    {
        GameObject body = new GameObject();
        body.name = transform.name + "_body";
        body.transform.SetParent(this.transform);
        SpriteRenderer bodyRenderer = body.AddComponent<SpriteRenderer>();
        bodyRenderer.sprite = bodySprite;
        body.transform.localScale += new Vector3(20, 20, 0);
        Debug.Log(body);
    }
    void CreateRightLeg()
    {
        GameObject body = new GameObject();
        body.name = transform.name + "_body";
        body.transform.SetParent(this.transform);
        SpriteRenderer bodyRenderer = body.AddComponent<SpriteRenderer>();
        bodyRenderer.sprite = bodySprite;
        body.transform.localScale += new Vector3(20, 20, 0);
        Debug.Log(body);
    }
    void CreateWeapon()
    {
        GameObject body = new GameObject();
        body.name = transform.name + "_body";
        body.transform.SetParent(this.transform);
        SpriteRenderer bodyRenderer = body.AddComponent<SpriteRenderer>();
        bodyRenderer.sprite = bodySprite;
        body.transform.localScale += new Vector3(20, 20, 0);
        Debug.Log(body);
    }

}
