using UnityEngine;

namespace GameFramework.ResKit
{
    public class AssetRes : Res
    {

        private string assetBundleName;
        private AssetBundleRes assetBundleRes;

        public AssetRes(string assetName, string assetBundleName) : base(assetName)
        {
            this.assetBundleName = assetBundleName ?? AssetTable.Instance.GetAssetBundleName(assetName);
        }


        public override void Load()
        {
            base.Load();
            if (assetBundleRes == null)
                assetBundleRes = ResMgr.GetAssetBundleRes(Application.streamingAssetsPath + "/AssetBundles/" + assetBundleName);
            asset = (assetBundleRes.Asset as AssetBundle).LoadAsset(Name);
            if (asset == null)
                Debug.LogErrorFormat("AssetBundle{0} do not contain asset{1}", assetBundleRes, asset);
        }

        protected override void UnLoad()
        {
            base.UnLoad();
            if (asset is GameObject)
            {

            }
            else
            {
                Resources.UnloadAsset(asset);
            }
            assetBundleRes.Release();
        }

    }

}