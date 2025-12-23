using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Visual.Form
{
    public class BaseForm : System.Windows.Forms.Form 
    {
        public BaseForm()
        {
            BackColor = Theme.Background;
            Font = Theme.DefaultFont;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AutoScaleMode = AutoScaleMode.Font;
            MaximizeBox = false;
        }
    }
}
