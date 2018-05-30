using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MCM.Klasy
{
    class Trigger : TriggerAction<Xamarin.Forms.Entry>
    {
        private string _prevValue = string.Empty;

        protected override void Invoke(Xamarin.Forms.Entry entry)
        {
            var isNumeric = int.TryParse(entry.Text, out int n);

            if (!string.IsNullOrWhiteSpace(entry.Text) && (entry.Text.Length > 9 || !isNumeric))
            {
                entry.Text = _prevValue;
                return;
            }

            _prevValue = entry.Text;
        }
    }
}
