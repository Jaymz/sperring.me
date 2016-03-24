/*
 * MarkdownSharp
 * -------------
 * a C# Markdown processor
 * 
 * Markdown is a text-to-HTML conversion tool for web writers
 * Copyright (c) 2004 John Gruber
 * http://daringfireball.net/projects/markdown/
 * 
 * Markdown.NET
 * Copyright (c) 2004-2009 Milan Negovan
 * http://www.aspnetresources.com
 * http://aspnetresources.com/blog/markdown_announced.aspx
 * 
 * MarkdownSharp
 * Copyright (c) 2009-2010 Jeff Atwood
 * http://stackoverflow.com
 * http://www.codinghorror.com/blog/
 * http://code.google.com/p/markdownsharp/
 * 
 * History: Milan ported the Markdown processor to C#. He granted license to me so I can open source it
 * and let the community contribute to and improve MarkdownSharp.
 * 
 */

#region Copyright and license

/*

Copyright (c) 2009 - 2010 Jeff Atwood

http://www.opensource.org/licenses/mit-license.php
  
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

Copyright (c) 2003-2004 John Gruber
<http://daringfireball.net/>   
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

* Redistributions of source code must retain the above copyright notice,
  this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer in the
  documentation and/or other materials provided with the distribution.

* Neither the name "Markdown" nor the names of its contributors may
  be used to endorse or promote products derived from this software
  without specific prior written permission.

This software is provided by the copyright holders and contributors "as
is" and any express or implied warranties, including, but not limited
to, the implied warranties of merchantability and fitness for a
particular purpose are disclaimed. In no event shall the copyright owner
or contributors be liable for any direct, indirect, incidental, special,
exemplary, or consequential damages (including, but not limited to,
procurement of substitute goods or services; loss of use, data, or
profits; or business interruption) however caused and on any theory of
liability, whether in contract, strict liability, or tort (including
negligence or otherwise) arising in any way out of the use of this
software, even if advised of the possibility of such damage.
*/

#endregion

using System.Configuration;

namespace Blog.Utils
{

    public class MarkdownOptions
    {
        /// <summary>
        /// Default constructor. First loads default values, then
        /// overrides them with any values specified in the configuration file.
        /// Configuration values are specified in the &lt;appSettings&gt;
        /// section of the config file and take the form Markdown.PropertyName
        /// where PropertyName is any of the properties in this class.
        /// </summary>
        public MarkdownOptions() { }


        /// <summary>
        /// Sets all options explicitly and does not attempt to override them with values
        /// from configuration file.
        /// </summary>
        /// <param name="autoHyperlink"></param>
        /// <param name="autoNewlines"></param>
        /// <param name="emptyElementsSuffix"></param>
        /// <param name="encodeProblemUrlCharacters"></param>
        /// <param name="linkEmails"></param>
        /// <param name="nestDepth"></param>
        /// <param name="strictBoldItalic"></param>
        /// <param name="tabWidth"></param>
        public MarkdownOptions(bool autoHyperlink, bool autoNewlines, string emptyElementsSuffix, 
            bool encodeProblemUrlCharacters, bool linkEmails, int nestDepth, bool strictBoldItalic, 
            int tabWidth)
        {
            AutoHyperlink = autoHyperlink;
            AutoNewlines = autoNewlines;
            EmptyElementSuffix = emptyElementsSuffix;
            EncodeProblemUrlCharacters = encodeProblemUrlCharacters;
            LinkEmails = linkEmails;
            NestDepth = nestDepth;
            StrictBoldItalic = strictBoldItalic;
            TabWidth = tabWidth;
        }

        /// <summary>
        /// Sets all fields to their default values
        /// </summary>
        private void Defaults()
        {
            AutoHyperlink = false;
            AutoNewlines = false;
            EmptyElementSuffix = " />";
            EncodeProblemUrlCharacters = false;
            LinkEmails = true;
            NestDepth = 6;
            StrictBoldItalic = false;
            TabWidth = 4;
        }

        /// <summary>
        /// when true, (most) bare plain URLs are auto-hyperlinked  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        public bool AutoHyperlink { get; private set; }

        /// <summary>
        /// when true, RETURN becomes a literal newline  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        public bool AutoNewlines { get; private set; }

        /// <summary>
        /// use ">" for HTML output, or " />" for XHTML output
        /// </summary>
        public string EmptyElementSuffix { get; private set; }

        /// <summary>
        /// when true, problematic URL characters like [, ], (, and so forth will be encoded 
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        public bool EncodeProblemUrlCharacters { get; private set; }

        /// <summary>
        /// when false, email addresses will never be auto-linked  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        public bool LinkEmails { get; private set; }

        /// <summary>
        /// maximum nested depth of [] and () supported by the transform
        /// </summary>
        public int NestDepth { get; private set; }

        /// <summary>
        /// when true, bold and italic require non-word characters on either side  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        public bool StrictBoldItalic { get; private set; }

        /// <summary>
        /// Tabs are automatically converted to spaces as part of the transform  
        /// this variable determines how "wide" those tabs become in spaces
        /// </summary>
        public int TabWidth { get; private set; }
    }
}