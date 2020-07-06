using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Versioning;
using IL.Terraria.UI;

namespace MoreWeaponaria.Items.NPCBOSS
{
    [AutoloadBossHead]
    public class Mara : ModNPC
    {
        // AI
        // Attackstate 0 = Stunned, 1 = Star attack, 2 = Laser Sweep, 3 = Super Chase
        private int attackState = 0;
        private int ai;
        private int attackTimer = 0;
        private bool fastSpeed = false;

        private bool stunned = false;
        private int stunnedTimer;

        private int frame = 0;
        private double counting;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mara, the Star Lord");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            npc.width = 256;
            npc.height = 256;
            npc.boss = true;
            npc.aiStyle = -1;
            npc.npcSlots = 5f;
            npc.knockBackResist = 0f;
            npc.defense = 85;
            npc.damage = 45;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lifeMax = 425000;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = MusicID.LunarBoss;

            bossBag = mod.ItemType("MaraTreasureBag");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.25f);
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center, new Vector3(255, 255, 0));
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;

            npc.rotation = 0.0f;
            npc.netAlways = true;
            npc.TargetClosest(true);
            if (npc.life >= npc.lifeMax)
            {
                npc.life = npc.lifeMax;
            }
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y + 0.1f;
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }

            ai++;
            npc.ai[0] = (float)ai;

            //MOVEMENT STARTS HERE

            int distance = (int)Vector2.Distance(target, npc.Center);
            if ((double)npc.ai[0] < 300)
            {
                attackState = 1;
                frame = 0;
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 600)
            {
                attackState = 0;
                frame = 0;
                MoveTowards(npc, target, 15f, 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 600 && (double)npc.ai[0] < 900)
            {
                attackState = 2;
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
                frame = 1;
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 900 && (double)npc.ai[0] < 1200)
            {
                attackState = 0;
                frame = 0;
                MoveTowards(npc, target, 10f, 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 1200 && (double)npc.ai[0] < 1500)
            {
                attackState = 3;
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
                frame = 1;
                npc.netUpdate = true;
            }
            else
            {
                npc.netUpdate = true;
            }
            if (attackState == 0)
            {
                npc.life += 25;
            }
            if ((double)npc.ai[0] >= 1500)
            {
                ai = 0;
                npc.alpha = 0;
                fastSpeed = false;
            }
            else
            {
                if (attackState == 1)
                {
                    if ((double)npc.ai[0] % 20 == 0)
                    {
                        attackTimer++;
                        if (attackTimer <= 2)
                        {
                            frame = 2;
                            Vector2 shootPos = npc.Center;
                            float accuracy = 5f * (npc.life / npc.lifeMax);
                            Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                            shootVel.Normalize();
                            shootVel *= 19f;
                            Main.PlaySound(SoundID.Item, npc.Center, 9);
                            Projectile.NewProjectile(npc.Center, shootVel, mod.ProjectileType("MaraProjectileStar"), npc.damage / 5, 10f);
                        }
                        else
                        {
                            attackTimer = 0;
                        }
                    }
                }
                else if (attackState == 2)
                {
                    if ((double)npc.ai[0] % 14 == 0)
                    {
                        Vector2 shootPos = new Vector2(npc.position.X + Main.rand.Next(-100, 101), npc.position.Y - 1000);
                        float accuracy = npc.life / npc.lifeMax;
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                        shootVel.Normalize();
                        shootVel *= 30f;
                        Main.PlaySound(SoundID.Item, npc.Center, 9);
                        Projectile.NewProjectile(new Vector2(npc.position.X + Main.rand.Next(-100, 101), npc.position.Y - 1000), shootVel, mod.ProjectileType("MaraProjectileStar"), npc.damage / 2, 30f);
                    }
                }
                else if (attackState == 3)
                {
                    if ((double)npc.ai[0] % 120 == 0)
                    {
                        Vector2 shootPos = new Vector2(npc.position.X + Main.rand.Next(-100, 101), npc.position.Y - 1000);
                        float accuracy = npc.life / npc.lifeMax;
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                        shootVel.Normalize();
                        shootVel *= 30f;
                        Main.PlaySound(SoundID.Item, npc.Center, 4);
                        for (int k = 0; k < 15; k ++)
                        {
                            Projectile.NewProjectile(new Vector2(npc.position.X - 1500 + k * 200, npc.position.Y + 1000), new Vector2(0, -100), mod.ProjectileType("MaraProjectileOrb"), npc.damage / 3, 30f);
                        }
                        for (int z = 0; z < 15; z ++)
                        {
                            Projectile.NewProjectile(new Vector2(npc.position.X - 1400 + z * 200, npc.position.Y - 1000), new Vector2(0, +100), mod.ProjectileType("MaraProjectileOrb"), npc.damage / 3, 30f);
                        }
                    }
                }
            }
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Zenithite"), Main.rand.Next(365, 600));
            }
        }
        private void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
        }
        public override void FindFrame(int frameHeight)
        {
            if (attackState == 0)
            {
                npc.frame.Y = 0;
            }
            else if (attackState != 0)
            {
                counting += 1f;
                if (counting <= 20)
                    npc.frame.Y = (int)(counting / 5f + 1) * frameHeight;
                else
                    counting = 0f;
            }
        }
    }
}
