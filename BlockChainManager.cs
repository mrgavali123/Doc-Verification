using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;
using Firebase.Database;
using Firebase.Database.Query;
using FireBaseLib;

namespace AutoGenerateCertificate.util
{
   class BlockChainManager
    {
        Block bc;
        BlockBonafide blockBonifide;

        public BlockChainManager(Block bc)
        {
            this.bc = bc;

            createBlock();

        }
        public BlockChainManager(BlockBonafide blockBonifide)
        {
            this.blockBonifide = blockBonifide;

            createBlockBonafide();

        }

        public void createBlock()
        {
            String strblock = "BlockTransferCert";

            var fb = FireBaseDB.init(FBConfig.url);
            var task = fb.Child(strblock).OnceAsync<Block>();
            task.Wait();
            var fbdata = task.Result;
            Block block = new Block();
            bc.TransferPojo.Id = "1";
            int f = 0;
            int c = 1;
            foreach (var data in fbdata)
            {
                block.Hash = data.Object.Hash;
                block.Prevhash = data.Object.Prevhash;
                block.TransferPojo = data.Object.TransferPojo;
                c++;

                f = 1;

            }
            bc.TransferPojo.Id = c+"";
            addBlock(block, f);
        }
        public void createBlockBonafide()
        {
            String strblock = "BlockBonafideCert";

            var fb = FireBaseDB.init(FBConfig.url);
            var task = fb.Child(strblock).OnceAsync<BlockBonafide>();
            task.Wait();
            var fbdata = task.Result;
            BlockBonafide block = new BlockBonafide();
            blockBonifide.BonafidePojo.Id = "1";
            int f = 0;
            int c = 1;
            foreach (var data in fbdata)
            {
                block.Hash = data.Object.Hash;
                block.Prevhash = data.Object.Prevhash;
                block.BonafidePojo = data.Object.BonafidePojo;
                c++;

                f = 1;

            }
            blockBonifide.BonafidePojo.Id = c + "";
            addBlock_Bonafide(block, f);
        }

        public void addBlock(Block block, int isNull)
        {
            String strblock = "BlockTransferCert";

            var fb = FireBaseDB.init(FBConfig.url).Child(strblock);


            if (isNull != 0)
            {
                Block latestblock = new Block(block.Hash, DateTime.Now.ToString(), bc.TransferPojo);
                fb.PostAsync(latestblock).Wait();
                bc = latestblock;
            }
            else
            {
                Block latestblock = new Block("null", DateTime.Now.ToString(), bc.TransferPojo);
                fb.PostAsync(latestblock).Wait();
                bc = latestblock;

            }
        }

        public void addBlock_Bonafide(BlockBonafide block, int isNull)
        {
            String strblock = "BlockBonafideCert";

            var fb = FireBaseDB.init(FBConfig.url).Child(strblock);


            if (isNull != 0)
            {
                BlockBonafide latestblock = new BlockBonafide(blockBonifide.Hash, DateTime.Now.ToString(), blockBonifide.BonafidePojo);
                fb.PostAsync(latestblock).Wait();
                blockBonifide = latestblock;
            }
            else
            {
                BlockBonafide latestblock = new BlockBonafide("null", DateTime.Now.ToString(), blockBonifide.BonafidePojo);
                fb.PostAsync(latestblock).Wait();
                blockBonifide = latestblock;

            }
        }
        public Block getBlock()
        {
            return bc;
        }

        public BlockBonafide getBlock_Bonafide()
        {
            return blockBonifide;
        }

    }

}

