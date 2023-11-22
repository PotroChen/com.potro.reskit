using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GameFramework.ResKit
{
    public class ResMgr
    {
        public static bool simulateMode = false;
        /// <summary>
        /// 共享的资源
        /// </summary>
        public static List<Res> SharedLoadedReses = new List<Res>();//Resource里的资源和AssetBundle的资源重名的话，还没有做区分

        public static void Init()
        {
            AssetTable.Load();
        }

        public static Res GetRes(string path)
        {
            Res res = SharedLoadedReses.Find(loadedAsset => loadedAsset.Path == path);

            if (res != null)
            {
                res.Retain();
                return res;
            }

            if (path.StartsWith("resources://"))
            {
                res = new ResourceRes(path);
            }
            else
            {
                res = new AssetRes(path);
            }

            res.Load();
            SharedLoadedReses.Add(res);
            res.Retain();

            return res;
        }

        public static AssetBundleRes GetAssetBundleRes(string assetPath)
        {
            Res res = SharedLoadedReses.Find(loadedAsset => loadedAsset.Path == assetPath);

            if (res != null)
            {
                res.Retain();
                return res as AssetBundleRes;
            }

            res = new AssetBundleRes(assetPath);
            res.Load();
            SharedLoadedReses.Add(res);
            res.Retain();

            return res as AssetBundleRes;

        }
    }

}