using System;
using OpenTK.Graphics;

namespace ObjRenderer
{
	public class Material
	{
		[Flags]
		public enum Reflection
		{
			Fresnel = 1 << 0,
			RayTrace = 1 << 1,
		}

		[Flags]
		public enum Transparency
		{
			Glass = 1 << 0,
			Refraction = 1 << 1,
		}

		public bool colorOn;
		public bool ambientOn;
		public bool highlightOn;
		public bool castShadowsOnInvisible;
		public Reflection reflection;
		public Transparency transparency;

		public Color4 ambient;
		public Color4 diffuse;
		public Color4 specular;
		public float specularExponent;
		public float dissolution;

		public string ambientTexture;
		public string diffuseTexture;
		public string specularColorTexture;
		public string specularHighlight;
		public string bumpMap;
		public string displacementMap;
		public string decalTexture;

		public readonly string name;

		public Material(string name)
		{
			this.name = name;
		}
	}
}
