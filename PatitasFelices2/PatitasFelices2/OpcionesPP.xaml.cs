﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpcionesPP : TabbedPage
    {
        public OpcionesPP(String codigo, string Nombre)
        {
            InitializeComponent();

            string codigousu = codigo;
            string nombreusu = Nombre;


        }
    }
}