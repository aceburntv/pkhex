using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PKHeX.Core.Injection
{
    public static class LPPointer
    {
        public static readonly LiveHeXVersion[] SupportedVersions = { LiveHeXVersion.SV_v101, LiveHeXVersion.SV_v110, LiveHeXVersion.LA_v100, LiveHeXVersion.LA_v101, LiveHeXVersion.LA_v102, LiveHeXVersion.LA_v111 };

        private const int LA_MYSTATUS_BLOCK_SIZE = 0x80;
        private const int SV_MYSTATUS_BLOCK_SIZE = 0x68;

        public static readonly BlockData[] Blocks_SV_v101 =
        {
            new() { Name = "MyStatus", Display = "Trainer Data", SCBKey = 0xE3E89BD1, Pointer = "[[main+42DA8E8]+148]+40" },
            new() { Name = "KItem", Display = "Items", SCBKey = 0x21C9BD44, Pointer = "[[main+42DA8E8]+1B0]+40" },
            new() { Name = "KTeraRaids", Display = "Raid", SCBKey = 0xCAAC8800, Pointer = "[[main+42DA8E8]+180]+40" },
        };

        public static readonly BlockData[] Blocks_SV_v110 =
        {
            new() { Name = "MyStatus", Display = "Trainer Data", SCBKey = 0xE3E89BD1, Pointer = "[[main+4384B18]+148]+40" },
            new() { Name = "KItem", Display = "Items", SCBKey = 0x21C9BD44, Pointer = "[[main+4384B18]+1B0]+40" },
            new() { Name = "KTeraRaids", Display = "Raid", SCBKey = 0xCAAC8800, Pointer = "[[main+4384B18]+180]+40" },
        };

        public static readonly BlockData[] Blocks_LA_v100 =
        {
            new() { Name = "MyStatus", Display = "Trainer Data", SCBKey = 0xF25C070E, Pointer = "[[main+4275470]+218]+68" },
            new() { Name = "KMoney", Display = "Money Data", SCBKey = 0x3279D927, Pointer = "[[main+4275470]+210]+6C", Type = SCTypeCode.UInt32 },

            new() { Name = "KItemRegular", Display = "Items", SCBKey = 0x9FE2790A, Pointer = "[[main+4275470]+230]+68" },
            new() { Name = "KItemKey", Display = "Items", SCBKey = 0x59A4D0C3, Pointer = "[[main+4275470]+230]+AF4" },
            new() { Name = "KItemStored", Display = "Items", SCBKey = 0x8E434F0D, Pointer = "[[main+4275470]+1E8]+68" },
            new() { Name = "KItemRecipe", Display = "Items", SCBKey = 0xF5D9F4A5, Pointer = "[[main+4275470]+230]+C84" },
            new() { Name = "KSatchelUpgrades", Display = "Items", SCBKey = 0x75CE2CF6, Pointer = "[[[[[main+4275470]+1D8]+1B8]+70]+270]+38", Type = SCTypeCode.UInt32 },

            new() { Name = "KZukan", Display = "Pokedex", SCBKey = 0x02168706, Pointer = "[[[[main+4275470]+248]+58]+18]+1C" },
        };

        public static readonly BlockData[] Blocks_LA_v101 =
        {
            new() { Name = "MyStatus", Display = "Trainer Data", SCBKey = 0xF25C070E, Pointer = "[[main+427B470]+218]+68" },
            new() { Name = "KMoney", Display = "Money Data", SCBKey = 0x3279D927, Pointer = "[[main+427B470]+210]+6C", Type = SCTypeCode.UInt32 },

            new() { Name = "KItemRegular", Display = "Items", SCBKey = 0x9FE2790A, Pointer = "[[main+427B470]+230]+68" },
            new() { Name = "KItemKey", Display = "Items", SCBKey = 0x59A4D0C3, Pointer = "[[main+427B470]+230]+AF4" },
            new() { Name = "KItemStored", Display = "Items", SCBKey = 0x8E434F0D, Pointer = "[[main+427B470]+1E8]+68" },
            new() { Name = "KItemRecipe", Display = "Items", SCBKey = 0xF5D9F4A5, Pointer = "[[main+427B470]+230]+C84" },
            new() { Name = "KSatchelUpgrades", Display = "Items", SCBKey = 0x75CE2CF6, Pointer = "[[[[[main+427B470]+1D8]+1B8]+70]+270]+38", Type = SCTypeCode.UInt32 },

            new() { Name = "KZukan", Display = "Pokedex", SCBKey = 0x02168706, Pointer = "[[[[main+427B470]+248]+58]+18]+1C" },
        };

        public static readonly BlockData[] Blocks_LA_v102 =
        {
            new() { Name = "MyStatus", Display = "Trainer Data", SCBKey = 0xF25C070E, Pointer = "[[main+427C470]+218]+68" },
            new() { Name = "KMoney", Display = "Money Data", SCBKey = 0x3279D927, Pointer = "[[main+427C470]+210]+6C", Type = SCTypeCode.UInt32 },

            new() { Name = "KItemRegular", Display = "Items", SCBKey = 0x9FE2790A, Pointer = "[[main+427C470]+230]+68" },
            new() { Name = "KItemKey", Display = "Items", SCBKey = 0x59A4D0C3, Pointer = "[[main+427C470]+230]+AF4" },
            new() { Name = "KItemStored", Display = "Items", SCBKey = 0x8E434F0D, Pointer = "[[main+427C470]+1E8]+68" },
            new() { Name = "KItemRecipe", Display = "Items", SCBKey = 0xF5D9F4A5, Pointer = "[[main+427C470]+230]+C84" },
            new() { Name = "KSatchelUpgrades", Display = "Items", SCBKey = 0x75CE2CF6, Pointer = "[[[[[main+427C470]+1D8]+1B8]+70]+270]+38", Type = SCTypeCode.UInt32 },

            new() { Name = "KZukan", Display = "Pokedex", SCBKey = 0x02168706, Pointer = "[[[[main+427C470]+248]+58]+18]+1C" },
        };

        public static readonly BlockData[] Blocks_LA_v110 =
        {
            new() { Name = "MyStatus", Display = "Trainer Data", SCBKey = 0xF25C070E, Pointer = "[[main+42BA6B0]+218]+68" },
            new() { Name = "KMoney", Display = "Money Data", SCBKey = 0x3279D927, Pointer = "[[main+42BA6B0]+210]+6C", Type = SCTypeCode.UInt32 },

            new() { Name = "KItemRegular", Display = "Items", SCBKey = 0x9FE2790A, Pointer = "[[main+42BA6B0]+230]+68" },
            new() { Name = "KItemKey", Display = "Items", SCBKey = 0x59A4D0C3, Pointer = "[[main+42BA6B0]+230]+AF4" },
            new() { Name = "KItemStored", Display = "Items", SCBKey = 0x8E434F0D, Pointer = "[[main+42BA6B0]+1E8]+68" },
            new() { Name = "KItemRecipe", Display = "Items", SCBKey = 0xF5D9F4A5, Pointer = "[[main+42BA6B0]+230]+C84" },
            new() { Name = "KSatchelUpgrades", Display = "Items", SCBKey = 0x75CE2CF6, Pointer = "[[[[[main+42BA6B0]+1D8]+1B8]+70]+270]+38", Type = SCTypeCode.UInt32 },

            new() { Name = "KZukan", Display = "Pokedex", SCBKey = 0x02168706, Pointer = "[[[[main+42BA6B0]+248]+58]+18]+1C" },
        };

        // LiveHexVersion -> Blockname -> List of <SCBlock Keys, OffsetValues>
        public static readonly Dictionary<LiveHeXVersion, BlockData[]> SCBlocks = new()
        {
            { LiveHeXVersion.SV_v110, Blocks_SV_v110 },
            { LiveHeXVersion.SV_v101, Blocks_SV_v101 },
            { LiveHeXVersion.LA_v100, Blocks_LA_v100 },
            { LiveHeXVersion.LA_v101, Blocks_LA_v101 },
            { LiveHeXVersion.LA_v102, Blocks_LA_v102 },
            { LiveHeXVersion.LA_v111, Blocks_LA_v110 },
        };

        public static readonly Dictionary<string, string> SpecialBlocks = new()
        {
            { "Items", "B_OpenItemPouch_Click" },
            { "Pokedex", "B_OpenPokedex_Click" },
            { "Raid", "B_OpenRaids_Click" },
            //{ "Trainer Data", "B_OpenTrainerInfo_Click" },
        };

        private static string GetB1S1Pointer(LiveHeXVersion lv)
        {
            return lv switch
            {
                LiveHeXVersion.SV_v110 => "[[[main+4384B18]+128]+9B0]",
                LiveHeXVersion.SV_v101 => "[[[main+42DA8E8]+128]+9B0]",
                LiveHeXVersion.LA_v100 => "[[main+4275470]+1F0]+68",
                LiveHeXVersion.LA_v101 => "[[main+427B470]+1F0]+68",
                LiveHeXVersion.LA_v102 => "[[main+427C470]+1F0]+68",
                LiveHeXVersion.LA_v111 => "[[main+42BA6B0]+1F0]+68",
                _ => string.Empty
            };
        }

        public static byte[] ReadBox(PokeSysBotMini psb, int box, List<byte[]> allpkm)
        {
            if (psb.com is not ICommunicatorNX sb)
                return ArrayUtil.ConcatAll(allpkm.ToArray());
            var lv = psb.Version;
            var b1s1 = sb.GetPointerAddress(GetB1S1Pointer(lv));
            var boxsize = RamOffsets.GetSlotCount(lv) * RamOffsets.GetSlotSize(lv);
            var boxstart = b1s1 + (ulong)(box * boxsize);
            return psb.com.ReadBytes(boxstart, boxsize);
        }

        public static byte[] ReadSlot(PokeSysBotMini psb, int box, int slot)
        {
            if (psb.com is not ICommunicatorNX sb)
                return new byte[psb.SlotSize];
            var lv = psb.Version;
            var slotsize = RamOffsets.GetSlotSize(lv);
            var b1s1 = sb.GetPointerAddress(GetB1S1Pointer(lv));
            var boxsize = RamOffsets.GetSlotCount(lv) * slotsize;
            var boxstart = b1s1 + (ulong)(box * boxsize);
            var slotstart = boxstart + (ulong)(slot * slotsize);
            return psb.com.ReadBytes(slotstart, slotsize);
        }

        public static void SendSlot(PokeSysBotMini psb, byte[] data, int box, int slot)
        {
            if (psb.com is not ICommunicatorNX sb)
                return;
            var lv = psb.Version;
            var slotsize = RamOffsets.GetSlotSize(lv);
            var b1s1 = sb.GetPointerAddress(GetB1S1Pointer(lv));
            var boxsize = RamOffsets.GetSlotCount(lv) * slotsize;
            var boxstart = b1s1 + (ulong)(box * boxsize);
            var slotstart = boxstart + (ulong)(slot * slotsize);
            psb.com.WriteBytes(data, slotstart);
        }

        public static void SendBox(PokeSysBotMini psb, byte[] boxData, int box)
        {
            if (psb.com is not ICommunicatorNX sb)
                return;
            var lv = psb.Version;
            var b1s1 = sb.GetPointerAddress(GetB1S1Pointer(lv));
            var boxsize = RamOffsets.GetSlotCount(lv) * RamOffsets.GetSlotSize(lv);
            var boxstart = b1s1 + (ulong)(box * boxsize);
            psb.com.WriteBytes(boxData, boxstart);
        }

        public static bool ReadBlockFromString(PokeSysBotMini psb, SaveFile sav, string block, out List<byte[]>? read)
        {
            read = null;
            if (psb.com is not ICommunicatorNX sb)
                return false;
            try
            {
                var offsets = SCBlocks[psb.Version].Where(z => z.Display == block);
                var blocks = sav.GetType().GetProperty("Blocks");
                var allblocks = blocks?.GetValue(sav);
                if (allblocks is not SCBlockAccessor scba)
                    return false;
                foreach (var sub in offsets)
                {
                    var scbkey = sub.SCBKey;
                    var offset = sub.Pointer;
                    var scb = scba.GetBlock(scbkey);
                    if (scb.Type == SCTypeCode.None && sub.Type != SCTypeCode.None)
                        ReflectUtil.SetValue(scb, "Type", sub.Type);
                    var ram = psb.com.ReadBytes(sb.GetPointerAddress(offset), scb.Data.Length);
                    ram.CopyTo(scb.Data, 0);
                    if (read == null)
                    {
                        read = new List<byte[]> { ram };
                    }
                    else
                    {
                        read.Add(ram);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return false;
            }
        }

        public static void WriteBlocksFromSAV(PokeSysBotMini psb, string block, SaveFile sav)
        {
            if (psb.com is not ICommunicatorNX sb)
                return;
            var blocks = sav.GetType().GetProperty("Blocks");
            var allblocks = blocks?.GetValue(sav);
            if (allblocks is not SCBlockAccessor scba)
                return;
            var offsets = SCBlocks[psb.Version].Where(z => z.Display == block);
            foreach (var sub in offsets)
            {
                var scbkey = sub.SCBKey;
                var offset = sub.Pointer;
                var scb = scba.GetBlock(scbkey);
                psb.com.WriteBytes(scb.Data, sb.GetPointerAddress(offset));
            }
        }

        public static Func<PokeSysBotMini, byte[]?> GetTrainerDataLA = psb =>
        {
            if (psb.com is not ICommunicatorNX sb)
                return null;
            var lv = psb.Version;
            var ptr = SCBlocks[lv].First(z => z.Name == "MyStatus").Pointer;
            var ofs = sb.GetPointerAddress(ptr);
            if (ofs == 0)
                return null;
            return psb.com.ReadBytes(ofs, LA_MYSTATUS_BLOCK_SIZE);
        };

        public static Func<PokeSysBotMini, byte[]?> GetTrainerDataSV = psb =>
        {
            if (psb.com is not ICommunicatorNX sb)
                return null;
            var lv = psb.Version;
            var ptr = SCBlocks[lv].First(z => z.Name == "MyStatus").Pointer;
            var ofs = sb.GetPointerAddress(ptr);
            if (ofs == 0)
                return null;
            return psb.com.ReadBytes(ofs, SV_MYSTATUS_BLOCK_SIZE);
        };
    }
}
