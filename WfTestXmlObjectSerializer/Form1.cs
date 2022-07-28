using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlObjectSerializer;

namespace WfTestXmlObjectSerializer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            Cane cane = new Cane()
            {
                Nome = "Pluto",
                Razza = "Alano",
                Anni = 10
            };

            string path = Path.GetFullPath("./cane.xml");

            Serializer<Cane> ser = new Serializer<Cane>();
            ser.ExportXml(cane, path);
        }
    }
}
