using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Presentation.Forms.Start;

namespace ClockIt.src.Shared.Utils
{
    public class FormHelper
    {
        public static void OpenForm(Form form)
        {
            form.Show();
        }

        public static void OpenFormAndExit(Form form)
        {
            form.Show();
            form.FormClosed += (s, args) => Environment.Exit(0);
        }

        public static void OpenFormWhenShown(Form currentForm, Form newForm)
        {
            currentForm.Shown += async (s, args) =>
            {
                await Task.Delay(700);

                var result = newForm.ShowDialog();

                if (newForm is AdminPasswordForm adminForm && adminForm.ForceCloseMainForm)
                {
                    currentForm.Close();
                }
            };
        }

        public static void OpenFormAsDialog(Form form)
        {
            form.ShowDialog();
        }

        public static void OpenFormAsDialogAndShow(Form currentForm, Form newForm)
        {
            newForm.ShowDialog();
            newForm.Shown += (s, args) => currentForm.Hide();
            newForm.FormClosed += (s, args) => currentForm.Show();
        }

        public static void OpenFormAsDialogAndClose(Form currentForm, Form newForm)
        {
            newForm.ShowDialog();
            newForm.Shown += (s, args) => currentForm.Hide();
            newForm.FormClosed += (s, args) => currentForm.Close();
        }

        public static void OpenFormAndShow(Form currentForm, Form newForm)
        {
            newForm.Show();
            newForm.Shown += (s, args) => currentForm.Hide();
            newForm.FormClosed += (s, args) => currentForm.Show();
        }

        public static void OpenFormAndClose(Form currentForm, Form newForm)
        {
            newForm.Show();
            newForm.Shown += (s, args) => currentForm.Hide();
            newForm.FormClosed += (s, args) => currentForm.Close();
        }

        public static void CloseForm(Form currentForm)
        {
            currentForm.Close();
        }

        public static void SetFormDialogOk(Form form)
        {
            form.DialogResult = DialogResult.OK;
        }

        public static void SetFormDialogCancel(Form form)
        {
            form.DialogResult = DialogResult.Cancel;
        }
    }
}
