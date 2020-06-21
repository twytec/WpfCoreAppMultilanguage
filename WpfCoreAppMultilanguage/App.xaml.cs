using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCoreAppMultilanguage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static I18n.Text Text;

        public App()
        {
            var cu = System.Globalization.CultureInfo.CurrentCulture.Name;

            string[] SupportLanguages = new string[] { "en", "de" };
            var f = cu.Split('-')[0];
            var ava = SupportLanguages.FirstOrDefault(a => a == f);

            //default language
            string culture = "en";
            if (ava != null)
                culture = f;

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App).GetTypeInfo()).Assembly;
            var stream = assembly.GetManifestResourceStream($"WpfCoreAppMultilanguage.I18n.{culture}.json");
            using (var sr = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
            {
                var json = sr.ReadToEnd();
                Text = Newtonsoft.Json.JsonConvert.DeserializeObject<I18n.Text>(json);
            }
        }
    }
}
