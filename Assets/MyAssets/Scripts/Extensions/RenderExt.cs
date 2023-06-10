using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RenderExt
{
	public static void SetColor(this MeshRenderer meshRenderer, Color color)
	{
		meshRenderer.material.color = color;
	}

	public static void SetColorAlpha(this MeshRenderer meshRenderer, float alpha)
	{
		Color color = meshRenderer.material.color;
		color.a = alpha;
		meshRenderer.material.color = color;
	}
}
