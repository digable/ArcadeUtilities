using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: need something to read the led blinky files and compare with the roms to make sure they are all in there
//-----First task:
//get list of roms in _roms\MAME
//compare with
//C:\Emulators\LEDBlinky_6_5_0_1\LEDBlinky\colors.ini
//C:\Emulators\LEDBlinky_6_5_0_1\LEDBlinky\controls.ini
//C:\Emulators\LEDBlinky_6_5_0_1\LEDBlinky\LEDBlinkyControls.xml
//make sure to compare all the files to each other as well
//check for color inconsistences between Colors.ini and LEDBlinkyControls.xml
//report all of this
//-----

namespace ArcadeUtilities
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();

        }
    }
}
