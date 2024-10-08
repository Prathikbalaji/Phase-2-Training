﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLrdwrite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlReader xmlread = XmlReader.Create(@"C:\Users\Prathik.b\Source\Repos\XMLReadWrite\XMLReadWrite\bin\Debug\net8.0\Assets.xml");
            while (xmlread.Read())
            {
                switch (xmlread.NodeType)
                {
                    case XmlNodeType.Element:
                        listBox1.Items.Add("<" + xmlread.Name + ">");
                        break;
                    case XmlNodeType.Text:
                        listBox1.Items.Add(xmlread.Value);
                        break;
                    case XmlNodeType.EndElement:
                        listBox1.Items.Add("</Assets>");
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(@"C:\Users\Prathik.b\Source\Repos\XMLReadWrite\XMLReadWrite\bin\Debug\net8.0\Assets.xml");
            var elets = from ele in doc.Descendants("Assets")
                        select new
                        {
                            AssetId = (string)ele.Element("AssetID"),
                            AssetName = (string)ele.Element("AssetName")
                        };


            foreach (var el in elets)
            {
                listBox2.Items.Add(el.AssetId + " : " + el.AssetName);
            }
        }
    }
}
