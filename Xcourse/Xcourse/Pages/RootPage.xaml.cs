﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xcourse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : TabbedPage
    {
        public RootPage ()
        {
            InitializeComponent();
        }
    }
}