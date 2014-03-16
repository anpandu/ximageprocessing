using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Window
{
    public partial class Form_chaincode : Form
    {

        private String cc_text;
        public Form_chaincode(String _filename, String _cc_text)
        {
            InitializeComponent();
            cc_text = _cc_text;
            cc_textbox.Text = cc_text;
            this.Text = _filename;
        }
    }
}
