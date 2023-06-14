using UnityEngine;
using UnityEngine.U2D;

public class AtlasSpriteTool : MonoBehaviour
{
	[SerializeField] private SpriteAtlas atlas;

	private void Awake()
	{
		ActionManager.SetSprite += GetSprite;
	}

	private Sprite GetSprite(AtlasSprites atlasSprites)
	{
		return atlas.GetSprite(atlasSprites.ToString());
	}
}
