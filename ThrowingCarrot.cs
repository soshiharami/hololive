using hololive.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace hololive.Projectiles
{
    public class ThrowingCarrot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            AIType = ProjectileID.SnowBallHostile; // ベースとなるAIタイプ
            Projectile.width = 32; // 投擲物の幅
            Projectile.height = 32; // 投擲物の高さ
            Projectile.aiStyle = 1; // AIスタイル
            Projectile.friendly = false; // プレイヤーに対してフレンドリー（ダメージを与えない）
            Projectile.hostile = true; // 敵に対してホスタイル（ダメージを与える）
            Projectile.penetrate = 2; // 貫通数
            Projectile.timeLeft = 600; // 存在時間（フレーム単位）
            Projectile.ignoreWater = true; // 水を無視するかどうか
            Projectile.tileCollide = true; // タイルに衝突するかどうか
            Projectile.knockBack = 3;
        }

        public override void Kill(int timeLeft)
        {
            // アイテムをドロップする確率（例: 20%）
            if (Main.rand.NextFloat() < 0.20f) // 20%の確率
            {
                Item.NewItem(Projectile.GetSource_Death(), Projectile.getRect(), ModContent.ItemType<Carrot>(), Main.rand.Next(1, 4)); // 1から3個の木の矢をドロップ
            }
        }

        public override void AI()
        {
            Projectile.rotation += 1.2f * (float)Projectile.direction;
        }

        // 必要に応じて他のメソッドをオーバーライドして挙動をカスタマイズ
    }
}
