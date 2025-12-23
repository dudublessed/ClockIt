using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Visual.Buttons
{
    public class PrimaryButton : Button
    {
        public PrimaryButton()
        {
            Size = new Size(200, 30);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Theme.Primary;
            ForeColor = Color.White;
            Font = Theme.DefaultFont;
            UseVisualStyleBackColor = false;
            Cursor = Cursors.Hand;
        }
    }
}
