using UnityEditor;
using UnityEngine;

namespace GameFramework.ResKit
{
    public class AssetRes : Res
    {

        private string assetBundleName;
        private AssetBundleRes assetBundleRes;

        public AssetRes(string assetPath) : base(assetPath)
        {
            this.assetBundleName = assetBundleName ?? AssetTable.Instance.GetAssetBundleName(assetPath);
        }


        public override void Load()
        {
            base.Load();
#if UNITY_EDITOR
            if (ResMgr.simulateMode)
            {
                asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(Path);
            }
            else
#endif
            {
                if (assetBundleRes == null)
                    assetBundleRes = ResMgr.GetAssetBundleRes(Application.streamingAssetsPath + "/AssetBundles/" + assetBundleName);
                asset = (assetBundleRes.Asset as AssetBundle).LoadAsset(Path);
                if (asset == null)
                    Debug.LogErrorFormat("AssetBundle{0} do not contain asset{1}", assetBundleRes, asset);
            }
        }

        protected override void UnLoad()
        {
            base.UnLoad();
#if UNITY_EDITOR
            if (ResMgr.simulateMode) 
            {
                asset = null;
            }
            else
#endif
            {
                Resources.UnloadAsset(asset);
                assetBundleRes.Release();
                asset = null;
            }
        }

    }

}