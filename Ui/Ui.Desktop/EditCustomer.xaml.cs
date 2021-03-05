﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videothek.Logic.Ui.ViewModel;

namespace Videothek.Ui.Desktop
{
	/// <summary>
	/// Interaction logic for Kunde.xaml
	/// </summary>
	public partial class EditCustomer : UserControl
    {
		public EditCustomer()
		{
			InitializeComponent();
            Messenger.Default.Register<PropertyChangedMessage<EditResult>>(this, (PropertyChangedMessage<EditResult> e) =>
            {
                if (e.PropertyName.Equals("EditOrAddCustomer"))
                {
                    if (e.NewValue.EditSuccess == true)
                    {
                        MessageBox.Show("Eintrag erfolgreich!");
                        //Jetzt soll die Tabelle im Hauptfenster aktualisieren, also nochmal aufgerufen werden. Das UserContro soll sich schliessen
                        Window.GetWindow(this).Close();
                        //Code vom HauptFenster in DbAbfragen umschreiben, damit von hier einfach aufgerufen werden kann, mit table = "Kunde"
                    }
                    else
                    {
                        MessageBox.Show("Es gab ein Problem. Eintrag wurde nicht ausgeführt!");
                    }
                }
            });
        }
	}
}
