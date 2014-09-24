using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qlik.Engine;


namespace QlikDotNetSDKDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ILocation location = Qlik.Engine.Location.Local;
            using (IHub hub = location.Hub())
            {
                TreeNode treeNode = new TreeNode("Qlik Sense Desktop " + hub.QvVersion());
                int c = 0;
                foreach (IAppIdentifier appIdentifier in location.GetAppIdentifiers())
                {
                    treeNode.Nodes.Add(appIdentifier.AppName);
                    Console.WriteLine(appIdentifier.AppName);
                }
                treeView1.Nodes.Add(treeNode);
                treeNode.Expand();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            label1.Text = e.Node.Text;
            ILocation location = Qlik.Engine.Location.Local;
            IAppIdentifier appId = location.AppWithName(e.Node.Text);
            using (IApp app = location.App(appId))
            {
                textBox1.Text = app.GetScript();
            }

            using (IHub hub = location.Hub())
            { 

            }

        }
    }
}
