using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_assignment1_LPR281
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Constraint> AllConstraints;
        public int MaxX1 = 1;
        public int MaxX2 = 1;
        public int MinX1 = 0;
        public int MinX2 = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //hallo mensies
        }
    }
}
