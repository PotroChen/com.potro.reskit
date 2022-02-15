using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleBuilder {

    /// <summary>
    /// 将所有标记了AssetLabel的资源打包为AssetBundle,并生成配置表(AssetTable)
    /// </summary>
    [MenuItem("ResKit/GenerateAssetTable")]
    public static void GenerateAssetTable()
    {
        BuildAssets();

        string[] assetBundleNames = AssetDatabase.GetAllAssetBundleNames();

        AssetTable assetTable = new AssetTable();

        foreach (string assetBundleName in assetBundleNames)
        {
            AssetBundleInfo assetBundleInfo = new AssetBundleInfo();
            assetBundleInfo.AssetBundleName = assetBundleName;

            string[] assetPaths = AssetDatabase.GetAssetPathsFromAssetBundle(assetBundleName);
            foreach (string assetPath in assetPaths)
            {
                AssetInfo assetInfo = new AssetInfo();
                assetInfo.AssetName = GetFileName(assetPath);
                assetInfo.OwnerAssetBundleName = assetBundleName;

                assetBundleInfo.AssetInfos.Add(assetInfo);
            }

            assetTable.AssetBundleInfos.Add(assetBundleInfo);
        }

        Chenlin.SerializeUtil.XmlHelper.SerializeToFile(assetTable, CreateAssetBundlePathIfNotExist()+"AssetTable.xml");
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 将所有标记了AssetLabel的资源打包为AssetBundle
    /// </summary>
    private static void BuildAssets()
    {
        var outputPath = CreateAssetBundlePathIfNotExist();

        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.StandaloneWindows64);
    }

    /// <summary>
    /// 获得储存AssetBundle的文件夹路径，若不存在则创建伊戈
    /// </summary>
    /// <returns></returns>
    private static string CreateAssetBundlePathIfNotExist()
    {
        var outputPath = Application.streamingAssetsPath + "/AssetBundles/";
        if (!Directory.Exists(outputPath))
        {
            Debug.LogWarning("This path doesn't exit,create a new one");
            Directory.CreateDirectory(outputPath);
        }
        return outputPath;
    }

    private static string GetFileName(string path)
    {
        string fileName;
        int dotPos = path.LastIndexOf('.');
        int slashPos = path.LastIndexOf('/');
        Debug.Log("dotPos:" + dotPos);
        Debug.Log("slashPos:" + slashPos);
        fileName = path.Substring(slashPos+1, dotPos - slashPos-1);
        return fileName;
    }
}
