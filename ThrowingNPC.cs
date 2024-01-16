using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using hololive.Projectiles; // Vector2を使用するために必要

namespace hololive.NPCs
{
    public class ThrowingNPC : ModNPC
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            NPC.width = 32; // NPCの幅
            NPC.height = 32; // NPCの高さ
            NPC.damage = 100; // 攻撃力
            NPC.defense = 10; // 防御力
            NPC.lifeMax = 200; // 最大HP
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCID.BlueSlime; // AIのタイプ（例：ゾンビ）
            // 他の設定...
        }

        public override void AI()
{
                NPC.TargetClosest(true);
    Mod.Logger.Info(NPC.ai[3]);
    // 他のAIコード...
    if (NPC.ai[3]++ > 50) // 100フレームごとに投擲
    {
        Mod.Logger.Info("とうてき"); // at log-level INFO
        NPC.ai[3] = 0; // タイマーリセット
        Player player = Main.player[NPC.target];
        Vector2 direction = player.Center - NPC.Center;
        direction.Normalize();
        direction *= 3f; // 投擲物の速度
        direction.Y -= 5f; // Y方向を上に調整
        Vector2 position = NPC.Center + Vector2.Normalize(direction) * 40; 

        // 投擲物を生成
        Projectile.NewProjectile(NPC.GetSource_FromAI(), position, direction, ModContent.ProjectileType<ThrowingCarrot>(), NPC.damage, 10f, Main.myPlayer);
    }
}


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // 昼間の地上でスポーンする条件
            if (spawnInfo.SpawnTileY < Main.worldSurface && Main.dayTime) // ZoneOverworldHeightの代わりにspawnTileYを使用
            {
                return 0.5f; // スポーン率を高く設定（0～1の範囲、通常はかなり低い）
            }
            return 0f; // それ以外の場所ではスポーンしない
        }
    }
}
