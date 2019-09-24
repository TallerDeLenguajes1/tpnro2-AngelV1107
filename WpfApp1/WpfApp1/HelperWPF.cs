using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HelperWPF
{
    public static class Validacion
    {
        public static bool esTxbVacio(TextBox txb)
        {
            return string.IsNullOrWhiteSpace(txb.Text);
        }
        public static bool esTxbTexto(TextBox txb)
        {
            return !esTxbVacio(txb);
        }
        public static bool esFechaPasado(DatePicker dp)
        {
            if (dp.SelectedDate.HasValue)
            {
                if (dp.SelectedDate.Value < DateTime.Today)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool esTxbNumLong(TextBox txb)
        {
            if (esTxbVacio(txb))
            {
                return false;
            }
            else
            {
                long num;
                if (long.TryParse(txb.Text, out num))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool esTxbNumDouble(TextBox txb)
        {
            if (esTxbVacio(txb))
            {
                return false;
            }
            else
            {
                double num;
                if (double.TryParse(txb.Text, out num))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
