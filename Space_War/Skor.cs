using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_War
{
    public partial class Skor : Form
    {
        public Skor()
        {
            InitializeComponent();
        }

        private void Skor_Load(object sender, EventArgs e)
        {

        }
        public void DisplayResult(string resultMessage)
        {
            listBoxResults.Items.Add(resultMessage);
        }
    }
}
