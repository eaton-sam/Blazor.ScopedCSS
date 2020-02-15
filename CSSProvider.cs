using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Components.Rendering;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScopedCSS
{
    public class CSSProvider
    {
        private Dictionary<Type, string> _styles = new Dictionary<Type, string>();
        internal string[] Styles => _styles.Values.ToArray();
        internal Action AddedCallback { get;set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0006:Do not use RenderTree types", Justification = "<Pending>")]
        public void Add<T>(RenderFragment css)
        {
            if(!_styles.ContainsKey(typeof(T)))
            {
                var renderTreeBuilder = new RenderTreeBuilder();
                css.Invoke(renderTreeBuilder);
                var frames = renderTreeBuilder.GetFrames();
                var content = frames.Array.FirstOrDefault().TextContent;

                if(content == null)
                {
                    throw new ArgumentException("RenderFragment can only contain CSS");
                }

                content = Regex.Replace(content, @"\s+", " ");

                var prefix = $"#comp{typeof(T).FullName.GetHashCode()}";
                var sections = content.Split('}').Where(x => !string.IsNullOrWhiteSpace(x));
                var prefixed = string.Join("} ", sections.Select(x => prefix + x)) + "}";

                _styles.Add(typeof(T), prefixed);
                AddedCallback?.Invoke();
            }
        }
    }
}
