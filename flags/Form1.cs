using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flags
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.Items.AddRange(new object[]
            {
                this.flags1.Flag = FlagType.cz,
                this.flags1.Flag = FlagType.de,
                this.flags1.Flag = FlagType.ru,
                this.flags1.Flag = FlagType.BigShock,
                this.flags1.Flag = FlagType.usa
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flags1.Flag = (FlagType)this.comboBox1.SelectedItem;
        }
    }
}
