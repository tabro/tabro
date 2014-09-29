using System.Text.RegularExpressions;
using MarkdownDeep;

namespace Tabro.WebApp
{
    public class MarkdownRenderer : IMarkdownRenderer
    {
        public static Regex rxExtractLanguage = new Regex("^({{(.+)}}\n)", RegexOptions.Compiled);

        public static string FormatCodePrettyPrint(Markdown m, string code)
        {
            Match match = rxExtractLanguage.Match(code);
            string language = null;

            if (match.Success)
            {
                // Save the language
                Group g = match.Groups[2];
                language = g.ToString();

                // Remove the first line
                code = code.Substring(match.Groups[1].Length);
            }


            if (language == null)
            {
                LinkDefinition d = m.GetLinkDefinition("default_syntax");
                if (d != null)
                    language = d.title;
            }
            if (language == "C#")
                language = "csharp";
            if (language == "C++")
                language = "cpp";

            if (string.IsNullOrEmpty(language))
                return string.Format("<pre><code>{0}</code></pre>\n", code);
            return string.Format("<pre class=\"prettyprint lang-{0}\"><code>{1}</code></pre>\n",
                language.ToLowerInvariant(), code);
        }

        public string Transform(string markdown)
        {
            var md = new Markdown
            {
                SafeMode = false,
                ExtraMode = true,
                AutoHeadingIDs = true,
                FormatCodeBlock = FormatCodePrettyPrint,
                ExtractHeadBlocks = true,
                UserBreaks = true
            };

            return md.Transform(markdown);
        }
    }
}