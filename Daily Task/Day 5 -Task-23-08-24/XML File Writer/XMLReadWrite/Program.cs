using System.Xml;

namespace Ex1
{

    class Assets
    {
        public int AssetID { get; set; }
        public string AssetName { get; set; }

        public Assets(int assetID,string assetName)
        {
            AssetID = assetID;
            AssetName = assetName;
        }

    }
    internal class Program
    {
        private static void Main(string[] args)
        {

            Assets[] assets = new Assets[3];
            assets[0] = new Assets(1, "Laptop");
            assets[1] = new Assets(2, "Mouse");
            assets[2] = new Assets(3, "Printer");
            using (XmlWriter writer = XmlWriter.Create("Assets.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Assets");
                foreach (Assets asset in assets)
                {
                    writer.WriteStartElement("Assets");
                    writer.WriteElementString("AssetID", asset.AssetID.ToString());
                    writer.WriteElementString("AssetName", asset.AssetName.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }
    }

}

