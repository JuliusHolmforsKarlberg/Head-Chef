using EPiServer.Cms.TinyMce.Core;
using Head_Chef.Models.Pages;
using Head;
using System.Text;

namespace Head_Chef.Business.TinyMce
{
    public static class TinyMce
    {
        public static void TinyMceConfiguration(this IServiceCollection services)
        {
            var text = new { title = "Brödtext", format = "p" };

            var sbFirstBar = new StringBuilder();
            sbFirstBar.Append(TinyMceNames.Styles + " ");
            sbFirstBar.Append(TinyMceNames.Code + " ");
            sbFirstBar.Append(TinyMceNames.Bold + " ");
            sbFirstBar.Append(TinyMceNames.Italic + " ");
            sbFirstBar.Append(TinyMceNames.Paste + " ");
            sbFirstBar.Append(TinyMceNames.Table);

            services.Configure<TinyMceConfiguration>(config =>
            {
                config
                    .Default()
                    .BodyClass("rte")
                    .Width(650)
                    .Height(250)
                    .AddEpiserverSupport()
                    .ContentCss("~/static/css/editor.css")
                    .AddPlugin("epi-link", "epi-image-editor", "epi-image-tools", "epi-dnd-processor", "code", "wordcount", "table", "directionality", "searchreplace")
                    .Toolbar(sbFirstBar.ToString());

                config.For<StartPage>(x => x.Text);
            });
        }
    }
}