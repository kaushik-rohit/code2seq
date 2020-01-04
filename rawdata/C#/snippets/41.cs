void ChangeSprite()
    {
        Sprite spriteSelected;
        if (num < 0 || num >= spriteValue.Length)
        {
            spriteSelected = spriteValue[Random.Range(0, spriteValue.Length)];
        }
        else
        {
            spriteSelected = spriteValue[num];
        }
        targetObject.GetComponent<Image>().sprite = spriteSelected;
        targetObject.GetComponent<Image>().SetNativeSize();
    }