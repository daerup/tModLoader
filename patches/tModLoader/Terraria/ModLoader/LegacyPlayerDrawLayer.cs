﻿using Terraria.DataStructures;

namespace Terraria.ModLoader
{
	[Autoload(false)]
	internal sealed class LegacyPlayerDrawLayer : PlayerDrawLayer
	{
		/// <summary> The delegate of this method, which can either do the actual drawing or add draw data, depending on what kind of layer this is. </summary>
		public readonly LayerFunction Layer;

		private readonly string CustomName;
		private readonly bool HeadLayer;

		public override string Name => CustomName;
		public override bool IsHeadLayer => HeadLayer;
		public override DrawLayer<PlayerDrawSet> Parent { get; set; }

		/// <summary> Creates a LegacyPlayerLayer with the given mod name, identifier name, and drawing action. </summary>
		public LegacyPlayerDrawLayer(string name, bool isHeadLayer, LayerFunction layer) {
			CustomName = name;
			Layer = layer;
			HeadLayer = isHeadLayer;
		}

		public override void GetDefaults(PlayerDrawSet drawInfo, out bool visible, out LayerConstraint constraint) {
			visible = true;
			constraint = default;
		}

		public override void Draw(ref PlayerDrawSet drawInfo) => Layer(ref drawInfo);
	}
}