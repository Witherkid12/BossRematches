using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace BossRematches.Items
{
	public class UltraGamer : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("UltraGamer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is the Crungonator 12 billion");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 1560;
			Item.DamageType = DamageClass.Melee;
			Item.width = 160;
			Item.height = 160;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = 10000000;
			Item.rare = ItemRarityID.Master;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.UltraBlast>();
			Item.shootSpeed = 21;
			Item.crit = 34;
		}

        /*public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.immune[player.whoAmI] = 60; //Gives enemies 60 i-frames instead of default 10 (does not work)
		}*/


        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Zenith, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
