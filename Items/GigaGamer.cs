using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace BossRematches.Items
{
	public class GigaGamer : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("GigaGamer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is the Crungonator 5000");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 177;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.GamerBlast>();
            Item.shootSpeed = 16;
			Item.noMelee = true;
			Item.mana = 10;
		}
		/*public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.immune[player.whoAmI] = 120; //Gives enemies 120 i-frames instead of default 10 (does not work)
		}*/
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}