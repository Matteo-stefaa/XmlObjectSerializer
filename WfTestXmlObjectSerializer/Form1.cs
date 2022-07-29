using MbxmlParser;
using RevEngModels.Staffaggio;
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
            InfoStaffaggioMassello stf = new InfoStaffaggioMassello()
            { 
                InfoBlocchi = new BlocksInformation(),
                Staffaggio = new StaffaggioAttrezzatura()
                {
                    Descrizione = "Staffaggio",
                    Cubo = new Cubo(300),
                    ColonnaPrimaFase = new Colonna(80, 100),
                    ColonnaSecondaFase = new Colonna(80, 100),
                    BPrimaFase = 0,
                    BSecondaFase = 90,
                    FacciaAnteriorePrimaFase = FacceMassello.LEFT,
                    FacciaDestraPrimaFase = FacceMassello.FRONT,
                }
            };
            StaffaggioAttrezzatura stfAttr = stf.Staffaggio as StaffaggioAttrezzatura;
            stfAttr.DctFacceVerticiPrimaFase.Add(FacceMassello.FRONT, Vertice.E);

            string path = Path.GetFullPath("./export.xml");

            Serializer<InfoStaffaggioMassello> ser = new Serializer<InfoStaffaggioMassello>();
            ser.ExportXml(stf, path);
        }
    }
}
